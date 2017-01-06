﻿#region Copyright information
// <copyright file="ResxLocalizationProviderBase.cs">
//     Licensed under Microsoft Public License (Ms-PL)
//     http://wpflocalizeextension.codeplex.com/license
// </copyright>
// <author>Uwe Mayer</author>
// <author>Bernhard Millauer</author>
#endregion

namespace WPFLocalizeExtension.Providers
{
    #region Uses
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Windows;
    using System.Management;
    #endregion

    /// <summary>
    /// The base for RESX file providers.
    /// </summary>
    public abstract class ResxLocalizationProviderBase : DependencyObject, ILocalizationProvider
    {
        #region Variables
        /// <summary>
        /// Holds the name of the Resource Manager.
        /// </summary>
        private const string ResourceManagerName = "ResourceManager";

        /// <summary>
        /// Holds the extension of the resource files.
        /// </summary>
        private const string ResourceFileExtension = ".resources";

        /// <summary>
        /// Holds the binding flags for the reflection to find the resource files.
        /// </summary>
        private const BindingFlags ResourceBindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

        /// <summary>
        /// Gets the used ResourceManagers with their corresponding <c>namespaces</c>.
        /// </summary>
        protected Dictionary<string, ResourceManager> ResourceManagerList;

        /// <summary>
        /// Lock object for concurrent access to the resource manager list.
        /// </summary>
        protected object ResourceManagerListLock = new object();

        /// <summary>
        /// Lock object for concurrent access to the available culture list.
        /// </summary>
        protected object AvailableCultureListLock = new object();

        private bool ignoreCase = true;
        /// <summary>
        /// Gets or sets the ignore case flag.
        /// </summary>
        public bool IgnoreCase
        {
            get { return ignoreCase; }
            set { ignoreCase = value; }
        }
        #endregion

        #region Helper functions
        /// <summary>
        /// Returns the <see cref="AssemblyName"/> of the passed assembly instance
        /// </summary>
        /// <param name="assembly">The Assembly where to get the name from</param>
        /// <returns>The Assembly name</returns>
        protected string GetAssemblyName(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            if (assembly.FullName == null)
            {
                throw new NullReferenceException("assembly.FullName is null");
            }

            return assembly.FullName.Split(',')[0];
        }

        /// <summary>
        /// Parses a key ([[Assembly:]Dict:]Key and return the parts of it.
        /// </summary>
        /// <param name="inKey">The key to parse.</param>
        /// <param name="outAssembly">The found or default assembly.</param>
        /// <param name="outDict">The found or default dictionary.</param>
        /// <param name="outKey">The found or default key.</param>
        public static void ParseKey(string inKey, out string outAssembly, out string outDict, out string outKey)
        {
            // Reset everything to null.
            outAssembly = null;
            outDict = null;
            outKey = null;

            if (!string.IsNullOrEmpty(inKey))
            {
                string[] split = inKey.Trim().Split(":".ToCharArray());

                // assembly:dict:key
                if (split.Length == 3)
                {
                    outAssembly = !string.IsNullOrEmpty(split[0]) ? split[0] : null;
                    outDict = !string.IsNullOrEmpty(split[1]) ? split[1] : null;
                    outKey = split[2];
                }

                // dict:key
                if (split.Length == 2)
                {
                    outDict = !string.IsNullOrEmpty(split[0]) ? split[0] : null;
                    outKey = split[1];
                }

                // key
                if (split.Length == 1)
                {
                    outKey = split[0];
                }
            }
        }
        #endregion

        #region Abstract assembly & dictionary lookup
        /// <summary>
        /// Get the assembly from the context, if possible.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <returns>The assembly name, if available.</returns>
        protected abstract string GetAssembly(DependencyObject target);

        /// <summary>
        /// Get the dictionary from the context, if possible.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <returns>The dictionary name, if available.</returns>
        protected abstract string GetDictionary(DependencyObject target);
        #endregion

        #region ResourceManager management
        /// <summary>
        /// Thread-safe access to the resource manager dictionary.
        /// </summary>
        /// <param name="thekey">Key.</param>
        /// <param name="result">Value.</param>
        /// <returns>Success of the operation.</returns>
        protected bool TryGetValue(string thekey, out ResourceManager result)
        {
            lock (ResourceManagerListLock) { return this.ResourceManagerList.TryGetValue(thekey, out result); }
        }

