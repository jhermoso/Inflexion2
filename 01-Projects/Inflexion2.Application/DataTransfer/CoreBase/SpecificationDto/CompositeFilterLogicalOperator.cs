// ---------------------------------------------------------------------------------
// <copyright file="CompositeFilterLogicalOperator.cs" company="Inflexion Software">
//     Copyright (c) 2012. Inflexion Software. All Rights Reserved.
// </copyright>
// ---------------------------------------------------------------------------------
namespace Inflexion2.Application
{
    using System.Runtime.Serialization;

    #region Enumerations

    /// <summary>
    /// Lista enumerada para almacenar los operadores lógicos.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    [DataContract]
    public enum CompositeFilterLogicalOperator
    {
        /// <summary>
        /// Operador lógico AND.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        [EnumMember(Value="AND")]
        And,

        /// <summary>
        /// Operador lógico OR.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        [EnumMember(Value="OR")]
        Or
    }

    #endregion Enumerations
}