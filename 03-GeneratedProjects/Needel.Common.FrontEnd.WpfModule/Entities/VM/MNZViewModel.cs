﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="MNZ" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " WpfEntityViewModelCT.tt" with "public class WpfEntityViewModelCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "WpfEntityViewModelCT.tt" con "public class WpfEntityViewModelCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.FrontEnd.WpfModule
{

    #region usings   
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.ServiceModel;
    using System.Windows;
    using System.Windows.Input;

    using MvvmValidation;
    using Needel.Common.Domain.Data;
    using Needel.Common.Application;
    using Needel.Common.Application.Dtos;
    using Needel.Common.Infrastructure.Resources;
    using Needel.Common.Application.WcfClient.MNZReference;
    using Needel.Common.Application.WcfClient.EntityMReference; //property parent
    using Needel.Common.Application.WcfClient.EntityNReference; //property parent
    using Needel.Common.Application.WcfClient.EntityZReference; //property parent

    using Inflexion2.Domain.Data;
    using Inflexion2.Application;
    using Inflexion2.Resources;
    using Inflexion2.UX.WPF.MVVM;
    using Inflexion2.UX.WPF.MVVM.Commands;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    #endregion

    /// <summary>
    /// .en Interaction logic for MNZViewModel.xaml
    /// .es Logica de interación para la vista MNZViewModel.xaml
    /// </summary>
    public partial class MNZViewModel : Inflexion2.UX.WPF.MVVM.CRUD.ValueObjCrudViewModel<MNZDto>, Inflexion2.UX.WPF.MVVM.CRUD.IValueObjViewModel, IEditableObject
    {
        #region Fields

        /// <summary>
        /// Campo para indicar que el viewmodel esta embevido en un viewmodel parental con el objeto de 
        /// de asegurar que se añade al menos un registro en esta entidad cuando se crea el padre de esta.
        /// </summary>
        bool from1VM;

        private EntityMQueryViewModel allEntityMQueryVM;//*From sources no es reflexiva no es Many 2 Many
        private ObservableCollection<EntityMDto> m_EntitiesCombo;//**# no es reflexiva no es Many 2 Many
        private EntityMQueryViewModel allM_EntitiesQueryVM;//**#
        bool entityMVisible = false;//**#
        private bool entityMComboVisible = false;//**#
        private EntityNQueryViewModel allEntityNQueryVM;//*From sources no es reflexiva no es Many 2 Many
        private ObservableCollection<EntityNDto> entitiesNCombo;//**# no es reflexiva no es Many 2 Many
        private EntityNQueryViewModel allEntitiesNQueryVM;//**#
        bool entityNVisible = false;//**#
        private bool entityNComboVisible = false;//**#
        private EntityZQueryViewModel allEntityZQueryVM;//*From sources no es reflexiva no es Many 2 Many
        private ObservableCollection<EntityZDto> entitiesZCombo;//**# no es reflexiva no es Many 2 Many
        private EntityZQueryViewModel allEntitiesZQueryVM;//**#
        bool entityZVisible = false;//**#
        private bool entityZComboVisible = false;//**#
        #endregion

        #region Constructors
        /// <summary>
        /// .en Parameterless constructor to implement the "IEditable" interface in query viewmodels that allow "editable row"
        /// </summary>
        public MNZViewModel() : this(true)
        {
        }

        /// <summary>
        /// .en Initialize a new instace for the class <see cref="T:MNZViewModel"/>.
        /// .es Inicializa una nueva instancia de la clase <see cref="T:MNZViewModel"/>.
        /// </summary>
        public MNZViewModel(bool from1VM = false) : base()
        {
            this.from1VM = from1VM;
            Initialization();
        } // MNZViewModel Constructor

        public override void Initialization(MNZDto element = null)
        {
            // .en https://github.com/SeriousM/WPFLocalizationExtension/issues/87#issuecomment-174510689
            // bind the property title of the VM to a dependecy property for the view. To allow the localization of the property tittle.
            // becouse this property don´t belong the class MNZControl what is the base for the view
            // but avalon dock uses this property to set the title of the dockable elements
            // if we wont tha this can be updated when the selected culture is changed we need this work arround.
            var targetProperty = this.GetType().GetProperty(nameof(MNZQueryViewModel.Title));
            var locBinding = new WPFLocalizeExtension.Extensions.LocTextExtension("MNZAlias");
            locBinding.SetBinding(this, targetProperty);
            this.CurrentViewName = "MNZView";
            // .en after to bind the property with the depdendecy property watch if theres is a change of the 
            // the culture to raise an event to warning that the title property has changed
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Culture")
                {
                    this.RaisePropertyChanged(() => Title);
                }
            };

            if ((this.ObjectElement != null && element != null && !this.ObjectElement.Equals(element)) || (this.ObjectElement == null && element != null))
            {
                this.ObjectElement = element;
            }

        } // MNZViewModel initialization

        /// <summary>
        /// .es Inicializa una nueva instancia de la clase <see cref="T:UserViewModel"/>.
        /// Este constructor se invoca desde el QueryViewModel ya que para cada 
        /// linea que se visualiza en la lista de Usuarios se crea el Viewmodel de dicho usuario.
        /// Esta lista se almacena en una observable collection en el query view model con la que se hace el binding 
        /// de la pantalla query.
        /// Por esta razon las entidades relacionadas no se cargan si no se navega hasta esta entidad.
        /// </summary>
        /// <param name="element">
        /// Parámetro de tipo <see cref="MNZDto"/> que contiene la información necesaria.
        /// </param>
        public MNZViewModel(MNZDto element, bool simpleViewModel = true)
            :  base(element)
        {
            if (!simpleViewModel)
            {
                Initialization(element);
            }
        } // MNZViewModel Parametrized Constructor

        #endregion

        #region Properties


        #endregion

        #region Properties from Parents

        // .en wrappers to help the managment of parent entities and their collections

        /// <summary>
        /// Campo para indicar que el viewmodel esta embebido en un viewmodel parental con el objeto de 
        /// de asegurar que se añade al menos un registro en esta entidad cuando se crea el padre de esta.
        /// </summary>
        public bool From1VM
        {
            get
            {
                return from1VM;
            }
        }

    #region UI controls visibility to manage parent properties in the view 
    public Visibility EntityMVisibility            { get { return  entityMVisible      ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility EntityMComboBoxVisibility    { get { return  entityMComboVisible ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility EntityMTextBoxVisibility     { get { return !entityMComboVisible ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility EntityNVisibility            { get { return  entityNVisible      ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility EntityNComboBoxVisibility    { get { return  entityNComboVisible ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility EntityNTextBoxVisibility     { get { return !entityNComboVisible ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility EntityZVisibility            { get { return  entityZVisible      ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility EntityZComboBoxVisibility    { get { return  entityZComboVisible ? Visibility.Visible : Visibility.Collapsed; } }
    public Visibility EntityZTextBoxVisibility     { get { return !entityZComboVisible ? Visibility.Visible : Visibility.Collapsed; } }
    #endregion


        /// <summary>
        /// Wraper property to help binding  
        /// </summary>
        public EntityMDto EntityM
        {
            get
            {
                return this.ObjectElement.EntityM;
            }
            set
            {
                if (this.ObjectElement.EntityM != value)
                {
                    if (value == null || value.IsTransient())
                    {
                        this.ObjectElement.EntityM = null;
                    }
                    else
                    {
                        this.ObjectElement.EntityM = value;
                        this.ObjectElement.EntityM_Id = this.ObjectElement.EntityM.Id;
                    }

                    this.RaisePropertyChanged(() => this.EntityM);
                }
            }
        } // EntityM

        /// <summary>
        /// .en Collection where to chose one parent from combobox for collections smaller than 50
        /// </summary>
        public ObservableCollection<EntityMDto> M_EntitiesCombo
        {
            get
            {
                return this.m_EntitiesCombo;
            }
            set
            {
                if (this.m_EntitiesCombo != value)
                {
                    this.m_EntitiesCombo = value;
                }
            }
        }
        /// <summary>
        /// .en Collection where to chose one parent from datagrid for collections greater than 50
        /// </summary>
        public EntityMQueryViewModel AllM_EntitiesQueryVM
        {
            get
            {
                return allM_EntitiesQueryVM;
            }
            set
            {
                if (this.allM_EntitiesQueryVM != value)
                {
                    this.allM_EntitiesQueryVM = value;
                    this.allM_EntitiesQueryVM.ParentViewName = this.CurrentViewName;
                    this.allM_EntitiesQueryVM.Title = "EntityMQueryViewModel";
                    this.RaisePropertyChanged(() => this.AllM_EntitiesQueryVM);
                }
            }
        }

        /// <summary>
        /// Wraper property to help binding  
        /// </summary>
        public EntityNDto EntityN
        {
            get
            {
                return this.ObjectElement.EntityN;
            }
            set
            {
                if (this.ObjectElement.EntityN != value)
                {
                    if (value == null || value.IsTransient())
                    {
                        this.ObjectElement.EntityN = null;
                    }
                    else
                    {
                        this.ObjectElement.EntityN = value;
                        this.ObjectElement.EntityN_Id = this.ObjectElement.EntityN.Id;
                    }

                    this.RaisePropertyChanged(() => this.EntityN);
                }
            }
        } // EntityN

        /// <summary>
        /// .en Collection where to chose one parent from combobox for collections smaller than 50
        /// </summary>
        public ObservableCollection<EntityNDto> EntitiesNCombo
        {
            get
            {
                return this.entitiesNCombo;
            }
            set
            {
                if (this.entitiesNCombo != value)
                {
                    this.entitiesNCombo = value;
                }
            }
        }
        /// <summary>
        /// .en Collection where to chose one parent from datagrid for collections greater than 50
        /// </summary>
        public EntityNQueryViewModel AllEntitiesNQueryVM
        {
            get
            {
                return allEntitiesNQueryVM;
            }
            set
            {
                if (this.allEntitiesNQueryVM != value)
                {
                    this.allEntitiesNQueryVM = value;
                    this.allEntitiesNQueryVM.ParentViewName = this.CurrentViewName;
                    this.allEntitiesNQueryVM.Title = "EntityNQueryViewModel";
                    this.RaisePropertyChanged(() => this.AllEntitiesNQueryVM);
                }
            }
        }

        /// <summary>
        /// Wraper property to help binding  
        /// </summary>
        public EntityZDto EntityZ
        {
            get
            {
                return this.ObjectElement.EntityZ;
            }
            set
            {
                if (this.ObjectElement.EntityZ != value)
                {
                    if (value == null || value.IsTransient())
                    {
                        this.ObjectElement.EntityZ = null;
                    }
                    else
                    {
                        this.ObjectElement.EntityZ = value;
                        this.ObjectElement.EntityZ_Id = this.ObjectElement.EntityZ.Id;
                    }

                    this.RaisePropertyChanged(() => this.EntityZ);
                }
            }
        } // EntityZ

        /// <summary>
        /// .en Collection where to chose one parent from combobox for collections smaller than 50
        /// </summary>
        public ObservableCollection<EntityZDto> EntitiesZCombo
        {
            get
            {
                return this.entitiesZCombo;
            }
            set
            {
                if (this.entitiesZCombo != value)
                {
                    this.entitiesZCombo = value;
                }
            }
        }
        /// <summary>
        /// .en Collection where to chose one parent from datagrid for collections greater than 50
        /// </summary>
        public EntityZQueryViewModel AllEntitiesZQueryVM
        {
            get
            {
                return allEntitiesZQueryVM;
            }
            set
            {
                if (this.allEntitiesZQueryVM != value)
                {
                    this.allEntitiesZQueryVM = value;
                    this.allEntitiesZQueryVM.ParentViewName = this.CurrentViewName;
                    this.allEntitiesZQueryVM.Title = "EntityZQueryViewModel";
                    this.RaisePropertyChanged(() => this.AllEntitiesZQueryVM);
                }
            }
        }

        #endregion

        #region Properties from Children
        /// <summary>
        /// collection for drag and drop
        /// </summary>
        public EntityMQueryViewModel AllEntityMQueryVM
        {
            get
            {
                return allEntityMQueryVM;
            }
            set
            {
                if (this.allEntityMQueryVM != value)
                {
                    this.allEntityMQueryVM = value;
                    this.allEntityMQueryVM.Title = "AllEntityM"; //mark the viewmodel to facilitate the drag&drop
                    this.allEntityMQueryVM.ParentViewName = this.CurrentViewName;
                    // todo: add a reference to parentviewmodel = this;
                    this.RaisePropertyChanged(() => this.AllEntityMQueryVM);
                }
            }
        } // EntityM
        /// <summary>
        /// collection for drag and drop
        /// </summary>
        public EntityNQueryViewModel AllEntityNQueryVM
        {
            get
            {
                return allEntityNQueryVM;
            }
            set
            {
                if (this.allEntityNQueryVM != value)
                {
                    this.allEntityNQueryVM = value;
                    this.allEntityNQueryVM.Title = "AllEntityN"; //mark the viewmodel to facilitate the drag&drop
                    this.allEntityNQueryVM.ParentViewName = this.CurrentViewName;
                    // todo: add a reference to parentviewmodel = this;
                    this.RaisePropertyChanged(() => this.AllEntityNQueryVM);
                }
            }
        } // EntityN
        /// <summary>
        /// collection for drag and drop
        /// </summary>
        public EntityZQueryViewModel AllEntityZQueryVM
        {
            get
            {
                return allEntityZQueryVM;
            }
            set
            {
                if (this.allEntityZQueryVM != value)
                {
                    this.allEntityZQueryVM = value;
                    this.allEntityZQueryVM.Title = "AllEntityZ"; //mark the viewmodel to facilitate the drag&drop
                    this.allEntityZQueryVM.ParentViewName = this.CurrentViewName;
                    // todo: add a reference to parentviewmodel = this;
                    this.RaisePropertyChanged(() => this.AllEntityZQueryVM);
                }
            }
        } // EntityZ
        #endregion

        #region Methods

        /// <summary>.es Crear o actualizar una entidad de tipo MNZ.</summary>
        /// <param name="parameter">data to update.</param>
        public override void OnSaveRecord(object parameter)
        {
            if (this.IsActive && this.ObjectElement != null)
            {
                MNZServiceClient serviceClient = new MNZServiceClient();
                if (this.Validation.ValidateAll().IsValid)
                {
                    serviceClient.Create(this.ObjectElement);
                    this.MessageBoxService.Show(FrameworkResource.AddedSuccessfullyEntity);
                }

                UpdateParentView();
            }
        }

        /// <summary>.en Create a new MNZ</summary>
        /// <param name="parameter">.en Data to create the new MNZ</param>
        public override void OnNewRecord(object parameter)
        {
            var views = this.RegionManager.Regions[Inflexion2.UX.WPF.MVVM.RegionNames.WorkspaceRegion].ActiveViews;
            base.OnNewRecord(parameter);
            this.Initialization();
        }

        #endregion

        #region Protected Methods
        // .en implement here the loading of related entities or value objects.
        // .es implementar aqui los metodos de carga  de entidades u objetos valor relacionadas al root aggregate.

        private void PopulateM_Entities(Int32 filterId, EnumPopulationType populationMethod = EnumPopulationType.All)
        {
            EntityMServiceClient serviceClient = new EntityMServiceClient();
            entityMVisible = true;

            if (this.M_EntitiesCombo != null && this.M_EntitiesCombo.Count() > 0)
            {
                this.M_EntitiesCombo.Clear();
            }

            if (filterId.Equals(default(Int32)) && populationMethod.HasFlag(EnumPopulationType.All))
            {
                this.M_EntitiesCombo = serviceClient.GetAll();
            }
            else if (populationMethod.HasFlag(EnumPopulationType.AllExceptOwnId))
            {
                this.M_EntitiesCombo = serviceClient.GetAllExceptThis(filterId); // Get All except the own Id to avoid a self reference object
            }
            else if (populationMethod.HasFlag(EnumPopulationType.OnlyId))
            {
                if (this.EntityM != null && this.EntityM.Id == filterId)
                {
                    this.m_EntitiesCombo = new ObservableCollection<EntityMDto>() { this.EntityM };
                }
                else
                {
                    this.EntityM = serviceClient.GetById(filterId);
                    this.M_EntitiesCombo = new ObservableCollection<EntityMDto>() { this.EntityM };
                }

                entityMVisible = !this.from1VM;
            }

            if (this.M_EntitiesCombo != null && populationMethod.HasFlag(EnumPopulationType.AddNullOrNoneOption))
            {
                this.M_EntitiesCombo.Insert(0, this.EntityM != null && !this.EntityM.IsTransient() ? this.EntityM : new EntityMDto());
            }

            if (populationMethod.HasFlag(EnumPopulationType.OnlyId))
                this.allM_EntitiesQueryVM = new EntityMQueryViewModel(typeof(MNZView).FullName);
            else
                this.allM_EntitiesQueryVM = new EntityMQueryViewModel(this.M_EntitiesCombo, typeof(MNZView).FullName);

            entityMComboVisible = this.M_EntitiesCombo.Count() <= 50;
        }


        private void PopulateEntitiesN(Int32 filterId, EnumPopulationType populationMethod = EnumPopulationType.All)
        {
            EntityNServiceClient serviceClient = new EntityNServiceClient();
            entityNVisible = true;

            if (this.EntitiesNCombo != null && this.EntitiesNCombo.Count() > 0)
            {
                this.EntitiesNCombo.Clear();
            }

            if (filterId.Equals(default(Int32)) && populationMethod.HasFlag(EnumPopulationType.All))
            {
                this.EntitiesNCombo = serviceClient.GetAll();
            }
            else if (populationMethod.HasFlag(EnumPopulationType.AllExceptOwnId))
            {
                this.EntitiesNCombo = serviceClient.GetAllExceptThis(filterId); // Get All except the own Id to avoid a self reference object
            }
            else if (populationMethod.HasFlag(EnumPopulationType.OnlyId))
            {
                if (this.EntityN != null && this.EntityN.Id == filterId)
                {
                    this.entitiesNCombo = new ObservableCollection<EntityNDto>() { this.EntityN };
                }
                else
                {
                    this.EntityN = serviceClient.GetById(filterId);
                    this.EntitiesNCombo = new ObservableCollection<EntityNDto>() { this.EntityN };
                }

                entityNVisible = !this.from1VM;
            }

            if (this.EntitiesNCombo != null && populationMethod.HasFlag(EnumPopulationType.AddNullOrNoneOption))
            {
                this.EntitiesNCombo.Insert(0, this.EntityN != null && !this.EntityN.IsTransient() ? this.EntityN : new EntityNDto());
            }

            if (populationMethod.HasFlag(EnumPopulationType.OnlyId))
                this.allEntitiesNQueryVM = new EntityNQueryViewModel(typeof(MNZView).FullName);
            else
                this.allEntitiesNQueryVM = new EntityNQueryViewModel(this.EntitiesNCombo, typeof(MNZView).FullName);

            entityNComboVisible = this.EntitiesNCombo.Count() <= 50;
        }


        private void PopulateEntitiesZ(Int32 filterId, EnumPopulationType populationMethod = EnumPopulationType.All)
        {
            EntityZServiceClient serviceClient = new EntityZServiceClient();
            entityZVisible = true;

            if (this.EntitiesZCombo != null && this.EntitiesZCombo.Count() > 0)
            {
                this.EntitiesZCombo.Clear();
            }

            if (filterId.Equals(default(Int32)) && populationMethod.HasFlag(EnumPopulationType.All))
            {
                this.EntitiesZCombo = serviceClient.GetAll();
            }
            else if (populationMethod.HasFlag(EnumPopulationType.AllExceptOwnId))
            {
                this.EntitiesZCombo = serviceClient.GetAllExceptThis(filterId); // Get All except the own Id to avoid a self reference object
            }
            else if (populationMethod.HasFlag(EnumPopulationType.OnlyId))
            {
                if (this.EntityZ != null && this.EntityZ.Id == filterId)
                {
                    this.entitiesZCombo = new ObservableCollection<EntityZDto>() { this.EntityZ };
                }
                else
                {
                    this.EntityZ = serviceClient.GetById(filterId);
                    this.EntitiesZCombo = new ObservableCollection<EntityZDto>() { this.EntityZ };
                }

                entityZVisible = !this.from1VM;
            }

            if (this.EntitiesZCombo != null && populationMethod.HasFlag(EnumPopulationType.AddNullOrNoneOption))
            {
                this.EntitiesZCombo.Insert(0, this.EntityZ != null && !this.EntityZ.IsTransient() ? this.EntityZ : new EntityZDto());
            }

            if (populationMethod.HasFlag(EnumPopulationType.OnlyId))
                this.allEntitiesZQueryVM = new EntityZQueryViewModel(typeof(MNZView).FullName);
            else
                this.allEntitiesZQueryVM = new EntityZQueryViewModel(this.EntitiesZCombo, typeof(MNZView).FullName);

            entityZComboVisible = this.EntitiesZCombo.Count() <= 50;
        }


        /// <summary>
        /// example to execute validation rules
        /// </summary>
        /// <param name="validation"></param>
        protected override void SetupValidation(MvvmValidation.ValidationHelper validation)
        {
            validation.AddRule(this, () => RuleResult.Assert(
                this.ObjectElement != null &&
                this.ObjectElement.EntityM_Id != default(Int32) &&
                this.ObjectElement.EntityN_Id != default(Int32) &&
                this.ObjectElement.EntityZ_Id != default(Int32) 
                , String.Format(FrameworkResource.IsRequired, "EntityM, EntityN &EntityZ")));
            //ejemplo de validacion
            //// Validación de hora de Inicio
            //validation.AddRule(
            //                   () => this.propiedad,
            //                   () => RuleResult.Assert(
            //                                           this.propiedad != null,
            //                                           "mensaje"));
        }

        /// <summary>
        /// .en Here is possible to override the actions to execute when there is a navigation request
        /// </summary>
        /// <remarks>
        ///  this logic applys when you came from the collection of users through double click
        ///  load parent entities and populate the related combobox with unique value
        /// .en Here is where to call to the methods to load the related entities (children and parents).
        /// .es aqui es donde se invoca a los métodos de carga de las entidades adicionales.
        /// </remarks>
        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            Int32 parentEntityMId = default(Int32);

            if (this.EntityM == null)//#
            {
                var parameter = navigationContext.Parameters["MNZ;EntityM_Id"];
                if (parameter != null)
                {
                    parentEntityMId = Int32.Parse(parameter.Split(';').Last());
                }
            }

            // populate the combobox
            if (((this.EntityM == null && parentEntityMId == default(Int32)) || (this.EntityM != null && this.EntityM.Id == default(Int32))) && parentEntityMId == default(Int32))
            {
                // with all values
                PopulateM_Entities(default(Int32), EnumPopulationType.All);
            }
            else
            {
                // only with the parent
                parentEntityMId = this.EntityM != null && this.EntityM.Id != default(Int32) ? this.EntityM.Id : parentEntityMId;
                PopulateM_Entities(parentEntityMId, EnumPopulationType.OnlyId ); // get only the parent
            }

            Int32 parentEntityNId = default(Int32);

            if (this.EntityN == null)//#
            {
                var parameter = navigationContext.Parameters["MNZ;EntityN_Id"];
                if (parameter != null)
                {
                    parentEntityNId = Int32.Parse(parameter.Split(';').Last());
                }
            }

            // populate the combobox
            if (((this.EntityN == null && parentEntityNId == default(Int32)) || (this.EntityN != null && this.EntityN.Id == default(Int32))) && parentEntityNId == default(Int32))
            {
                // with all values
                PopulateEntitiesN(default(Int32), EnumPopulationType.All);
            }
            else
            {
                // only with the parent
                parentEntityNId = this.EntityN != null && this.EntityN.Id != default(Int32) ? this.EntityN.Id : parentEntityNId;
                PopulateEntitiesN(parentEntityNId, EnumPopulationType.OnlyId ); // get only the parent
            }

            Int32 parentEntityZId = default(Int32);

            if (this.EntityZ == null)//#
            {
                var parameter = navigationContext.Parameters["MNZ;EntityZ_Id"];
                if (parameter != null)
                {
                    parentEntityZId = Int32.Parse(parameter.Split(';').Last());
                }
            }

            // populate the combobox
            if (((this.EntityZ == null && parentEntityZId == default(Int32)) || (this.EntityZ != null && this.EntityZ.Id == default(Int32))) && parentEntityZId == default(Int32))
            {
                // with all values
                PopulateEntitiesZ(default(Int32), EnumPopulationType.All);
            }
            else
            {
                // only with the parent
                parentEntityZId = this.EntityZ != null && this.EntityZ.Id != default(Int32) ? this.EntityZ.Id : parentEntityZId;
                PopulateEntitiesZ(parentEntityZId, EnumPopulationType.OnlyId ); // get only the parent
            }

            this.Rebind();
        }


        /// <summary>
        /// override of Generic BeginEdit to avoid the edition in the blank line of query viewmodel with double click
        /// </summary>
        public override void BeginEdit()
        {
            if (!this.inTxn && this.ObjectElement != null && ((MNZDto)this.ObjectElement).Equals( default(MNZDto)))
            {
                this.inTxn = true;
                if (this.backupEntity == null)
                    this.backupEntity = (MNZDto)this.ObjectElement.Clone();
            }
            else
            {
                if (!this.inTxn)
                {
                    this.inTxn = true;
                    //SpecificationDto spDto = MNZDto2Specificaton();
                    IDictionary<string, string> parameters = new Dictionary<string, string>();

                    parameters.Add(string.Format("{0};{1}", "MNZ", "EntityM_Id"), string.Format("{0};{1}", "IsEqualTo", this.ObjectElement.EntityM_Id.ToString()));
                    parameters.Add(string.Format("{0};{1}", "MNZ", "EntityN_Id"), string.Format("{0};{1}", "IsEqualTo", this.ObjectElement.EntityN_Id.ToString()));
                    parameters.Add(string.Format("{0};{1}", "MNZ", "EntityZ_Id"), string.Format("{0};{1}", "IsEqualTo", this.ObjectElement.EntityZ_Id.ToString()));
                    this.CancelEdit();
                    this.NavigationService.NavigateToWorkSpace(typeof(MNZView).FullName, parameters);
                }
                else
                {

                }
            }
        }

        private SpecificationDto MNZDto2Specificaton()
        {
            SpecificationDto spDto = new SpecificationDto() { PageIndex = 1, PageSize = 5 };
            //var includes = Inflexion2.Domain.Reflection.ValueObjectReflection<MNZDto>.GetValueObjectProperties();
            Filter f;
            f = new Filter() { Property = "EntityM_Id", Operator = "IsEqualTo", Value = this.ObjectElement.EntityM_Id.ToString() };
            spDto.CompositeFilter.Filters.Add(f);

            f = new Filter() { Property = "EntityN_Id", Operator = "IsEqualTo", Value = this.ObjectElement.EntityN_Id.ToString() };
            spDto.CompositeFilter.Filters.Add(f);

            f = new Filter() { Property = "EntityZ_Id", Operator = "IsEqualTo", Value = this.ObjectElement.EntityZ_Id.ToString() };
            spDto.CompositeFilter.Filters.Add(f);

            return spDto;
        }
        #endregion
    }
} //  Needel.Common.FrontEnd.WpfModule