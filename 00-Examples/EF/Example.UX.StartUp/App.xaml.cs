// -----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Company.Product.Shared.UX.Windows
{
    #region Imports
    
    using System.Windows;

    #endregion

    /// <summary>
    /// Lógica de interación para App.xaml.
    /// </summary>
    public partial class App : Application
    {
        #region Protected Methods

        /// <summary>
        /// Provoca el evento <see cref="M:System.Windows.Application.Startup"/>.
        /// </summary>
        /// <param name="e">
        /// Contiene los datos del evento.
        /// </param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }

        #endregion
    }
}