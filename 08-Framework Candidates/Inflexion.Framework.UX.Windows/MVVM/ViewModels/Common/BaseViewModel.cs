// -----------------------------------------------------------------------
// <copyright file="ObservableObject.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Windows;
    using Microsoft.Practices.ServiceLocation;
    using MvvmValidation;

    using Inflexion.Framework.UX.Windows.Services;
    using System.Collections.Generic;

    /// <summary>
    /// Clase base para cualquier tipo que deba proporcionar notificaciones de cambio de propiedad.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged, INotifyPropertyChanging, IDataErrorInfo
    {
        private readonly IDictionary<string, PropertyChangedEventArgs> propertyChangedArgsCache = new Dictionary<string, PropertyChangedEventArgs>();
        private readonly IDictionary<string, PropertyChangingEventArgs> propertyChangingArgsCache = new Dictionary<string, PropertyChangingEventArgs>();

        #region Constructors

        public BaseViewModel()
        {
            Validation = new ValidationHelper();
            SetupValidation(this.Validation);
            DataErrorInfoValidationAdapter = new DataErrorInfoAdapter(Validation);
        }

        #endregion

        #region Events

        /// <summary>
        /// Se produce después de que una propiedad cambia de valor.
        /// </summary>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:System.ComponentModel.INotifyPropertyChanged"/>.
        /// </remarks>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Se produce antes de que una propiedad cambia de valor.
        /// </summary>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:System.ComponentModel.INotifyPropertyChanging"/>.
        /// </remarks>
        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene un valor que indica si la vista es una vista en tiempo de diseño.
        /// </summary>
        /// <value>
        /// Es true si la vista es una vista en tiempo de diseño; en caso contrario, false.
        /// </value>
        protected bool IsDesignTime
        {
            get
            {
                return (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(
                    typeof(DependencyObject)).DefaultValue;
            }
        }

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <returns>The error message for the property. The default is an empty string ("").</returns>
        public string this[string columnName]
        {
            get { return DataErrorInfoValidationAdapter[columnName]; }
        }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error
        {
            get
            {
                //CommandManager.InvalidateRequerySuggested();
                return DataErrorInfoValidationAdapter.Error;
            }
        }

        /// <summary>
        /// Gets or sets the validation helper.
        /// </summary>
        /// <value>
        /// The validation helper.
        /// </value>
        public ValidationHelper Validation { get; set; }

        /// <summary>
        /// Gets or sets the data error info validation adapter.
        /// </summary>
        /// <value>
        /// The data error info validation adapter.
        /// </value>
        private DataErrorInfoAdapter DataErrorInfoValidationAdapter { get; set; }

        /// <summary>
        /// Proporciona acceso al controlador de eventos <see cref="M:PropertyChanged"/> para las clases derivadas.
        /// </summary>
        /// <value>
        /// La referencia al controlador de eventos <see cref="M:PropertyChanged"/>.
        /// </value>
        protected PropertyChangedEventHandler PropertyChangedHandler
        {
            get
            {
                return this.PropertyChanged;
            }
        }

        /// <summary>
        /// Proporciona acceso al controlador de eventos <see cref="M:PropertyChanging"/> para las clases derivadas.
        /// </summary>
        /// <value>
        /// La referencia al controlador de eventos <see cref="M:PropertyChanging"/>.
        /// </value>
        protected PropertyChangingEventHandler PropertyChangingHandler
        {
            get
            {
                return this.PropertyChanging;
            }
        }

        protected IMessageBoxService MessageBoxService
        {
            get 
            {
                return ServiceLocator.Current.GetInstance<IMessageBoxService>();
            }
        }

        #endregion

        #region Protected Methods

        protected void Rebind()
        {
            this.RaisePropertyChanged(string.Empty);
        }

        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpresssion)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpresssion);
            this.RaisePropertyChanged(propertyName);
        }

        protected virtual void RaisePropertyChanging<T>(Expression<Func<T>> propertyExpresssion)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpresssion);
            this.RaisePropertyChanging(propertyName);
        }

        /// <summary>
        /// Setups the validation.
        /// </summary>
        /// <param name="validation">The validation.</param>
        protected virtual void SetupValidation(ValidationHelper validation)
        {

        }

        #endregion

        /// <summary>
        /// Provoca el evento <see cref="M:PropertyChanged"/> si es necesario.
        /// </summary>
        /// <param name="propertyName">
        /// El nombre de la propiedad modificada.
        /// </param>
        /// <remarks>
        /// Si el parámetro <paramref name="propertyName"/> no se corresponde
        /// con una propiedad existente en la clase actual, se produce una excepción
        /// en la configuración de depuración.
        /// </remarks>
        private void RaisePropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            this.Validation.Validate(propertyName);

            var handler = this.PropertyChanged;
            if (handler != null)
            {
                if (!this.propertyChangedArgsCache.ContainsKey(propertyName))
                {
                    this.propertyChangedArgsCache.Add(propertyName, new PropertyChangedEventArgs(propertyName));
                }

                handler(this, this.propertyChangedArgsCache[propertyName]);
            }
        }

        /// <summary>
        /// Provoca el evento <see cref="M:PropertyChanging"/> si es necesario.
        /// </summary>
        /// <param name="propertyName">
        /// El nombre de la propiedad que se va a modificar.
        /// </param>
        /// <remarks>
        /// Si el parámetro <paramref name="propertyName"/> no se corresponde
        /// con una propiedad existente en la clase actual, se produce una excepción
        /// en la configuración de depuración.
        /// </remarks>
        private void RaisePropertyChanging(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            var handler = this.PropertyChanging;
            if (handler != null)
            {
                if (!this.propertyChangingArgsCache.ContainsKey(propertyName))
                {
                    this.propertyChangingArgsCache.Add(propertyName, new PropertyChangingEventArgs(propertyName));
                }

                handler(this, this.propertyChangingArgsCache[propertyName]);
            }
        }

        /// <summary>
        /// Comprueba que un nombre determinado de propiedad existe en esta instancia.
        /// </summary>
        /// <param name="propertyName">
        /// El nombre de la propiedad que se va a comprobar.
        /// </param>
        /// <remarks>
        /// Este método solamente se aplica a la configuración de depuración.
        /// </remarks>
        [DebuggerStepThrough]
        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            var myType = this.GetType();

            if (!string.IsNullOrEmpty(propertyName)
                && myType.GetProperty(propertyName) == null)
            {
                var descriptor = this as ICustomTypeDescriptor;

                if (descriptor != null)
                {
                    if (descriptor.GetProperties()
                        .Cast<PropertyDescriptor>()
                        .Any(property => property.Name == propertyName))
                    {
                        return;
                    }
                }

                throw new ArgumentException("Property not found!", propertyName);
            }
        }

        #region Private Methods

        #endregion

    }
}
