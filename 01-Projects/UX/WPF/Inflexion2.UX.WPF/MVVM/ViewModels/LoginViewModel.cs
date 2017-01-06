// -----------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion2.UX.WPF.MVVM.ViewModels
{
    using Inflexion2.Resources;
    using Inflexion2.UX.WPF.MVVM;
    using MvvmValidation;
    using System;
    using System.Windows.Input;
    using System.Windows.Threading;

    /// <summary>
    /// .en view model to managed user login
    /// .es View model para el login de usuario en el sistema.
    /// </summary>
    /// <remarks>
    /// .en No comment
    /// Sin comentarios adicionales.
    /// </remarks>
    public class LoginViewModel : BaseViewModel
    {

        #region FIELDS

        private string login;
        private string password;
        private bool? dialogResult;
        DispatcherTimer dayTimer = new DispatcherTimer();

        #endregion

#if DEBUG

        /// <summary>
        /// 
        /// </summary>
        public LoginViewModel()
        {

            this.login = FrameworkResource.NameOfUser;
            this.password = FrameworkResource.Password;
            
            dayTimer.Interval = TimeSpan.FromMilliseconds(500);
            dayTimer.Tick += new EventHandler(dayTimer_Tick);
            dayTimer.Start();
        }

#endif

        #region PROPERTIES

        /// <summary>
        /// Reloj
        /// </summary>
        public DateTime CurrentDateAndTime { get; private set; }

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

        /// <summary>
        /// go on command
        /// </summary>
        public ICommand Ok
        {
            get
            {
                return new RelayCommand(ExecuteOk, CanExecuteOk);
            }
        } // Ok Command

        /// <summary>
        /// cancel dialog command and close the aplication
        /// </summary>
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

            this.DialogResult = true;
            this.dayTimer.Stop();
            // TODO descomentar al implementar la seguridad
            //ApplicationContext.UserContext = new UserContextDto();

            //try
            //{
            //    AuthenticationServiceClient loginSvc = new AuthenticationServiceClient();

            //    int applicationId = 2;
            //    if (ConfigurationManager.AppSettings.AllKeys.Contains("applicationId"))
            //    {
            //        applicationId = int.Parse(ConfigurationManager.AppSettings["applicationId"]);
            //    }

            //    UserContextDto userContext = loginSvc.Login(new UserCredentialsDto(this.Login, this.Password, string.Empty, applicationId, string.Empty));
            //    if (userContext != null)
            //    {
            //        ApplicationContext.UserContext = userContext;
            //        this.DialogResult = true;
            //    }
            //    else
            //    {
            //        this.DialogResult = false;
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    this.DialogResult = false;
            //}
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

        void dayTimer_Tick(object sender, EventArgs e)
        {
            CurrentDateAndTime = DateTime.Now;

            this.RaisePropertyChanged(() => this.CurrentDateAndTime);
        }

        #endregion

    } // LoginViewModel

} // Inflexion2.UX.WPF
