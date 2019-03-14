// -----------------------------------------------------------------------
// <copyright file="EnumExtension.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.Domain.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Runtime.Serialization;

    /// <summary>
    ///   Clase estática que define métodos extensores para la clase
    ///   <see cref="T:System.Enum"/>.
    /// </summary>
    /// <remarks>
    ///   Para utilizar los métodos extensores es necesario incluir el
    ///   espacio de nombres <see cref="N:Inflexion2.Domain.Extensions"/>.
    /// </remarks>
    public static class EnumExtension
    {
        #region Methods

        /// <summary>
        /// Devuelve la descripción  asociada al valor enumerado
        /// <paramref name="value"/> especificado.
        /// </summary>
        /// <remarks>
        /// Esta función es un método extensor de la clase
        ///  <see cref="T:System.Enum"/>.
        /// </remarks>
        /// <typeparam name="TEnum">
        /// Tipo genérico restringido a enumerado (descendiente de
        /// <see cref="T:System.Enum"/>).
        /// </typeparam>
        /// <param name="structure">
        /// Enumerado sobre el que se aplica la extensión.
        /// </param>
        /// <param name="value">
        /// Valor del enumerado del que se desea obtener la descripción.
        /// </param>
        /// <returns>
        /// La descripción asociada al valor enumerado
        /// <paramref name="value"/> especificado.
        /// </returns>
        public static string GetDescription<TEnum>(this TEnum structure, Enum value)
        where TEnum : struct
        {
            // Obtenemos el tipo de la instancia.
            Type type = value.GetType();

            // Obtenemos los miembros públicos del enumerado.
            MemberInfo[] memInfo = type.GetMember(value.ToString());

            // Comprobamos los datos.
            if (memInfo != null && memInfo.Length > 0)
            {
                // Obtenemos los atributos.
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                // Comprobamos los datos.
                if (attrs != null && attrs.Length > 0)
                {
                    // Devolvemos la descripción almacenada en el atributo.
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            // Devolvemos el valor del enumerado.
            return value.ToString();
        }

        /// <summary>
        /// Función encargada de obtener el valor del atributo EnumMember.
        /// </summary>
        /// <remarks>
        /// Esta función es un método extensor de la clase
        ///  <see cref="T:System.Enum"/>.
        /// </remarks>
        /// <typeparam name="TEnum">
        /// Tipo genérico restringido a enumerado (descendiente de
        /// <see cref="T:System.Enum"/>).
        /// </typeparam>
        /// <param name="structure">
        /// Enumerado sobre el que se aplica la extensión.
        /// </param>
        /// <param name="value">
        /// Enumerado sobre el que se aplica la extensión.
        /// </param>
        /// <returns>
        /// Devuelve el valor del atributo EnumMember.
        /// </returns>
        public static string GetEnumMemberValue<TEnum>(this TEnum structure, Enum value)
        where TEnum : struct
        {
            // Obtenemos el tipo del enumerado.
            var enumType = typeof(TEnum);
            // Exigimos que efectivamente sea un tipo enumerado.
            if (!enumType.IsEnum)
            {
                throw new global::System.InvalidCastException();
            }

            // Obtenemos los atributos.
            EnumMemberAttribute[] attributes = value.GetType()
                                               .GetField(value.ToString())
                                               .GetCustomAttributes(typeof(EnumMemberAttribute), false) as EnumMemberAttribute[];
            // Devolvemos el resultaso.
            return attributes.Length > 0 ? attributes[0].Value : string.Empty;
        }

        /// <summary>
        /// Alternative implementation
        /// .es obtenemos el valor correspondiente al enumerado
        /// .en get the value of enum member
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumMemberValue(this Enum value)
        {
            var attributes
            = value.GetType().GetField(value.ToString())
              .GetCustomAttributes(typeof(EnumMemberAttribute), false)
              as EnumMemberAttribute[];

            return attributes.Length > 0 ? attributes[0].Value : string.Empty;
        }


        /// <summary>
        ///   Devuelve el identificador asociado al valor enumerado
        ///   <paramref name="value"/> especificado.
        /// </summary>
        /// <remarks>
        ///   Esta función es un método extensor de la clase
        ///   <see cref="T:System.Enum"/>.
        /// </remarks>
        /// <typeparam name="TEnum">
        ///   Tipo genérico restringido a enumerado (descendiente de
        ///   <see cref="T:System.Enum"/>).
        /// </typeparam>
        /// <param name="value">
        ///   Valor enumerado cuyo identificador se desea obtener.
        /// </param>
        /// <returns>
        ///   El identificador asociado al valor enumerado
        ///   <paramref name="value"/> especificado.
        /// </returns>
        /// <example>
        ///   Ejemplo de uso del método extensor:
        ///   <code>
        ///     <![CDATA[
        /// using Inflexion2.Domain.Extensions;
        /// using global::Inflexion2.Infrastructure.Security.LoginProvider;
        /// // ...
        /// string enumValueName = LoginProviderType.Database.GetName();
        ///     ]]>
        ///   </code>
        /// </example>
        public static string GetName<TEnum>(this TEnum value)
        where TEnum : struct
        {
            /* Obtenemos el tipo del enumerado. */
            var enumType = typeof(TEnum);
            /* Exigimos que efectivamente sea un tipo enumerado. */
            if (!enumType.IsEnum)
            {
                throw new global::System.InvalidCastException();
            }

            /* Obtenemos el nombre asociado al valor especificado. */
            string result = global::System.Enum.GetName(enumType, value);
            /* Devolvemos el resultado. */
            return result;
        }

        /// <summary>
        /// Método extensor para obtener el valor del enumerado a partir del valor del atributo EnumMember.
        /// </summary>
        /// <typeparam name="TEnum">
        /// Tipo genérico restringido a enumerado (descendiente de
        /// <see cref="T:System.Enum"/>).
        /// </typeparam>
        /// <param name="structure">
        /// Enumerado sobre el que se aplica la extensión.
        /// </param>
        /// <param name="value">
        /// Parámetro que indica el valor del atributo EnumMember.
        /// </param>
        /// <returns>
        /// Devuelve el valor de enumerado.
        /// </returns>
        public static TEnum GetNameFromEnumMemberValue<TEnum>(this TEnum structure, string value)
        where TEnum : struct
        {
            // Obtenemos el tipo del enumerado.
            var enumType = typeof(TEnum);
            // Exigimos que efectivamente sea un tipo enumerado.
            if (!enumType.IsEnum)
            {
                throw new global::System.InvalidCastException();
            }

            // Recorremos la lista de campos del enumerado.
            foreach (var item in enumType.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(item, typeof(EnumMemberAttribute)) as EnumMemberAttribute;
                if (attribute != null)
                {
                    if (attribute.Value == value || item.Name == value)
                    {
                        return (TEnum)item.GetValue(null);
                    }
                }
                else
                {
                    if (item.Name == value)
                    {
                        return (TEnum)item.GetValue(null);
                    }
                }
            }
            // Error, el valor del atributo EnumMember no se ha encontrado.
            throw new ArgumentException("EnumMember value not found");
        }

        /// <summary>
        /// Método extensor para obtener el valor del enumerado a partir de la descripción.
        /// </summary>
        /// <typeparam name="TEnum">
        /// Tipo genérico restringido a enumerado (descendiente de
        /// <see cref="T:System.Enum"/>).
        /// </typeparam>
        /// <param name="structure">
        /// Enumerado sobre el que se aplica la extensión.
        /// </param>
        /// <param name="description">
        /// Parámetro que indica la descripción del valor del enumerdo.
        /// </param>
        /// <returns>
        /// Devuelve el valor de enumerado.
        /// </returns>
        public static TEnum GetValueFromDescription<TEnum>(this TEnum structure, string description)
        where TEnum : struct
        {
            // Obtenemos el tipo del enumerado.
            var enumType = typeof(TEnum);
            // Exigimos que efectivamente sea un tipo enumerado.
            if (!enumType.IsEnum)
            {
                throw new global::System.InvalidCastException();
            }

            // Recorremos los campos del enumerado.
            foreach (var field in enumType.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                                typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == description)
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
            }
            // Error, la descripción proporcionada no se ha encontrado.
            throw new ArgumentException("Enum description not found");
        }

        #endregion Methods
    }
}