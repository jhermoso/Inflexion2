// -- FILE ------------------------------------------------------------------
// name       : AssemblyInfo.cs
// created    : Jani Giannoudis - 2008.04.28
// language   : c#
// environment: .NET 3.0
// --------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Runtime.InteropServices;

using System.Windows.Markup; // para incluir Xmlnsdefinition 
//// Registramos los namespace entrecomillados siguiendo la fomra de un schema sobre un unico prefijo
[assembly: XmlnsDefinition("http://schemas.InflexionSoftware.com/xaml/usersettings", "I3TV.Framework.UserInterface.Wpf.Utilities.Configuration")]

//// Asignamos un unico prefijo por defecto para el eschema definido anteriormente
[assembly: XmlnsPrefix("http://schemas.InflexionSoftware.com/xaml/usersettings", "ISux")]

[assembly: AssemblyTitle("ConfigurationWindows2010")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("I3TV")]
[assembly: AssemblyProduct("3TV.Framework.Interface.WPF.Utils.Configuration.Windows")]
[assembly: AssemblyCopyright("Copyright © I3TV 2011 - 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]



// -- EOF -------------------------------------------------------------------

