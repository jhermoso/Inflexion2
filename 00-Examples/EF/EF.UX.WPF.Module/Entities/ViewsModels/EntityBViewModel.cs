// -----------------------------------------------------------------------
// <copyright file="ProductoViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace EF.UX.WPF.Module.Entities
{

    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    //using Inflexion.Framework.Application.Security.Data.Base;
    //using Inflexion.Framework.Extensions;
    //using Inflexion.Framework.UX.Windows;
    //using Inflexion.Framework.UX.Windows.MVVM;
    //using Inflexion.Framework.UX.Windows.MVVM.CRUD;
    //using Inflexion.Framework.UX.Windows.Services;

    using EFApplication;
    using EFApplication.Dtos;
    //using Company.Product.Shared.Application.RemoteClient.WCF;


    //using Company.Product.Shared.CompanyProduct.Application.Data.Base;
    //using Company.Product.Shared.CompanyProduct.Application.RemoteClient.WCF.ProductoReference;
    //using Company.Product.Shared.CompanyProduct.UI.WPF.Services;
    //using Company.Product.Shared.SharedCore.Domain.Data.Enum;

    //using Microsoft.Practices.ServiceLocation;
    using MvvmValidation;

    /// <summary>
    /// Clase que representa el ViewModel de la vista 
    /// <see cref="T:Company.Product.Shared.UX.WPF.Producto.View.ProductoView"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public class EntityBViewModel : Inflexion2.UX.WPF.MVVM.CRUD.CrudViewModel<EntityBDto, int>
    {

        #region CONTRUCTORS

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:ViewModel"/>.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public EntityBViewModel()
            : base()
        {
        } // ProductoViewModel Constructor


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:ProductoViewModel"/>.
        /// </summary>
        /// <param name="granFranjaSofres">
        /// Parámetro de tipo <see cref="ProductoDto"/> que contiene la información necesaria.
        /// </param>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public EntityBViewModel(EntityBDto element)
            : base(element)
        {
        } // ProductoViewModel Constructor

    #endregion

        //#region PROPERTIES

        /// <summary>
        /// Propiedad para establecer el Titulo de la ventana
        /// </summary>
        public override string Title
        {
            get
            {
                return "Entity B";
            }
        }

        /// <summary>
        /// Propiedad pública que obtiene o establece el nombre de la entidad.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para obtener o establecer el nombre de la entidad.
        /// </value>
        public string Nombre
        {
            get
            {
                return this.ObjectElement.Name;
            }
            set
            {
                if (this.ObjectElement.Name != value)
                {
                    this.ObjectElement.Name = value;
                    this.RaisePropertyChanged(() => this.Nombre);
                }
            }
        } // Nombre Property

        ///// <summary>
        ///// Propiedad pública que obtiene o establece la descripción de la entidad.
        ///// </summary>
        ///// <remarks>
        ///// Sin comentarios adicionales.
        ///// </remarks>
        ///// <value>
        ///// Valor que es utilizado para obtener o establecer la descripción de la entidad.
        ///// </value>
        //public string Descripcion
        //{
        //    get
        //    {
        //        return this.ObjectElement.Descripcion;
        //    }
        //    set
        //    {
        //        if (this.ObjectElement.Descripcion != value)
        //        {
        //            this.ObjectElement.Descripcion = value;
        //            this.RaisePropertyChanged(() => this.Descripcion);
        //        }
        //    }
        //} // Descripcion Property


        ///// <summary>
        ///// Obtiene o establece el código externo de la entidad.
        ///// </summary>
        ///// <value>
        ///// Codigo externo de la entidad.
        ///// </value>
        //public string CodigoExterno
        //{
        //    get
        //    {
        //        return this.ObjectElement.CodigoExterno;
        //    }
        //    set
        //    {
        //        if (this.ObjectElement.CodigoExterno != value)
        //        {
        //            this.ObjectElement.CodigoExterno = value;
        //            this.RaisePropertyChanged(() => this.CodigoExterno);
        //        }
        //    }
        //}


        ///// <summary>
        ///// Obtiene o establece el Nombre del Soporte de la entidad.
        ///// </summary>
        ///// <value>
        ///// Nombre Del Soporte de la entidad.
        ///// </value>
        //public string NombreSoporte
        //{
        //    get
        //    {
        //        return this.ObjectElement.NombreSoporte;
        //    }
        //    set
        //    {
        //        if (this.ObjectElement.NombreSoporte != value)
        //        {
        //            this.ObjectElement.NombreSoporte = value;
        //            this.RaisePropertyChanged(() => this.NombreSoporte);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Obtiene o establece el Nombre del Ambito de la entidad.
        ///// </summary>
        ///// <value>
        ///// Nombre Del Ambito de la entidad.
        ///// </value>
        //public string NombreAmbito
        //{
        //    get
        //    {
        //        return this.ObjectElement.NombreAmbito;
        //    }
        //    set
        //    {
        //        if (this.ObjectElement.NombreAmbito != value)
        //        {
        //            this.ObjectElement.NombreAmbito = value;
        //            this.RaisePropertyChanged(() => this.NombreAmbito);
        //        }
        //    }
        //}


        /////<summary>
        ///// Propiedad pública encargada de obtener y establecer el Visible Extranet
        ///// de la entidad.
        ///// </summary>
        ///// <remarks>
        ///// Sin comentarios adicionales.
        ///// </remarks>
        ///// <value>
        ///// Indica el campo Visibl extranet de la entidad.
        ///// </value>
        //public bool EsVisibleExtranet
        //{
        //    get
        //    {
        //        return this.ObjectElement.EsVisibleExtranet;
        //    }
        //    set
        //    {
        //        if (this.ObjectElement.EsVisibleExtranet != value)
        //        {
        //            this.ObjectElement.EsVisibleExtranet = value;
        //            RaisePropertyChanged(() => this.EsVisibleExtranet);
        //        }
        //    }
        //} // GestionaPosiciones

        /////<summary>
        ///// Propiedad pública encargada de obtener y establecer la hora 
        ///// de inicio de emisión de la desconexión
        ///// </summary>
        ///// <value>
        ///// Indica el campo hora de inicio de emisión
        ///// </value>
        //public DateTime? HoraInicioEmision
        //{
        //    get
        //    {
        //        return this.ObjectElement.HoraInicioEmision;
        //    }
        //    set
        //    {
        //        if (this.ObjectElement.HoraInicioEmision != value)
        //        {
        //            this.ObjectElement.HoraInicioEmision = value;
        //            RaisePropertyChanged(() => this.HoraInicioEmision);
        //        }
        //    }
        //} // HoraInicioEmision

        /////<summary>
        ///// Propiedad pública encargada de obtener y establecer la hora 
        ///// de fin de emisión de la desconexión
        ///// </summary>
        ///// <value>
        ///// Indica el campo hora de fin de emisión
        ///// </value>
        //public DateTime? HoraFinEmision
        //{
        //    get
        //    {
        //        return this.ObjectElement.HoraFinEmision;
        //    }
        //    set
        //    {
        //        if (this.ObjectElement.HoraFinEmision != value)
        //        {
        //            this.ObjectElement.HoraFinEmision = value;
        //            RaisePropertyChanged(() => this.HoraFinEmision);
        //        }
        //    }
        //} // HoraFinEmision

        ///// <summary>
        ///// Indica el soporte seleccionado
        ///// </summary>
        //public int SelectedSoporteValue
        //{
        //    get
        //    {
        //        return this.ObjectElement.SoporteId;
        //    }
        //    set
        //    {
        //        if (this.ObjectElement.SoporteId != value)
        //        {
        //            this.ObjectElement.SoporteId = value;
        //            RaisePropertyChanged(() => this.SelectedSoporteValue);
        //        }
        //    }
        //}

        //private ObservableCollection<IKeyValueItem> soportes;
        //public ObservableCollection<IKeyValueItem> Soportes
        //{
        //    get
        //    {
        //        return this.soportes;
        //    }
        //    set
        //    {
        //        if (this.soportes != value)
        //        {
        //            this.soportes = value;
        //            RaisePropertyChanged(() => this.Soportes);
        //        }
        //    }
        //}

        //public ICommand RefreshSoportes { get { return new RelayCommand(LoadSoportes); } }


        ////Combo Ambito
        //public int SelectedAmbitoValue
        //{
        //    get
        //    {
        //        return this.ObjectElement.AmbitoId;
        //    }
        //    set
        //    {
        //        if (this.ObjectElement.AmbitoId != value)
        //        {
        //            this.ObjectElement.AmbitoId = value;
        //            RaisePropertyChanged(() => this.SelectedAmbitoValue);
        //        }
        //    }
        //}

        //private ObservableCollection<IKeyValueItem> ambitos;
        //public ObservableCollection<IKeyValueItem> Ambitos
        //{
        //    get
        //    {
        //        return this.ambitos;
        //    }
        //    set
        //    {
        //        if (this.ambitos != value)
        //        {
        //            this.ambitos = value;
        //            RaisePropertyChanged(() => this.Ambitos);
        //        }
        //    }
        //}

        //public ICommand RefreshAmbitos { get { return new RelayCommand(LoadAmbitos); } }


        //private ObservableCollection<IKeyValueItem> grupoProductoes;
        //public ObservableCollection<IKeyValueItem> GrupoProductoes
        //{
        //    get
        //    {
        //        return this.grupoProductoes;
        //    }
        //    set
        //    {
        //        if (this.grupoProductoes != value)
        //        {
        //            this.grupoProductoes = value;
        //            RaisePropertyChanged(() => this.GrupoProductoes);
        //        }
        //    }
        //}

        //public ICommand RefreshGrupoProductoes { get { return new RelayCommand(LoadGrupoProductoes); } }

        //#endregion

        #region METHODS

        /// <summary>
        /// Método encargado de recuperar los datos de una entidad mediante su identificador.
        /// </summary>
        /// <param name="identifier">
        /// Parámetro que indica el identificador de la entidad que se va a recuperar.
        /// </param>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <returns>
        /// Devuelve el objeto Dto <see cref="MedioDto"/> correspondiente.
        /// </returns>
        public override EntityBDto GetById(int identifier)
        {
            //UserContextDto userContext = ApplicationContext.UserContext;
            WcfClient.EntityBServiceReference.EntityBWebServiceClient serviceClient = new WcfClient.EntityBServiceReference.EntityBWebServiceClient();

           // Consumimos el servicio y obtenemos los datos.
            var ProductoDto = serviceClient.GetById(identifier /*, userContext*/);
            // Devolvemos la respuesta.
            return ProductoDto;
        } // GetById



        /// <summary>
        /// Método encargado de crear o actualizar una entidad de tipo Medio.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="parameter">
        /// Parámetro con información adicional.
        /// </param>
        public override void OnSaveRecord(object parameter)
        {
            if (this.IsActive &&
                    (this.ObjectElement != null))
            {
                //UserContextDto userContext = ApplicationContext.UserContext;
                
                WcfClient.EntityBServiceReference.EntityBWebServiceClient serviceClient = new WcfClient.EntityBServiceReference.EntityBWebServiceClient();

                if (this.ObjectElement.Id == default(int) )
                {
                    serviceClient.Create(this.ObjectElement/*, userContext*/);
                    this.MessageBoxService.Show("Entidad agregada");
                }
                else
                {
                    bool response = serviceClient.Update(this.ObjectElement/*, userContext*/);
                    this.MessageBoxService.Show("Entidad actualizada");
                }
            }
        } // OnSaveRecord


        //private void LoadSoportes()
        //{
        //    var svc = ServiceLocator.Current.GetInstance<IQueryServiceFactory>();
        //    ISoporteQueryService queryService = svc.GetInstance<ISoporteQueryService>();
        //    this.Soportes = new ObservableCollection<IKeyValueItem>(queryService.GetKeyValueItems());
        //    this.Rebind();
        //}

        //private void LoadAmbitos()
        //{
        //    var svc = ServiceLocator.Current.GetInstance<IQueryServiceFactory>();
        //    IAmbitoQueryService queryService = svc.GetInstance<IAmbitoQueryService>();
        //    this.Ambitos = new ObservableCollection<IKeyValueItem>(queryService.GetKeyValueItems());
        //    this.Rebind();
        //}

        //private void LoadGrupoProductoes()
        //{
        //    var svc = ServiceLocator.Current.GetInstance<IQueryServiceFactory>();
        //    IGrupoProductoQueryService queryService = svc.GetInstance<IGrupoProductoQueryService>();
        //    this.GrupoProductoes = new ObservableCollection<IKeyValueItem>(queryService.GetKeyValueItems());
        //    this.Rebind();
        //}


        #endregion

        #region Protected Methods

        protected override void SetupValidation(MvvmValidation.ValidationHelper validation)
        {

            //// Validación de hora de Inicio
            //validation.AddRule(
            //                   () => this.HoraInicioEmision,
            //                   () => RuleResult.Assert(
            //                                           this.HoraInicioEmision != null,
            //                                           "La hora de inicio de emisión es requerida"));

            //// Validación de hora de Fin
            //validation.AddRule(
            //                   () => this.HoraFinEmision,
            //                   () => RuleResult.Assert(
            //                                           this.HoraFinEmision != null,
            //                                           "La hora de fin de emisión es requerida"));

            //// Hora Fin mayor que Hora Inicio
            //validation.AddRule(
            //                   () => this.HoraInicioEmision,
            //                   () => this.HoraFinEmision,
            //                   () => RuleResult.Assert(
            //                                           (this.HoraInicioEmision != null && this.HoraFinEmision != null)
            //                                           && ((DateComparisonResult)this.HoraFinEmision.Value.CompareTo24(this.HoraInicioEmision.Value) == DateComparisonResult.Later),
            //                                           "La hora de Fin de emisión debe ser mayor que la hora de Inicio de emisión"));

        }


        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            //LoadSoportes();
            //LoadAmbitos();
            //LoadGrupoProductoes();

            base.OnNavigatedTo(navigationContext);
        }

        #endregion

    } // ProductoViewModel

} // Company.Product.Shared.Module.UX.WPF.Producto.ViewModel
