// -----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion2.UX.WPF.MVVM.CRUD
{

    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using System.Linq;
    using System.Linq.Expressions;
    using Inflexion2.UX.WPF.MVVM;
    using Inflexion2.UX.WPF.MVVM.ViewModels;
    using Inflexion2.Application.DataTransfer.Base;

    /// <summary>
    /// Clase pública que representa la Vista Modelo Base de la cuál tiran el
    /// resto de ViewModels.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public abstract class CrudViewModel<T,TIdentifier> : WorkspaceViewModel, IEntityViewModel<TIdentifier> 
        where T : BaseEntityDataTransferObject<TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {

        private T entity;

        #region Constructors

        public CrudViewModel()
        {
            if (!this.IsDesignTime)
            {
                this.ObjectElement = Activator.CreateInstance<T>();
            }
        }

        public CrudViewModel(T element)
        {
            if (!this.IsDesignTime)
            {
                this.ObjectElement = element;
            }
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Propiedad pública encargada de obtener y establecer el nombre 
        /// de la entidad.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Indica el campo Id de la entidad.
        /// </value>
        public virtual TIdentifier Id
        {
            get
            {
                if (this.IsDesignTime)
                {
                    return default(TIdentifier);
                }
                
                return this.ObjectElement.Id;
            }
            set
            {
                if ( this.ObjectElement.Id.Equals(value) )
                {
                    this.ObjectElement.Id = value;
                    RaisePropertyChanged(()=> this.Id);
                }
            }
        } // Id

        /// <summary>
        /// Propiedad pública encargada de obtener y establecer si
        /// la entidad esta Activa o no
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Indica el campo Activo de la entidad.
        /// </value>
        //public virtual bool Activo
        //{
        //    get
        //    {
        //        return this.ObjectElement.Activo;
        //    }
        //    set
        //    {
        //        if (this.ObjectElement.Activo != value)
        //        {
        //            this.ObjectElement.Activo = value;
        //            RaisePropertyChanged(() => this.Activo);
        //        }
        //    }
        //} // Activo

        protected override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpresssion)
        {
            base.RaisePropertyChanged(propertyExpresssion);

            var cmd = this.activateRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommandBase;
            cmd.RaiseCanExecuteChanged();

            cmd = this.editRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommandBase;
            cmd.RaiseCanExecuteChanged();

            cmd = this.deleteRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommandBase;
            cmd.RaiseCanExecuteChanged();

            cmd = this.saveRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommandBase;
            cmd.RaiseCanExecuteChanged();
        }

        public T ObjectElement
        {
            get
            {
                return this.entity;
            }
            set
            {
                this.entity = value;
                RaisePropertyChanged(() => this.ObjectElement);
            }
        }

        public override string Title
        {
            get { return string.Empty; }
        }

        #endregion

        public override bool CanSaveRecord(object parameter)
        {
            return this.ObjectElement != null && Validation.ValidateAll().IsValid;// para entidades que no se borran && this.Activo;
        }

        public override bool CanDeleteRecord(object parameter)
        {
            return false; // this.entity != null && !this.entity.IsTransient;
        }

        public override bool CanGetRecords(object parameter)
        {
            return false;
        }

        public override bool CanNewRecord(object parameter)
        {
            return true;
        }

        public override bool CanActivateRecord(object parameter)
        {
            return false;
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void OnNewRecord(object parameter)
        {
            this.ObjectElement = Activator.CreateInstance<T>();
            this.Rebind();
        }

        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            string id = navigationContext.Parameters["Id"];
            if (string.IsNullOrWhiteSpace(id) || id == "0")
            {
                return;
            }

            this.ObjectElement = GetById(int.Parse(id));

            this.Rebind();
        }

    } // CrudViewModel

} // Inflexion2.UX.WPF.MVVM.CRUD