        /// <summary>
        /// Thread-safe access to the resource manager dictionary.
        /// </summary>
        /// <param name="thekey">Key.</param>
        /// <param name="value">Value.</param>
        protected void Add(string thekey, ResourceManager value)
        {
            lock (ResourceManagerListLock) { this.ResourceManagerList.Add(thekey, value); }
        }

        /// <summary>
        /// Tries to remove a key from the resource manager dictionary.
        /// </summary>
        /// <param name="thekey">Key.</param>
        protected void TryRemove(string thekey)
        {
            lock (ResourceManagerListLock) { if (this.ResourceManagerList.ContainsKey(thekey)) this.ResourceManagerList.Remove(thekey); }
        }

        /// <summary>
        /// Clears the whole list of cached resource managers.
        /// </summary>
        public void ClearResourceManagerList()
        {
            lock (ResourceManagerListLock) { this.ResourceManagerList.Clear(); }
        }

        /// <summary>
        /// Thread-safe access to the AvailableCultures list.
        /// </summary>
        /// <param name="c">The CultureInfo.</param>
        protected void AddCulture(CultureInfo c)
        {
            lock (AvailableCultureListLock)
            {
                if (!this.AvailableCultures.Contains(c))
                    this.AvailableCultures.Add(c);
            }
        }

        /// <summary>
        /// Updates the list of available cultures using the given resource location.
        /// </summary>
        /// <param name="resourceAssembly">The resource assembly.</param>
        /// <param name="resourceDictionary">The dictionary to look up.</param>
        /// <returns>True, if the update was successful.</returns>
        public bool UpdateCultureList(string resourceAssembly, string resourceDictionary)
        {
            return GetResourceManager(resourceAssembly, resourceDictionary) != null;
        }

        private static Dictionary<int, string> executablePaths = new Dictionary<int, string>();
        private DateTime lastUpdateCheck = DateTime.MinValue;

        private static string projectDirectory = null;
        private static string[] projectFilesCache = null;

        /// <summary>
        /// Get the executable path for both x86 and x64 processes.
        /// </summary>
        /// <param name="processId">The process id.</param>
        /// <returns>The path if found; otherwise, null.</returns>
        private static string GetExecutablePath(int processId)
        {
            if (executablePaths.ContainsKey(processId))
                return executablePaths[processId];

            const string wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            using (var results = searcher.Get())
            {
                var query = from p in Process.GetProcesses()
                            join mo in results.Cast<ManagementObject>()
                            on p.Id equals (int)(uint)mo["ProcessId"]
                            where p.Id == processId
                            select new
                            {
                                Process = p,
                                Path = (string)mo["ExecutablePath"],
                                CommandLine = (string)mo["CommandLine"],
                            };
                foreach (var item in query)
                {
                    executablePaths.Add(processId, item.Path);
                    return item.Path;
                }
            }

            return null;
        }

        private static bool IsFileOfInterest(string f, string dir)
        {
            if (String.IsNullOrEmpty(f))
                return false;

            if (!(f.EndsWith(".resx", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".resources.dll", StringComparison.OrdinalIgnoreCase) ||
                  f.EndsWith(".resources", StringComparison.OrdinalIgnoreCase)) &&
                !dir.Equals(Path.GetDirectoryName(f), StringComparison.OrdinalIgnoreCase))
                return false;

            return true;
        }

