// -----------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion.Framework.UX.Windows
{
    using System.Configuration;
    using System.Linq;
    using System.Net;
    using System.Windows.Input;

    using MvvmValidation;
    using Inflexion.Framework.UX.Windows.MVVM;
    //using Inflexion.Framework.Application.Security.RemoteClient.WCF.AuthenticationService;
    using Inflexion.Framework.Application.Security.Data.Base;

    /// <summary>
    /// Clase view model para el login de usuario en el sistema.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public class LoginViewModel : BaseViewModel
    {

        #region FIELDS

        private string login;
        private string password;
        private bool? dialogResult;

        #endregion

#if DEBUG

        public LoginViewModel()
        {
            this.login = "qwerty";
            this.password = "qwerty";
        }

#endif

        #region PROPERTIES

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// </value>
        public string Login
        {
            get
            {
                return this.login;
            }
            set
            {
                if (this.login != value)
                {
                    this.login = value;
                    RaisePropertyChanged(() => this.Login);
                }
            }
        } // Login Property

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// </value>
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    RaisePropertyChanged(() => Password);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <value>
        /// </value>
        public bool? DialogResult
        {
            get
            {
                return this.dialogResult;
            }
            set
            {
                if (this.dialogResult != value)
                {
                    this.dialogResult = value;
                    RaisePropertyChanged(() => this.DialogResult);
                }
            }
        } // DialogResult

        #endregion

        #region COMMNANDS

        public ICommand Ok
        {
            get
            {
                return new RelayCommand(ExecuteOk, CanExecuteOk);
            }
        } // Ok Command


        public ICommand Cancel
        {
            get
            {
                return new RelayCommand(() => { DialogResult = false; });
            }
        } // Cancel Command

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <returns></returns>
        public bool CanExecuteOk()
        {
            return this.Validation.ValidateAll().IsValid;
        } // CanExecuteOk


        #endregion

        #region METHODS

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales
        /// </remarks>
        public void ExecuteOk()
        {
            ApplicationContext.UserContext = new UserContextDto();
            this.DialogResult = true;

            try
            {
                Inflexion.Framework.Application.Security.RemoteClient.WCF.AuthenticationService.AuthenticationServiceClient loginSvc = new Inflexion.Framework.Application.Security.RemoteClient.WCF.AuthenticationService.AuthenticationServiceClient();

                // TODO: hay que cambiar esto por algo más elegante.
                int applicationId = 2; // este numeor de ide corresponde al que se guarda en la base de datos en la tabla de aplicaciones.
                if (ConfigurationManager.AppSettings.AllKeys.Contains("applicationId"))
                {
                    applicationId = int.Parse(ConfigurationManager.AppSettings["applicationId"]);
                }

                UserContextDto userContext = loginSvc.Login(new UserCredentialsDto(this.Login, this.Password, string.Empty, applicationId, string.Empty));
                if (userContext != null)
                {
                    ApplicationContext.UserContext = userContext;
                    this.DialogResult = true;
                }
                else
                {
                    this.DialogResult = false;
                }
            }
            catch (System.Exception ex)
            {
                this.DialogResult = false;
            }
        } // ExecuteOk

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales
        /// </remarks>
        /// <param name="validation"></param>
        protected override void SetupValidation(MvvmValidation.ValidationHelper validation)
        {
            base.SetupValidation(validation);

            validation.AddRequiredRule(() => this.Login, "Usuario requerido");
            validation.AddRequiredRule(() => this.Password, "Password requerida");

        } // SetupValidation

        #endregion

    } // LoginViewModel

} // Inflexion.Framework.UX.Windows
