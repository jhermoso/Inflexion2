
namespace Common
{

    using System;
    using System.ComponentModel;
    using System.Reflection;


    /// <summary>
    ///   Clase estática que define métodos extensores para la clase
    ///   <see cref="T:System.Enum"/>.
    /// </summary>
    /// <remarks>
    ///   Para utilizar los métodos extensores es necesario incluir el
    ///   espacio de nombres <see cref="N:Inflexion.Framework.Extensions"/>.
    /// </remarks>
    public static class EnumExtension
    {

        #region FUNCTIONS

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
        /// using Inflexion.Framework.Extensions;
        /// using global::Inflexion.Framework.Infrastructure.Security.Base.LoginProvider;
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
            else
            {
                /* Obtenemos el nombre asociado al valor especificado. */
                string result = global::System.Enum.GetName(enumType, value);
                /* Devolvemos el resultado. */
                return result;
            }
        } // GetName


        /// <summary>
        /// Devuelve la descripción asociada al valor enumerado
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
        } // GetDescription

        #endregion

    } // EnumExtension

} // Inflexion.Framework.Extensions
