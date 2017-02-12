//----------------------------------------------------------------------------------------------
// <copyright file="DataAnnotationHelper.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain.Validation
{
    using GNU.Gettext;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Static class capable of readinng de DataAnnotations of a type and return a list of corresponding IValidationInfos.
    /// </summary>
    internal static class DataAnnotationHelper
    {
        public static string ParseDisplayName(Type entityType, string propertyName)
        {
            string displayName = propertyName;

            DisplayAttribute displayAttribute = TypeDescriptor.GetProperties(entityType)
                                                .Cast<PropertyDescriptor>()
                                                .Where(p => p.Name == propertyName)
                                                .SelectMany(p => p.Attributes.OfType<DisplayAttribute>()).FirstOrDefault();

            if (displayAttribute != null)
            {
                displayName = displayAttribute.Name;
            }

            return GettextHelper.t(displayName, entityType.Assembly);
        }
    }
}