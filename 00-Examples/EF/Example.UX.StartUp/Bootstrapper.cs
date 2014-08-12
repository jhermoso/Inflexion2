// -----------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Company.Product.Shared.UX.Windows
{
    #region Imports

    using Inflexion2.UX.WPF.MVVM;

    #endregion

    /// <summary>
    /// .en Application's boot. (Main point enter)
    /// .es Punto de arranque de la aplicación.
    /// </summary>
    internal sealed class Bootstrapper : BaseBootstrapper
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:Bootstrapper"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:Bootstrapper"/>.
        /// </remarks>
        public Bootstrapper()
            : base("*.UX.WPF.Module.dll", string.Empty) // *.UX.WPF.Module.dll
        {

        }

        #endregion
    }
}