﻿// -----------------------------------------------------------------------
// <copyright file="CrudModeType.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion2.UX.WPF.MVVM.CRUD
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

} // Company.Product.Shared.SharedCore.UI.MVVM