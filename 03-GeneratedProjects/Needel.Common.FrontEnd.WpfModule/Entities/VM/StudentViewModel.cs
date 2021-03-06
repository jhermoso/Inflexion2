﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Student" company="Company">
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
    using Needel.Common.Application.WcfClient.StudentReference;
    using Needel.Common.Application.WcfClient.TeacherReference; //property children

    using Inflexion2.Domain.Data;
    using Inflexion2.Application;
    using Inflexion2.Resources;
    using Inflexion2.UX.WPF.MVVM;
    using Inflexion2.UX.WPF.MVVM.Commands;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    #endregion

    /// <summary>
    /// .en Interaction logic for StudentViewModel.xaml
    /// .es Logica de interación para la vista StudentViewModel.xaml
    /// </summary>
    public partial class StudentViewModel : Inflexion2.UX.WPF.MVVM.CRUD.CrudViewModel<StudentDto, Int32>, IEditableObject
    {
        #region Fields

        private TeacherQueryViewModel teachersQueryVM;
        private TeacherQueryViewModel allStudentsQueryVM;//*% no es reflexiva es Many 2 Many
        #endregion

        #region Constructors
        /// <summary>
        /// .en Initialize a new instace for the class <see cref="T:StudentViewModel"/>.
        /// .es Inicializa una nueva instancia de la clase <see cref="T:StudentViewModel"/>.
        /// </summary>
        public StudentViewModel() : base()
        {
            Initialization();
        } // StudentViewModel Constructor

        public override void Initialization(StudentDto element = null)
        {
            // .en https://github.com/SeriousM/WPFLocalizationExtension/issues/87#issuecomment-174510689
            // bind the property title of the VM to a dependecy property for the view. To allow the localization of the property tittle.
            // becouse this property don´t belong the class StudentControl what is the base for the view
            // but avalon dock uses this property to set the title of the dockable elements
            // if we wont tha this can be updated when the selected culture is changed we need this work arround.
            var targetProperty = this.GetType().GetProperty(nameof(StudentQueryViewModel.Title));
            var locBinding = new WPFLocalizeExtension.Extensions.LocTextExtension("StudentAlias");
            locBinding.SetBinding(this, targetProperty);
            this.CurrentViewName = "StudentView";
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

        } // StudentViewModel initialization

        /// <summary>
        /// .en Child composed constructor <see cref="T:StudentViewModel"/>.
        /// This constructor is used to be the viewmodel of a nested viemodel in a hierchahy.
        /// </summary>
        /// <param name="element">
        /// .en Parameter of type <see cref="StudentDto"/> with all the related data.</param>
        /// <param name="first">first element in the current paged collection</param>
        /// <param name="previous">last element in the current paged collection</param>
        /// <param name="next">next element in the current paged collection</param>
        /// <param name="last">last element in the current paged collection</param>
        /// <remarks>
        /// .en these initialization are to allow navigation betwen pages and not only next record. TODO: test this.
        /// </remarks>
        public StudentViewModel(StudentDto element, StudentDto first, StudentDto previous, StudentDto next, StudentDto last)
            : base(element)
        {
            this.firstEntityId = first != null ? first.Id: default(Int32);
            this.nextEntityId = next != null ? next.Id : default(Int32);
            this.lastEntityId = last != null ? last.Id : default(Int32);
            this.previousEntityId = previous != null ? previous.Id : default(Int32);
            
            Initialization(element);

        } // StudentViewModel Parametrized Constructor


        /// <summary>
        /// .es Inicializa una nueva instancia de la clase <see cref="T:UserViewModel"/>.
        /// Este constructor se invoca desde el QueryViewModel ya que para cada 
        /// linea que se visualiza en la lista de Usuarios se crea el Viewmodel de dicho usuario.
        /// Esta lista se almacena en una observable collection en el query view model con la que se hace el binding 
        /// de la pantalla query.
        /// Por esta razon las entidades relacionadas no se cargan si no se navega hasta esta entidad.
        /// </summary>
        /// <param name="element">
        /// Parámetro de tipo <see cref="StudentDto"/> que contiene la información necesaria.
        /// </param>
        public StudentViewModel(StudentDto element, bool simpleViewModel = true)
            :  base(element)
        {
            if (!simpleViewModel)
            {
                Initialization(element);
            }
        } // StudentViewModel Parametrized Constructor

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return this.ObjectElement.Name;
            }
            set
            {
                if (this.ObjectElement.Name != value)
                {
                    this.ObjectElement.Name  = value;
                    this.RaisePropertyChanged(() => this.Name);
                }
            }
        } // Name

        #endregion

        #region Properties from Children

        /// <summary>
        /// Property helper to allow easy access to the children properties
        /// </summary>
        public System.Collections.Generic.List<TeacherDto> Teachers
        {
            get
            {
                return this.ObjectElement.Teachers;
            }
            set
            {
                if (this.ObjectElement.Teachers != value)
                {
                    if (value == null )
                    {
                        this.ObjectElement.Teachers = null;
                    }
                    else
                    {
                        this.ObjectElement.Teachers = value;
                    }

                    this.RaisePropertyChanged(() => this.Teachers);
                }
            }
        } // Teachers

        /// <summary>
        /// 
        /// </summary>
        public TeacherQueryViewModel TeachersQueryVM
        {
            get
            {
                return teachersQueryVM;
            }
            set
            {
                if (this.teachersQueryVM != value)
                {
                    this.teachersQueryVM = value;
                    this.teachersQueryVM.ParentViewName = this.CurrentViewName;
                    this.teachersQueryVM.Title = "TeachersQueryVM";
                    this.RaisePropertyChanged(() => this.TeachersQueryVM);
                }
            }
        } // TeachersQueryViewModel

        /// <summary>
        /// collection with all free items for drag and drop
        /// </summary>
        public TeacherQueryViewModel AllTeachersQueryVM
        {
            get
            {
                return allStudentsQueryVM;
            }
            set
            {
                if (this.allStudentsQueryVM != value)
                {
                    this.allStudentsQueryVM = value;
                    this.allStudentsQueryVM.Title = "AllStudentsQueryVM"; //mark the viewmodel to facilitate the drag&drop
                    this.allStudentsQueryVM.ParentViewName = this.CurrentViewName;
                    // todo: add a reference to parentviewmodel = this;
                    this.RaisePropertyChanged(() => this.AllTeachersQueryVM);
                }
            }
        } // AllStudentsQueryVM
        #endregion

        #region Methods
        /// <summary>.es Obtener el dto de la entidad Student por su identificador.</summary>
        /// <param name="identifier">.es Parámetro que indica el identificador de la entidad que se va a recuperar.</param>
        /// <returns>.es Devuelve el objeto Dto <see cref="StudentDto"/> correspondiente.</returns>
        public override StudentDto GetById(Int32 identifier)
        {
            StudentServiceClient serviceClient = new StudentServiceClient();
            // .en consume the service and get the data // .es Consumimos el servicio y obtenemos los datos.
            var studentDto = serviceClient.GetById(identifier );

            return studentDto;
        } // GetById

        /// <summary>.es Crear o actualizar una entidad de tipo Student.</summary>
        /// <param name="parameter">data to update.</param>
        public override void OnSaveRecord(object parameter)
        {
            if (this.IsActive && this.ObjectElement != null)
            {
                StudentServiceClient serviceClient = new StudentServiceClient();
                if (this.ObjectElement.Id == default(Int32) )
                {
                    serviceClient.Create(this.ObjectElement);
                    this.MessageBoxService.Show(FrameworkResource.AddedSuccessfullyEntity);
                }
                else
                {
                    bool response = serviceClient.Update(this.ObjectElement);
                    this.MessageBoxService.Show(FrameworkResource.UpdatedSuccessfullyEntity);
                }

                UpdateParentView();
            }
        }

        /// <summary>.en Create a new Student</summary>
        /// <param name="parameter">.en Data to create the new Student</param>
        public override void OnNewRecord(object parameter)
        {
            var views = this.RegionManager.Regions[Inflexion2.UX.WPF.MVVM.RegionNames.WorkspaceRegion].ActiveViews;
            base.OnNewRecord(parameter);
            this.Initialization();
            StudentView currentView = (StudentView)views.FirstOrDefault(c => c as StudentView != null);

            // .en Nested Query view models for the controls of children properties or Many to Many.
            // .es View models anidados para los controles de colecciones de propiedades correspondientes a los hijos.
            (currentView.TeachersQueryView).DataContext = new TeacherQueryViewModel();
            ((TeacherQueryViewModel)(currentView.TeachersQueryView).DataContext).RefreshItems();//*

        }


        public void AttachTeacher(TeacherDto data)//**bis
        {
            this.ObjectElement.Teachers.Add(data);
            TeachersQueryVM = new TeacherQueryViewModel(this.ObjectElement.Teachers, this.CurrentViewName);
        
            var vm = AllTeachersQueryVM.Items.First(c => c.Id == data.Id);
            AllTeachersQueryVM.Items.Remove(vm);
            this.TeachersQueryVM.Rebind();
        }
        
        public void RemoveTeacher(TeacherDto data)
        {
            var vm = AllTeachersQueryVM.Items.First(c => c.Id == data.Id);
            AllTeachersQueryVM.Items.Add(vm);
            this.ObjectElement.Teachers.Remove(data);
            TeachersQueryVM = new TeacherQueryViewModel(this.ObjectElement.Teachers, this.CurrentViewName);
        
            AllTeachersQueryVM.Rebind();
            this.TeachersQueryVM.Rebind();
        }
        #endregion

        #region Protected Methods

        /// <summary>
        /// example to execute validation rules
        /// </summary>
        /// <param name="validation"></param>
        protected override void SetupValidation(MvvmValidation.ValidationHelper validation)
        {
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
            //.en load children entities
            //.es cargar aqui los agregados relacionados

            if (navigationContext.Parameters["Id"] != default(Int32).ToString())//***
            {
                // only in this case there is a need of subscription to update a parent view
                if (!CompositeViewUpdateEvent.Contains(this.OnReceiveCompositeViewUpdateEvent))
                {
                    CompositeViewUpdateEvent.Subscribe(this.OnReceiveCompositeViewUpdateEvent, ThreadOption.UIThread);
                }
            }

            TeachersQueryVM = new TeacherQueryViewModel(this.ObjectElement.Teachers, this.CurrentViewName);//*----
            TeacherServiceClient serviceClient = new TeacherServiceClient();
            var usedTeachers = this.ObjectElement.Teachers.Select(c =>c.Id).ToList();

            var usedIds = new ObservableCollection<Int32>(usedTeachers);
            var allTeachers = serviceClient.GetAllExceptThese(usedIds).ToList();
            AllTeachersQueryVM = new TeacherQueryViewModel(allTeachers, this.CurrentViewName);
            this.TeachersQueryVM.Rebind();
            this.Rebind();
        }

        /// <summary>. en Action to execute when there is a call to update the view.</summary>
        /// <param name="message"></param>
        public override void OnReceiveCompositeViewUpdateEvent(string message)
        {
            this.TeachersQueryVM.OnGetRecords("from StudentViewModel");			
        }

        internal void RefreshRelatedEntities()
        {
        }

        /// <summary>
        /// override of Generic BeginEdit to avoid the edition in the blank line of query viewmodel with double click
        /// </summary>
        public override void BeginEdit()
        {
            if (!this.inTxn && this.IsNotTransient)
            {
                this.inTxn = true;
                if (this.backupEntity == null)
                    this.backupEntity = (StudentDto)this.ObjectElement.Clone();
            }
            else
            {
                this.CancelEdit();
                this.NavigationService.NavigateToWorkSpace(typeof(StudentView).FullName, this.Id);
            }
        }
        #endregion
    }
} //  Needel.Common.FrontEnd.WpfModule
