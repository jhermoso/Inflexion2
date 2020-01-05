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
    using System.ComponentModel;
    using System.Linq.Expressions;

    /// <summary>
    /// Clase pública que representa la Vista Modelo Base de la cuál tiran el
    /// resto de ViewModels.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public abstract class ValueObjCrudViewModel<TDto> : WorkspaceViewModel, IEditableObject
        where TDto : BaseValueObjectDataTransferObject

    {
        #region IEditableObject implementation
        /// <summary>
        /// field for implementation of IEditableObject in the actual View model.
        /// his function is to backup the content of current viewmodel dto
        /// </summary>
        protected internal TDto backupEntity;

        /// <summary>
        /// field for implementation of IEditableObject in the actual View model
        /// his function is to avoid calls when a transsaction is started
        /// </summary>
        protected internal bool inTxn = false;
        #endregion


        private TDto ValueObject;

         #region Constructors

        /// <summary>
        /// .en parameter less constructor 
        /// </summary>
        public ValueObjCrudViewModel()
        {
            if (!this.IsDesignTime)
            {
                this.ObjectElement = Activator.CreateInstance<TDto>();
            }
        }

        /// <summary>
        /// .en Typed parameter constructor. 
        /// </summary>
        /// <param name="valueObj"> domain entity to manage with this constructor</param>
        public ValueObjCrudViewModel(TDto valueObj)
        {
            if (!this.IsDesignTime)
            {
                this.ObjectElement = valueObj;
            }
        }

        #endregion

        #region PROPERTIES

        ///// <summary>
        ///// Propiedad pública encargada de obtener y establecer si
        ///// la entidad esta Activa o no
        ///// </summary>
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

            cmd = this.newRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommand<object>;
            cmd.RaiseCanExecuteChanged();

            cmd = this.deleteRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommandBase;
            cmd.RaiseCanExecuteChanged();

            cmd = this.saveRecordCommand as Microsoft.Practices.Prism.Commands.DelegateCommandBase;
            cmd.RaiseCanExecuteChanged();

        }

        /// <summary>
        /// .en self reference to the own entity dto to manage with the viemodel derived from this class.
        /// </summary>
        public TDto ObjectElement
        {
            get
            {
                return this.ValueObject;
            }
            set
            {
                this.ValueObject = value;
                RaisePropertyChanged(() => this.ObjectElement);
            }
        }

        /// <summary>
        /// .en store for the title of the derived vm. this property is binded in the view.
        /// </summary>
        public override string Title
        {
            get; set;
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
            var result = this.ObjectElement != null && this.Validation.ValidateAll().IsValid; // para entidades que no se borran && this.Activo;
            return result;
        
        }

        /// <summary>
        /// method to calculate if is possible to delete the current entity.
        /// </summary>
        /// <param name="parameter">.en addtional info to pass to the method</param>
        /// <returns></returns>
        public override bool CanDeleteRecord(object parameter)
        {
            return this.ValueObject != null;
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

        ///// <summary>
        ///// .en method to calculate if is possible to add a new record at this time.
        ///// usually this method has to be overrided in the derived viemodel.
        ///// </summary>
        ///// <param name="parameter">.en Addtional info to pass to the method.</param>
        ///// <returns></returns>
        //public override bool CanNewRecord(object parameter)
        //{
        //    return true;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>.en Addtional info to pass to the method.</returns>
        public override bool CanActivateRecord(object parameter)
        {
            return false;
        }


        //TODO: overrrides for using this actions with detail views and not only with query views

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public override void OnGetFirstPageRecords(object parameter)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanGetFirstPageRecords(object parameter)
        {
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanGetNextPageRecords(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanGetPreviousPageRecords(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanGetLastPageRecords(object parameter)
        {
            return true;
        }

        #endregion

        /// <summary>
        /// General method.
        /// </summary>
        /// <param name="parameter">.en Addtional info to pass to the method.</param>
        public override void OnNewRecord(object parameter)
        {
            this.ObjectElement = Activator.CreateInstance<TDto>();
            this.Rebind();
        }

        /// <summary>
        /// .en Navigate method to go to view a record with his id.
        /// </summary>
        /// <param name="navigationContext">.en Id of the record to go to.</param>
        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {

        }

        #region IEditableObject implementation

        /// <summary>
        /// 
        /// </summary>
        public virtual void BeginEdit()
        {
            if (!this.inTxn)
            {
                this.inTxn = true;
                if (this.backupEntity == null)
                    this.backupEntity = (TDto)this.ObjectElement.Clone();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void EndEdit()
        {
            if (this.inTxn)
            {
                this.backupEntity = null;
                this.inTxn = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void CancelEdit()
        {
            if (this.inTxn)
            {
                Initialization(this.ObjectElement);
                this.backupEntity = null;
                this.inTxn = false;
            }
        }

        /// <summary>
        /// Intialize the View model from a Dto.
        /// This method has to be overrided in the derived class
        /// </summary>
        /// <param name="objectElement"></param>
        public virtual void Initialization(TDto objectElement)
        {
            throw new NotImplementedException();
        }

        #endregion

    } // ValueObjCrudViewModel

} // Inflexion2.UX.WPF.MVVM.CRUD