        /// <summary>
        /// Looks up in the cached <see cref="ResourceManager"/> list for the searched <see cref="ResourceManager"/>.
        /// </summary>
        /// <param name="resourceAssembly">The resource assembly.</param>
        /// <param name="resourceDictionary">The dictionary to look up.</param>
        /// <returns>
        /// The found <see cref="ResourceManager"/>
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        /// If the ResourceManagers cannot be looked up
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If the searched <see cref="ResourceManager"/> wasn't found
        /// </exception>
        protected ResourceManager GetResourceManager(string resourceAssembly, string resourceDictionary)
        {
            Assembly assembly = null;
            ResourceManager resManager;
            string foundResource = null;
            string resManagerNameToSearch = "." + resourceDictionary + ResourceFileExtension;

            var resManKey = resourceAssembly + resManagerNameToSearch;

            // Here comes our great hack for full VS2012+ design time support with multiple languages.
            // We check only every second to reduce overhead in the designer.
            var now = DateTime.Now;
            
            if (AppDomain.CurrentDomain.FriendlyName.Contains("XDesProc") && ((now - lastUpdateCheck).TotalSeconds >= 1.0))
            {
                // This block is only handled during design time.
                lastUpdateCheck = now;

                // Get the directory of the executing assembly (some strange path in the middle of nowhere on the disk and attach "\tmp", e.g.:
                // %userprofile%\AppData\Local\Microsoft\VisualStudio\12.0\Designer\ShadowCache\erys4uqz.oq1\l24nfewi.r0y\tmp\
                var assemblyDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "tmp");

                // If not done yet, find the VS process that shows our design.
                if (string.IsNullOrEmpty(projectDirectory))
                {
                    foreach (var process in Process.GetProcesses())
                    {
                        if (!process.ProcessName.Contains(".vshost"))
                            continue;

                        // Get the executable path (all paths are cached now in order to reduce WMI load.
                        projectDirectory = Path.GetDirectoryName(GetExecutablePath(process.Id));

                        if (string.IsNullOrEmpty(projectDirectory))
                            continue;

                        // Get all files.
                        var files = Directory.GetFiles(projectDirectory, "*.*", SearchOption.AllDirectories);

                        if (files.Where(f => Path.GetFileName(f).StartsWith(resourceAssembly)).Count() > 0)
                        {
                            // We got a hit. Filter the files that are of interest for this provider.
                            projectFilesCache = files.Where(f => IsFileOfInterest(f, projectDirectory)).ToArray();

                            // Must break here - otherwise, we might catch another instance of VS.
                            break;
                        }
                    }
                }
                else
                {
                    // Remove the resource manager from the dictionary.
                    TryRemove(resManKey);

                    // Copy all newer or missing files.
                    foreach (var f in projectFilesCache)
                    {
                        try
                        {
                            var dst = Path.Combine(assemblyDir, f.Replace(projectDirectory + "\\", ""));

                            if (!File.Exists(dst) || (Directory.GetLastWriteTime(dst) < Directory.GetLastWriteTime(f)))
                            {
                                var dstDir = Path.GetDirectoryName(dst);
                                if (String.IsNullOrEmpty(dstDir))
                                    continue;
                                if (!Directory.Exists(dstDir))
                                    Directory.CreateDirectory(dstDir);

                                File.Copy(f, dst, true);
                            }
                        }
                        // ReSharper disable once EmptyGeneralCatchClause
                        catch { }
                    }

                    // Prepare and load (new) assembly.
                    var file = Path.Combine(assemblyDir, resourceAssembly + ".exe");
                    if (!File.Exists(file))
                        file = Path.Combine(assemblyDir, resourceAssembly + ".dll");

                    assembly = Assembly.LoadFrom(file);
                }
            }

