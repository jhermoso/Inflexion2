// -----------------------------------------------------------------------
// <copyright file="MaestraKeyValueItem.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.Services
{
    #region Imports

    using System;

    using Inflexion2.UX.WPF.MVVM;

    #endregion

    /// <summary>
    /// Representa la clase base para los elementos clave-valor.
    /// </summary>
    public class MaestraKeyValueItem : BaseViewModel, IKeyValueItem
    {
        #region Fields

        /// <summary>
        /// Valor que indica si el elemento está activo.
        /// </summary>
        private bool activo;

        /// <summary>
        /// Identificador del elemento.
        /// </summary>
        private string id;

        /// <summary>
        /// Valor que indica si el elemento está seleccionado.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Nombre del elemento.
        /// </summary>
        private string nombre;

        /// <summary>
        /// Código del elemento.
        /// </summary>
        private string codigo;

        /// <summary>
        /// Hora de inicio del elemento.
        /// </summary>
        private DateTime? horaInicio;

        /// <summary>
        /// Hora de fin del elemento.
        /// </summary>
        private DateTime? horaFin;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:BaseKeyValueItem" />.
        /// </summary>
        /// <param name="id">Identificador del elemento.</param>
        /// <param name="nombre">Nombre del elemento.</param>
        /// <param name="activo">Valor que indica si el elemento está activo.</param>
        /// <param name="codigo">El codigo del elemento.</param>
        /// <param name="horaInicio">La hora inicio del elemento.</param>
        /// <param name="horaFin">La hora fin del elemento.</param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:BaseKeyValueItem" />.
        /// </remarks>
        public MaestraKeyValueItem(
                                int id,
                                string nombre,
                                bool activo, 
                                string codigo,
                                DateTime? horaInicio,
                                DateTime? horaFin)
            : this(id, nombre, activo, false, codigo, horaInicio, horaFin)
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:BaseKeyValueItem" />.
        /// </summary>
        /// <param name="id">Identificador del elemento.</param>
        /// <param name="nombre">Nombre del elemento.</param>
        /// <param name="activo">Valor que indica si el elemento está activo.</param>
        /// <param name="isSelected">Valor que indica si el elemento está seleccionado.</param>
        /// <param name="codigo">El codigo del elemento.</param>
        /// <param name="horaInicio">La hora inicio del elemento.</param>
        /// <param name="horaFin">La hora fin del elemento.</param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:BaseKeyValueItem" />.
        /// </remarks>
        public MaestraKeyValueItem(
                                int id,
                                string nombre,
                                bool activo,
                                bool isSelected,
                                string codigo,
                                DateTime? horaInicio,
                                DateTime? horaFin)
        {
            this.Activo = activo;
            this.Id = id.ToString();
            this.IsSelected = isSelected;
            this.Nombre = nombre;
            this.Codigo = codigo;
            this.HoraInicio = horaInicio;
            this.HoraFin = horaFin;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene o establece un valor que indica si el elemento está activo.
        /// </summary>
        public bool Activo
        {
            get
            {
                return this.activo;
            }

            set
            {
                if (this.activo != value)
                {
                    this.activo = value;
                    this.RaisePropertyChanged(() => this.Activo);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el identificador del elemento.
        /// </summary>
        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (this.id != value)
                {
                    this.id = value;
                    this.RaisePropertyChanged(() => this.Id);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica si el elemento está seleccionado.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    this.RaisePropertyChanged(() => this.IsSelected);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre del elemento.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.Activo ? this.nombre : string.Format("(D) {0}", this.nombre);
            }

            set
            {
                if (this.nombre != value)
                {
                    this.nombre = value;
                    this.RaisePropertyChanged(() => this.Nombre);
                }
            }
        }

        /// <summary>
        /// Obtiene el identificador numérico del elemento.
        /// </summary>
        public int NumericId
        {
            get
            {
                int numericId;
                if (int.TryParse(this.Id, out numericId))
                {
                    return numericId;
                }

                throw new InvalidCastException("The identifier is not numeric!");
            }
        }

        /// <summary>
        /// Obtiene o establece la hora de fin del elemento.
        /// </summary>
        public DateTime? HoraFin
        {
            get 
            { 
                return this.horaFin; 
            }

            set 
            { 
                this.horaFin = value;
                this.RaisePropertyChanged(() => this.HoraFin);
            }
        }

        /// <summary>
        /// Obtiene o establece la hora de inicio del elemento.
        /// </summary>
        public DateTime? HoraInicio
        {
            get 
            { 
                return this.horaInicio; 
            }

            set 
            { 
                this.horaInicio = value;
                this.RaisePropertyChanged(() => this.HoraInicio);
            }
        }

        /// <summary>
        /// Obtiene o establece el código del elemento.
        /// </summary>
        public string Codigo
        {
            get 
            { 
                return this.codigo; 
            }

            set 
            { 
                this.codigo = value;
                this.RaisePropertyChanged(() => this.Codigo);
            }
        }
        

        #endregion

        #region Overridden Methods

        /// <summary>
        /// Devuelve un valor que indica cuando esta instancia es igual al objeto especificado.
        /// </summary>
        /// <param name="obj">
        /// El objeto que se va a comparar con esta instancia.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si es igual; en caso contrario, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return (obj is MaestraKeyValueItem) && (this.Id == ((MaestraKeyValueItem)obj).Id);
        }

        /// <summary>
        /// Devuelve el código hash de esta instancia.
        /// </summary>
        /// <returns>
        /// El código hash de esta instancia.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Obtiene la representación de cadena de la instancia actual.
        /// </summary>
        /// <returns>
        /// La representación de cadena de la instancia actual.
        /// </returns>
        public override string ToString()
        {
            return string.Format(
                                 "({0}) : Id = \"{1}\" | Nombre = \"{2}\" | Activo = {3} | Codigo = \"{4}\" | HoraInicio = \"{5}\" | HoraFin = \"{6}\"",
                                 typeof(MaestraKeyValueItem).Name,
                                 this.Id,
                                 this.Nombre,
                                 this.Activo ? "Sí" : "No",
                                 this.Codigo,
                                 this.HoraInicio,
                                 this.HoraFin);
        }

        #endregion
    }
}