// -----------------------------------------------------------------------
// <copyright file="PropertyExtension.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// <para>
    /// Clase estática que permite obtener la descripción y el nombre de la
    /// propiedad.
    /// </para>
    /// <para>
    /// Para obtener la descripción de la propiedad, ésta debería tener la
    /// etiqueta o decorado DescriptionAttribute.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Permite obtener la descripción y el nombre de la propiedad.
    /// </remarks>
    /// <example>
    /// Ejemplo de uso:
    /// <code>
    ///   <![CDATA[
    /// string nameField = "";
    /// nameField = msisdnInformation.GetPropertyName(o => msisdnInformation.Version);
    /// string nameDescriptionField = msisdnInformation.GetPropertyDescription(nameField);
    ///   ]]>
    /// </code>
    /// </example>
    public static class PropertyExtension
    {
        #region Methods

        /// <summary>
        /// Función para obtener la descripción de la propiedad.
        /// </summary>
        /// <remarks>
        /// Obtiene la descripción de la propiedad.
        /// </remarks>
        /// <param name="structure">
        /// Nombre de la estructura.
        /// </param>
        /// <param name="nameField">
        /// Nombre del campo de la propiedad.
        /// </param>
        /// <returns>
        /// Descripción de la propiedad de la etiqueta o decorado
        /// <seealso cref="DescriptionAttribute"/>.
        /// </returns>
        public static string GetPropertyDescription(
            this object structure,
            string nameField)
        {
            PropertyInfo field = structure.GetType().GetProperty(nameField);
            if (field != null)
            {
                object[] attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return (attributes[0] as DescriptionAttribute).Description;
                }
            }
            // Devuelte la descripción de la propiedad.
            return structure.ToString();
        }

        /// <summary>
        /// Función Lambda para obtener el nombre de la propiedad.
        /// </summary>
        /// <remarks>
        /// Obtiene el nombre de la propiedad.
        /// </remarks>
        /// <typeparam name="T">
        /// Primer parámetro Lambda.
        /// </typeparam>
        /// <typeparam name="R">
        /// Segundo parámetro Lambda.
        /// </typeparam>
        /// <param name="objectParameter">
        /// Parámetro que corresponde con el objeto en sí encargado de
        /// realizar la llamada.</param>
        /// <param name="expression">
        /// Expresión Lambda a utilizar.
        /// </param>
        /// <returns>
        /// Nombre de la propiedad que será utilizada para obtener
        /// la descripción de la propiedad.
        /// </returns>
        public static string GetPropertyName<T, R>(
            this T objectParameter,
            Expression<Func<T, R>> expression)
        {
            // Devuelve el nombre de la propiedad
            return ((MemberExpression)((LambdaExpression)(expression)).Body).Member.Name;
        }

        #endregion Methods
    }
}