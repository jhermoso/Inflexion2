// -----------------------------------------------------------------------
// <copyright file="QueryMultipleColumns.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.Controls.Dialogs
{
    using System;

    /// <summary>
    /// Entidad que define una columna a mostrar en el diálogo QueryMultipleView.
    /// </summary>
    public class QueryColumn
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="QueryColumn"/>.
        /// </summary>
        public QueryColumn()
        {
            this.DataType = typeof(string);
            this.StringFormat = string.Empty;
        }

        /// <summary>
        /// Obtiene o establece el nombre de la columna.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del campo con el que se va a hacer binding.
        /// </summary>
        public string Binding { get; set; }

        /// <summary>
        /// Obtiene o establece el formato que se desea dar al valor.
        /// </summary>
        public string StringFormat { get; set; }

        /// <summary>
        /// Obtiene o establece el ancho de la columna.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de datos de la columna.
        /// </summary>
        public Type DataType { get; set; }
    }
}
