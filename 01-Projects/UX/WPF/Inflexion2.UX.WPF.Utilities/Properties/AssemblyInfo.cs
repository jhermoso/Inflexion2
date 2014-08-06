//-----------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="Inflexion">
//     Copyright (c)2012. Inflexion. All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------


using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Markup; // para incluir Xmlnsdefinition necesitamos este using fuera del namespace

[assembly: AssemblyTitle("Inflexion.Framework.UserInterface.Wpf.Utilities")]
[assembly: AssemblyDescription("Ensamblado con librerías pertenecientes al core o base principal común que será reutilizada por la mayoría de ensamblados de la solución.")]
[assembly: AssemblyProduct("Inflexion.Framework.UserInterface.Wpf.Utilities.dll")]

// Registramos los namespace entrecomillados siguiendo la forma de un schema sobre un único prefijo
[assembly: XmlnsDefinition("http://schemas.InflexionSoftware.com/xaml/presentation", "Inflexion.Framework.UserInterface.Wpf.Utilities")]

// Asignamos un único prefijo por defecto para el eschema definido anteriormente
[assembly: XmlnsPrefix("http://schemas.InflexionSoftware.com/xaml/presentation", "ISth")]