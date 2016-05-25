// -----------------------------------------------------------------------
// <copyright file="AccessLevel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion.Framework.UX.Windows.Security
{

    /// <summary>
    /// Lsita enumerada que determina el nivel de seguridad.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public enum AccessLevel : int
    {
        /// <summary>
        /// Estado correspondiente a dato que no se muestra.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>1</c>.
        /// </value>
        Invisible = 1,

        /// <summary>
        /// Estado correspondiente a dato que se muestra pero no se 
        /// puede modificar.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>2</c>.
        /// </value>
        ReadOnly = 2,

        /// <summary>
        /// Estado correspondiente a dato no activo.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>3</c>.
        /// </value>
        Disabled = 3,

        /// <summary>
        /// Estado correspondiente a permiso no asignado.
        /// </summary>
        /// <value>
        /// El valor del enumerado es <c>4</c>.
        /// </value>
        Unassigned = 4

    } // AccessLevel

} // Inflexion.Framework.UX.Windows.Security