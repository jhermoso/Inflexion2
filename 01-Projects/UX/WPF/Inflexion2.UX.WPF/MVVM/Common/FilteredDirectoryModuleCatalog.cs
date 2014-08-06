// -----------------------------------------------------------------------
// <copyright file="FilteredDirectoryModuleCatalog.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows;

    using Microsoft.Practices.Prism.Modularity;

    /// <summary>
    /// Representa un catálogo de módulos creado desde un directorio filtrado.
    /// </summary>
    internal sealed class FilteredDirectoryModuleCatalog : DirectoryModuleCatalog
    {
        #region Constants

        /// <summary>
        /// Define el filtro por defecto.
        /// </summary>
        private const string DefaultFilter = "*.dll";

        #endregion

        #region Fields

        /// <summary>
        /// Representa el filtro.
        /// </summary>
        private string filter;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:FilteredDirectoryModuleCatalog"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:FilteredDirectoryModuleCatalog"/>.
        /// </remarks>
        public FilteredDirectoryModuleCatalog()
        {
            // Asignación del filtro por defecto.
            this.Filter = DefaultFilter;

            // Asignación de la ruta por defecto.
            var appDirectory = Application.Current.GetType().Assembly.Location;
            this.ModulePath = Path.GetDirectoryName(appDirectory);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene o establece el filtro.
        /// </summary>
        /// <value>
        /// Cadena que contiene el filtro.
        /// </value>
        public string Filter
        {
            get
            {
                return this.filter;
            }
            set
            {
                if (this.filter != value)
                {
                    this.filter = value;
                }
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Acciona la lógica principal de la construcción del dominio secundario
        /// y la búsqueda de las ensamblados que contienen módulos Prism definidos.
        /// </summary>
        protected override void InnerLoad()
        {
            if (string.IsNullOrEmpty(this.ModulePath))
            {
                throw new InvalidOperationException("ModulePathCannotBeNullOrEmpty");
            }

            if (!Directory.Exists(this.ModulePath))
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.CurrentCulture, "DirectoryNotFound", this.ModulePath));
            }

            AppDomain childDomain = this.BuildChildDomain(AppDomain.CurrentDomain);

            try
            {
                List<string> loadedAssemblies = new List<string>();

                var assemblies =
                    from Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()
                    where !(assembly is System.Reflection.Emit.AssemblyBuilder)
                    && assembly.GetType().FullName != "System.Reflection.Emit.InternalAssemblyBuilder"
                    && !string.IsNullOrEmpty(assembly.Location)
                    select assembly.Location;

                loadedAssemblies.AddRange(assemblies);

                Type loaderType = typeof(InnerModuleInfoLoader);

                if (loaderType.Assembly != null)
                {
                    var loader =
                        (InnerModuleInfoLoader)
                        childDomain.CreateInstanceFrom(loaderType.Assembly.Location, loaderType.FullName).Unwrap();

                    loader.LoadAssemblies(loadedAssemblies);

                    foreach (ModuleInfo item in loader.GetModuleInfos(this.ModulePath, this.Filter))
                    {
                        this.Items.Add(item);
                    }
                }
            }
            finally
            {
                AppDomain.Unload(childDomain);
            }
        }

        #endregion

        #region Internal Classes

        /// <summary>
        /// Cargador de información de módulos Prism.
        /// </summary>
        internal class InnerModuleInfoLoader : MarshalByRefObject
        {
            #region Internal Methods

            /// <summary>
            /// Obtiene la información de módulos a partir de una ruta y filtro determinado.
            /// </summary>
            /// <param name="path">
            /// Ruta donde se va a realizar la búsqueda.
            /// </param>
            /// <param name="filter">
            /// Filtro que se va a aplicar.
            /// </param>
            /// <returns>
            /// Matriz que contiene la información de módulos obtenida.
            /// </returns>
            [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "No es necesario.")]
            internal ModuleInfo[] GetModuleInfos(string path, string filter)
            {
                DirectoryInfo directory = new DirectoryInfo(path);

                ResolveEventHandler resolveEventHandler =
                    delegate(object sender, ResolveEventArgs args) { return OnReflectionOnlyResolve(args, directory); };

                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += resolveEventHandler;

                Assembly moduleReflectionOnlyAssembly =
                    AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies().First(
                        asm => asm.FullName == typeof(IModule).Assembly.FullName);
                Type moduleType = moduleReflectionOnlyAssembly.GetType(typeof(IModule).FullName);

                IEnumerable<ModuleInfo> modules = GetNotAllreadyLoadedModuleInfos(directory, filter, moduleType);

                var array = modules.ToArray();
                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= resolveEventHandler;
                return array;
            }

            /// <summary>
            /// Carga los ensamblados especificados.
            /// </summary>
            /// <param name="assemblies">
            /// Ensamblados que se van a cargar.
            /// </param>
            [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "No es necesario.")]
            internal void LoadAssemblies(IEnumerable<string> assemblies)
            {
                foreach (string assemblyPath in assemblies)
                {
                    try
                    {
                        Assembly.ReflectionOnlyLoadFrom(assemblyPath);
                    }
                    catch (FileNotFoundException)
                    {
                        // Continuar cargando los ensamblados a pesar de que no se pueda
                        // cargar un determinado ensamblado en el nuevo dominio de aplicación.
                    }
                }
            }

            #endregion

            #region Private Static Methods

            /// <summary>
            /// Crea la información de módulo a partir de su tipo.
            /// </summary>
            /// <param name="type">
            /// Tipo que se va a utilizar.
            /// </param>
            /// <returns>
            /// Información de módulo del tipo indicado.
            /// </returns>
            private static ModuleInfo CreateModuleInfo(Type type)
            {
                string moduleName = type.Name;
                List<string> dependsOn = new List<string>();
                bool onDemand = false;
                var moduleAttribute =
                    CustomAttributeData.GetCustomAttributes(type).FirstOrDefault(
                        cad => cad.Constructor.DeclaringType.FullName == typeof(ModuleAttribute).FullName);

                if (moduleAttribute != null)
                {
                    foreach (CustomAttributeNamedArgument argument in moduleAttribute.NamedArguments)
                    {
                        string argumentName = argument.MemberInfo.Name;
                        switch (argumentName)
                        {
                            case "ModuleName":
                                moduleName = (string)argument.TypedValue.Value;
                                break;

                            case "OnDemand":
                                onDemand = (bool)argument.TypedValue.Value;
                                break;

                            case "StartupLoaded":
                                onDemand = !((bool)argument.TypedValue.Value);
                                break;
                        }
                    }
                }

                var moduleDependencyAttributes =
                    CustomAttributeData.GetCustomAttributes(type).Where(
                        cad => cad.Constructor.DeclaringType.FullName == typeof(ModuleDependencyAttribute).FullName);

                foreach (CustomAttributeData cad in moduleDependencyAttributes)
                {
                    dependsOn.Add((string)cad.ConstructorArguments[0].Value);
                }

                ModuleInfo moduleInfo = new ModuleInfo(moduleName, type.AssemblyQualifiedName)
                {
                    InitializationMode =
                        onDemand
                            ? InitializationMode.OnDemand
                            : InitializationMode.WhenAvailable,
                    Ref = type.Assembly.CodeBase,
                };

                foreach (string item in dependsOn)
                {
                    moduleInfo.DependsOn.Add(item);
                }

                return moduleInfo;
            }

            /// <summary>
            /// Obtener las informaciones de módulo que todavía no estén cargadas.
            /// </summary>
            /// <param name="directory">
            /// Directorio donde se va a realizar la búsqueda.
            /// </param>
            /// <param name="filter">
            /// Filtro que se va a utilizar.
            /// </param>
            /// <param name="moduleType">
            /// Tipo de módulo.
            /// </param>
            /// <returns>
            /// Informaciones de módulo obtenidas.
            /// </returns>
            private static IEnumerable<ModuleInfo> GetNotAllreadyLoadedModuleInfos(DirectoryInfo directory, string filter, Type moduleType)
            {
                List<FileInfo> validAssemblies = new List<FileInfo>();
                
                Assembly[] alreadyLoadedAssemblies = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies();

                var fileInfos = directory.GetFiles(filter)
                    .Where(file => alreadyLoadedAssemblies
                                       .FirstOrDefault(
                                       assembly => string.Compare(
                                           Path.GetFileName(assembly.Location),
                                           file.Name,
                                           StringComparison.OrdinalIgnoreCase) == 0) == null);

                foreach (FileInfo fileInfo in fileInfos)
                {
                    Assembly assembly = null;
                    try
                    {
                        assembly = Assembly.ReflectionOnlyLoadFrom(fileInfo.FullName);
                        validAssemblies.Add(fileInfo);
                    }
                    catch (BadImageFormatException)
                    {
                        // Saltar las DLL que no son .NET
                    }
                }

                var result = validAssemblies.SelectMany(file => Assembly.ReflectionOnlyLoadFrom(file.FullName)
                                            .GetExportedTypes()
                                            .Where(moduleType.IsAssignableFrom)
                                            .Where(t => t != moduleType)
                                            .Where(t => !t.IsAbstract)
                                            .Select(type => CreateModuleInfo(type)));
                return result;
            }

            /// <summary>
            /// Se invoca solamente al resolver en el contexto de reflexión.
            /// </summary>
            /// <param name="args">
            /// Datos del evento.
            /// </param>
            /// <param name="directory">
            /// Directorio donde se va a realizar la búsqueda.
            /// </param>
            /// <returns>
            /// Ensamblado resuelto.
            /// </returns>
            private static Assembly OnReflectionOnlyResolve(ResolveEventArgs args, DirectoryInfo directory)
            {
                Assembly loadedAssembly = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies().FirstOrDefault(
                    asm => string.Equals(asm.FullName, args.Name, StringComparison.OrdinalIgnoreCase));
                if (loadedAssembly != null)
                {
                    return loadedAssembly;
                }
                AssemblyName assemblyName = new AssemblyName(args.Name);
                string dependentAssemblyFilename = Path.Combine(directory.FullName, assemblyName.Name + ".dll");
                if (File.Exists(dependentAssemblyFilename))
                {
                    return Assembly.ReflectionOnlyLoadFrom(dependentAssemblyFilename);
                }
                return Assembly.ReflectionOnlyLoad(args.Name);
            }

            #endregion
        }

        #endregion
    }
}