// -----------------------------------------------------------------------
// <copyright file="ToolbarViewModel.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.MVVM.ViewModels
{
    #region Imports

    using System;
    using System.Linq;

    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Windows.Controls.Ribbon;
    using Inflexion.Framework.UX.Windows.MVVM.Views;

    #endregion

    /// <summary>
    /// Clase base para las clases modelo de vista (MVVM) que utilizan la región ToolbarRegion.
    /// </summary>
    public class ToolbarViewModel : RegionViewModel
    {
        #region Fields

        /// <summary>
        /// Referencia al ribbon gestionado.
        /// </summary>
        private readonly Ribbon innerRibbon;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:ToolbarViewModel"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:ToolbarViewModel"/>.
        /// </remarks>
        public ToolbarViewModel()
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:ToolbarViewModel"/>.
        /// </summary>
        /// <param name="ribbon">
        /// Ribbon que se va a gestionar.
        /// </param>
        /// <remarks>
        /// Constructor de la clase <see cref="T:ToolbarViewModel"/>.
        /// </remarks>
        public ToolbarViewModel(Ribbon ribbon)
        {
            this.innerRibbon = ribbon;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene la referencia al ribbon gestionado.
        /// </summary>
        protected Ribbon InnerRibbon
        {
            get
            {
                return this.innerRibbon;
            }
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Obtiene la referencia al ViewModel asociado a la barra de herramientas actual.
        /// </summary>
        /// <returns>
        /// La referencia al ViewModel asociado a la barra de herramientas actual.
        /// </returns>
        public static ToolbarViewModel GetCurrentToolbarViewModel()
        {
            ShellWindow shell = (ShellWindow)System.Windows.Application.Current.MainWindow;

            return (ToolbarViewModel)shell.ApplicationRibbon.DataContext;
        }

        #endregion

        #region Public Methods

        public void PruebaTonta()
        {
            RibbonTab tab = new RibbonTab()
            {
                Header = "Mi Pestaña",
                Tag = Guid.NewGuid()
            };

            RibbonGroup group = new RibbonGroup()
            {
                Header = "Mi Grupo",
                Tag = Guid.NewGuid()
            };

            RibbonButton button = new RibbonButton()
            {
                //Command = 
                Label = "Mi Botón",
                Tag = Guid.NewGuid()
            };

            group.Items.Add(button);
            tab.Items.Add(group);

            this.InnerRibbon.Items.Add(tab);
        }

        #endregion

        #region Overridden Methods

        /// <summary>
        /// Obtiene un valor que indica si esta instancia debe ser mantenida cuando se desactiva.
        /// </summary>
        /// <value>
        /// Es true para indicar que la instancia debe ser mantenida; en caso contrario, false.
        /// </value>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:Microsoft.Practices.Prism.Regions.IRegionMemberLifetime"/>.
        /// </remarks>
        public override bool KeepAlive
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}