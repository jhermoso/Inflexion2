// -----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.MVVM.CRUD
{
    using Converters;
    using Inflexion2.Application;
    using Inflexion2.UX.WPF.MVVM.ViewModels;
    using System;
    using System.Linq.Expressions;

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

        /// <summary>
        /// .en parameter less constructor 
        /// </summary>
        public CrudViewModel()
        {
            if (!this.IsDesignTime)
            {
                this.ObjectElement = Activator.CreateInstance<T>();
            }
        }

        /// <summary>
        /// .en Typed parameter constructor. 
        /// </summary>
        /// <param name="element"> domain entity to manage with this constructor</param>
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

        ///// <summary>
        ///// Propiedad pública encargada de obtener y establecer si
        ///// la entidad esta Activa o no
        ///// </summary>
        ///// <remarks>
        ///// Sin comentarios adicionales.
        ///// </remarks>
        ///// <value>
        ///// Indica el campo Activo de la entidad.
        ///// </value>
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

        #pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        /// <summary>
        /// TODO: update summary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpresssion"></param>
        protected override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpresssion)
        #pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
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

        /// <summary>
        /// .en self reference to the own entity to manage with the viemodel derived from this class.
        /// </summary>
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

        /// <summary>
        /// .en strore for the title of the derived vm. this property is binded in the view.
        /// </summary>
        public override string Title
        {
            get { return string.Empty; }
        }

        #endregion

        #region can methods for commands
        /// <summary>
        /// .en overridible can method for common command on ribbon to ask is is it possible to save the current record
        /// </summary>
        /// <param name="parameter">.en addtional info to pass to the method</param>
        /// <returns></returns>
        public override bool CanSaveRecord(object parameter)
        {
            return this.ObjectElement != null && Validation.ValidateAll().IsValid;// para entidades que no se borran && this.Activo;
        }

        /// <summary>
        /// method to calculate if is possible to delete the current entity.
        /// </summary>
        /// <param name="parameter">.en addtional info to pass to the method</param>
        /// <returns></returns>
        public override bool CanDeleteRecord(object parameter)
        {
            return this.entity != null && !this.entity.IsTransient();
        }

        /// <summary>
        /// .en addtional info to pass to the method
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanGetRecords(object parameter)
        {
            return false;
        }

        /// <summary>
        /// .en method to calculate if is possible to add a new record ata thi time.
        /// ususally this method has to be overrided in the derived viemodel.
        /// </summary>
        /// <param name="parameter">.en Addtional info to pass to the method.</param>
        /// <returns></returns>
        public override bool CanNewRecord(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>.en Addtional info to pass to the method.</returns>
        public override bool CanActivateRecord(object parameter)
        {
            return false;
        }
        #endregion

        /// <summary>
        /// .en General method to get a record by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(TIdentifier id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// General method.
        /// </summary>
        /// <param name="parameter">.en Addtional info to pass to the method.</param>
        public override void OnNewRecord(object parameter)
        {
            this.ObjectElement = Activator.CreateInstance<T>();
            this.Rebind();
        }

        /// <summary>
        /// .en Navigate method to go to view a record with his id.
        /// </summary>
        /// <param name="navigationContext">.en Id of the record to go to.</param>
        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            string id = navigationContext.Parameters["Id"];
            if (string.IsNullOrWhiteSpace(id) || id == default(TIdentifier).ToString())
            {
                return;
            }

            TIdentifier tid = GenericConverters.ChangeType<TIdentifier>(id);
            this.ObjectElement = GetById(tid);

            this.Rebind();
        }

    } // CrudViewModel

} // Inflexion2.UX.WPF.MVVM.CRUD