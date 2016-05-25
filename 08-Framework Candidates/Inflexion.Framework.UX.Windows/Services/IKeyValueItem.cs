// -----------------------------------------------------------------------
// <copyright file="IDropDownListDto.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IKeyValueItem
    {
        #region PROPERTIES

        /// <summary>
        /// Propiedad pública que permite establecer y obtener el 
        /// identificador del Dto.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener el 
        /// identificador del Dto.
        /// </value>
        string Id { get; set; }

        /// <summary>
        /// Propiedad pública que permite obtener o establecer el nombre 
        /// de la localidad.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el nombre 
        /// de la localidad.
        /// </value>
        string Nombre { get; set; }

        /// <summary>
        /// Propiedad pública que permite obtener o establecer
        /// si un registro está activo o no.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o 
        /// establecer si un registro está activo o no.
        /// </value>
        bool Activo { get; set; }

        /// <summary>
        /// Propiedad pública que permite obtener o establecer
        /// si un registro está seleccionado o no.
        /// </summary>
        /// <remarks>
        /// Sin comentarios especiales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o 
        /// establecer si un registro está seleccionado o no.
        /// </value>
        bool IsSelected { get; set; }

        #endregion

    } // IKeyValueItem

}