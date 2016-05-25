// -----------------------------------------------------------------------
// <copyright file="CrudModeType.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion.Framework.UX.Windows.MVVM.CRUD
{

    /// <summary>
    /// Lista pública enumerada del tipo de acción CRUD a acometer.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public enum CrudModeType
    {

        /// <summary>
        /// Tipo de acción para agregar un nuevo registro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        Add,

        /// <summary>
        /// Tipo de acción para actualizar un nuevo registro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        Update,

        /// <summary>
        /// Tipo de acción para eliminar un nuevo registro.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        Delete,

        /// <summary>
        /// Tipo de acción para recoger registros.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        Fetch,

        /// <summary>
        /// Tipo de acción para deshabilitar todos los posibles comandos.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        AllDisabled

    } // CrudModeType

} // end namespace Inflexion.Framework.UX.Windows.MVVM