            if (!TryGetValue(resManKey, out resManager))
            {
                // If the assembly cannot be loaded, throw an exception
                if (assembly == null)
                {
                    try
                    {
                        // go through every assembly loaded in the app domain
                        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                        foreach (var assemblyInAppDomain in loadedAssemblies)
                        {
                            // get the assembly name object
                            AssemblyName assemblyName = new AssemblyName(assemblyInAppDomain.FullName);

                            // check if the name of the assembly is the seached one
                            if (assemblyName.Name == resourceAssembly)
                            {
                                // assigne the assembly
                                assembly = assemblyInAppDomain;

                                // stop the search here
                                break;
                            }
                        }

                        // check if the assembly is still null
                        if (assembly == null)
                        {
                            // assign the loaded assembly
                            assembly = Assembly.Load(new AssemblyName(resourceAssembly));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("The Assembly '{0}' cannot be loaded.", resourceAssembly), ex);
                    }
                }

                // get all available resourcenames
                string[] availableResources = assembly.GetManifestResourceNames();

                // get all available types (and ignore unloadable types, e.g. because of unsatisfied dependencies)
                IEnumerable<Type> availableTypes;
                try
                {
                    availableTypes = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException e)
                {
                    availableTypes = e.Types.Where(t => t != null);
                }

                // The proposed approach of Andras (http://wpflocalizeextension.codeplex.com/discussions/66098?ProjectName=wpflocalizeextension)
                Func<Type, string> tryGetNamespace = delegate(Type type)
                {
                    // Ignore unloadable types
                    try
                    {
                        return type.Namespace;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                };
                var possiblePrefixes = availableTypes.Select(tryGetNamespace).Where(n => n != null).Distinct().ToList();

                foreach (string availableResource in availableResources)
                {
                    if (availableResource.EndsWith(resManagerNameToSearch) && possiblePrefixes.Any(p => availableResource.StartsWith(p + ".")))
                    {
                        // take the first occurrence and break
                        foundResource = availableResource;
                        break;
                    }
                }

                // NOTE: Inverted this IF (nesting is bad, I know) so we just create a new ResourceManager.  -gen3ric
                if (foundResource != null)
                {
                    // remove ".resources" from the end
                    foundResource = foundResource.Substring(0, foundResource.Length - ResourceFileExtension.Length);

                    // First try the simple retrieval
                    Type resourceManagerType;
                    try
                    {
                        resourceManagerType = assembly.GetType(foundResource);
                    }
                    catch (Exception)
                    {
                        resourceManagerType = null;
                    }

                    // If simple doesn't work, check all of the types without using dot notation
                    if (resourceManagerType == null)
                    {
                        var dictTypeName = resourceDictionary.Replace('.', '_');

                        Func<Type, bool> matchesDictTypeName = delegate(Type type)
                        {
                            // Ignore unloadable types
                            try
                            {
                                return type.Name == dictTypeName;
                            }
                            catch (Exception)
                            {
                                return false;
                            }
                        };
                        resourceManagerType = availableTypes.FirstOrDefault(matchesDictTypeName);
                    }

                    resManager = GetResourceManagerFromType(resourceManagerType);
                }
                else
                {
                    resManager = new ResourceManager(resManagerNameToSearch, assembly);
                }

                // if no one was found, exception
                if (resManager == null)
                    throw new ArgumentException(string.Format("No resource manager for dictionary '{0}' in assembly '{1}' found! ({1}.{0})", resourceDictionary, resourceAssembly));

                // Add the ResourceManager to the cachelist
                Add(resManKey, resManager);

                try
                {
                    var assemblyLocation = Path.GetDirectoryName(assembly.Location);

                    // Get the list of all cultures.
                    var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
                    
                    foreach (var c in cultures)
                    {
                        var rs = resManager.GetResourceSet(c, true, false);
                        if (rs != null)
                            AddCulture(c);
                    }
                }
                catch
                {
                    // This may lead to problems with Silverlight
                }
            }

            // return the found ResourceManager
            return resManager;
        }

