// -- FILE ------------------------------------------------------------------
// name       : AssemblyInfo.cs
// created    : Jani Giannoudis - 2008.04.28
// language   : c#
// environment: .NET 2.0
// --------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Markup;  // necesario para assembly: xmlnsDefinition y xmlnsPrefix se encuntra en el ensamblado de System.Xaml

//// Registramos los namespace entrecomillados siguiendo la fomra de un schema sobre un unico prefijo
[assembly: XmlnsDefinition("http://schemas.i3tv.com/xaml/usersettings", "I3TV.Framework.UserInterface.Wpf.Utilities.Configuration")]
//// Asignamos un unico prefijo por defecto para el eschema definido anteriormente
[assembly: XmlnsPrefix("http://schemas.i3tv.com/xaml/usersettings", "ISux")] // inflexion software user experience

[assembly: AssemblyTitle("InflexionSoftware.Configuration")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("InflexionSoftware")]
[assembly: AssemblyProduct("InflexionSoftware.WpfConfiguration")]
[assembly: AssemblyCopyright("Copyright © InflexionSoftware 2011 - 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// -- EOF -------------------------------------------------------------------