        private ResourceManager GetResourceManagerFromType(Type type)
        {
            if (type == null)
                return null;
            try
            {
                var propInfo = type.GetProperty(ResourceManagerName, ResourceBindingFlags);

                // get the GET-method from the methodinfo
                var methodInfo = propInfo.GetGetMethod(true);

                // cast it to a ResourceManager for better working with
                return (ResourceManager)methodInfo.Invoke(null, null);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region ILocalizationProvider implementation
        /// <summary>
        /// Uses the key and target to build a fully qualified resource key (Assembly, Dictionary, Key)
        /// </summary>
        /// <param name="key">Key used as a base to find the full key</param>
        /// <param name="target">Target used to help determine key information</param>
        /// <returns>Returns an object with all possible pieces of the given key (Assembly, Dictionary, Key)</returns>
        public FullyQualifiedResourceKeyBase GetFullyQualifiedResourceKey(String key, DependencyObject target)
        {
            if (String.IsNullOrEmpty(key))
                return null;
            String assembly, dictionary;
            ParseKey(key, out assembly, out dictionary, out key);
            
            if (String.IsNullOrEmpty(assembly))
                assembly = GetAssembly(target);

            if (String.IsNullOrEmpty(dictionary))
                dictionary = GetDictionary(target);

            return new FQAssemblyDictionaryKey(key, assembly, dictionary);
        }

        /// <summary>
        /// Gets fired when the provider changed.
        /// </summary>
        public event ProviderChangedEventHandler ProviderChanged;

        /// <summary>
        /// An event that is fired when an error occurred.
        /// </summary>
        public event ProviderErrorEventHandler ProviderError;

        /// <summary>
        /// An event that is fired when a value changed.
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;

        /// <summary>
        /// Calls the <see cref="ILocalizationProvider.ProviderChanged"/> event.
        /// </summary>
        /// <param name="target">The target object.</param>
        protected virtual void OnProviderChanged(DependencyObject target)
        {
            try
            {
                var assembly = GetAssembly(target);
                var dictionary = GetDictionary(target);

                if (!String.IsNullOrEmpty(assembly) && !String.IsNullOrEmpty(dictionary))
                    GetResourceManager(assembly, dictionary);
            }
            catch
            {
            }

            if (ProviderChanged != null)
                ProviderChanged(this, new ProviderChangedEventArgs(target));
        }

        /// <summary>
        /// Calls the <see cref="ILocalizationProvider.ProviderError"/> event.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="key">The key.</param>
        /// <param name="message">The error message.</param>
        protected virtual void OnProviderError(DependencyObject target, string key, string message)
        {
            if (ProviderError != null)
                ProviderError(this, new ProviderErrorEventArgs(target, key, message));
        }

        /// <summary>
        /// Calls the <see cref="ILocalizationProvider.ValueChanged"/> event.
        /// </summary>
        /// <param name="key">The key where the value was changed.</param>
        /// <param name="value">The new value.</param>
        /// <param name="tag">A custom tag.</param>
        protected virtual void OnValueChanged(string key, object value, object tag)
        {
            if (ValueChanged != null)
                ValueChanged(this, new ValueChangedEventArgs(key, value, tag));
        }

        /// <summary>
        /// Get the localized object.
        /// </summary>
        /// <param name="key">The key to the value.</param>
        /// <param name="target">The target object.</param>
        /// <param name="culture">The culture to use.</param>
        /// <returns>The value corresponding to the source/dictionary/key path for the given culture (otherwise NULL).</returns>
        public virtual object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture)
        {
            string assembly;
            string dictionary;

            // Call this function to provide backward compatibility.
            ParseKey(key, out assembly, out dictionary, out key);

            // Now try to read out the default assembly and/or dictionary.
            if (String.IsNullOrEmpty(assembly))
                assembly = GetAssembly(target);
            if (String.IsNullOrEmpty(dictionary))
                dictionary = GetDictionary(target);

            // Final validation of the values.
            if (String.IsNullOrEmpty(assembly))
            {
                OnProviderError(target, key, "No assembly provided.");
                return null;
            }

            if (String.IsNullOrEmpty(dictionary))
            {
                OnProviderError(target, key, "No dictionary provided.");
                return null;
            }

            if (String.IsNullOrEmpty(key))
            {
                OnProviderError(target, key, "No key provided.");
                return null;
            }

            // declaring local resource manager
            ResourceManager resManager;

            // try to get the resouce manager
            try
            {
                resManager = GetResourceManager(assembly, dictionary);
            }
            catch (Exception e)
            {
                OnProviderError(target, key, "Error retrieving the resource manager.\r\n" + e.Message);
                return null;
            }

            // finally, return the searched object as type of the generic type
            try
            {
                resManager.IgnoreCase = ignoreCase;
                var result = resManager.GetObject(key, culture);

                if (result == null)
                    OnProviderError(target, key, "Missing key.");

                return result;
            }
            catch (Exception e)
            {
                OnProviderError(target, key, "Error retrieving the resource.\r\n" + e.Message);
                return null;
            }
        }

        /// <summary>
        /// An observable list of available cultures.
        /// </summary>
        public ObservableCollection<CultureInfo> AvailableCultures { get; protected set; }
        #endregion
    }
}
