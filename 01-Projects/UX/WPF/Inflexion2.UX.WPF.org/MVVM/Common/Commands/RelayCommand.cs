// -----------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion2.UX.WPF.MVVM
{

    using System;
    using System.Diagnostics;
    using System.Windows.Input;


    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other 
    /// objects by invoking delegates. The default return value for the 
    /// CanExecute method is 'true'.
    /// </summary>
    /// <remarks>
    /// Sin comenarios adicionales.
    /// </remarks>
    public class RelayCommand<T> : ICommand
    {

        #region VARIABLES

        readonly Predicate<T> _canExecute;

        readonly Action<T> _execute;

        #endregion

        #region CONSTRUCTORS

            /// <summary>
            /// Initializes a new instance of the <see cref="RelayCommand&lt;T&gt;"/> 
            /// class and the command can always be executed.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="execute">
            /// The execution logic.
            /// </param>
            public RelayCommand(Action<T> execute)
                : this(execute, null)
            {
            } // RelayCommand Constructor

            /// <summary>
            /// Initializes a new instance of the <see cref="RelayCommand&lt;T&gt;"/> class.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="execute">
            /// The execution logic.
            /// </param>
            /// <param name="canExecute">
            /// The execution status logic.
            /// </param>
            public RelayCommand(
                                Action<T> execute, 
                                Predicate<T> canExecute)
            {

                if (execute == null)
                    throw new ArgumentNullException("execute");
                _execute = execute;
                _canExecute = canExecute;
            } // RelayCommand Constructor

        #endregion

        #region ICommand Members

            /// <summary>
            /// Evento que se lanza para preguntar si se puede ejecutar el comando.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    if (_canExecute != null)
                        CommandManager.RequerySuggested += value;
                }
                remove
                {
                    if (_canExecute != null)
                        CommandManager.RequerySuggested -= value;
                }
            } // CanExecuteChanged

            /// <summary>
            /// Función pública utilizada para preguntar si se puede ejecutar el comando.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="parameter">
            /// Parámetro de tipo <see cref="Object"/> de entrada a la función.
            /// </param>
            [DebuggerStepThrough]
            public Boolean CanExecute(Object parameter)
            {
                return _canExecute == null ? true : _canExecute((T)parameter);
            } // CanExecute

            /// <summary>
            /// Método público encargado de ejecutar el método.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="parameter">
            /// Parámetro de tipo <see cref="Object"/> de entrada al método.
            /// </param>
            public void Execute(Object parameter)
            {
                _execute((T)parameter);
            } // Execute

        #endregion

    } // RelayCommand


    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other 
    /// objects by invoking delegates. The default return value for the 
    /// CanExecute method is 'true'.
    /// </summary>
    /// <remarks>
    /// Sin comenarios adicionales.
    /// </remarks>
    public class RelayCommand : ICommand
    {

        #region VARIABLES

            readonly Func<Boolean> _canExecute;

            readonly Action _execute;

        #endregion

        #region CONSTRUCTORS

            /// <summary>
            /// Initializes a new instance of the <see cref="RelayCommand&lt;T&gt;"/> 
            /// class and the command can always be executed.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="execute">
            /// The execution logic.
            /// </param>
            public RelayCommand(Action execute)
                : this(execute, null)
            {
            } // RelayCommand Constructor

            /// <summary>
            /// Initializes a new instance of the <see cref="RelayCommand&lt;T&gt;"/> class.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="execute">
            /// The execution logic.
            /// </param>
            /// <param name="canExecute">
            /// The execution status logic.
            /// </param>
            public RelayCommand(
                                Action execute, 
                                Func<Boolean> canExecute)
            {

                if (execute == null)
                    throw new ArgumentNullException("execute");
                _execute = execute;
                _canExecute = canExecute;
            } // RelayCommand Constructor

        #endregion

        #region ICommand Members

            /// <summary>
            /// Evento que se lanza para preguntar si se puede ejecutar el comando.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    if (_canExecute != null)
                        CommandManager.RequerySuggested += value;
                }
                remove
                {
                    if (_canExecute != null)
                        CommandManager.RequerySuggested -= value;
                }
            } // CanExecuteChanged

            /// <summary>
            /// Función pública utilizada para preguntar si se puede ejecutar el comando.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="parameter">
            /// Parámetro de tipo <see cref="Object"/> de entrada a la función.
            /// </param>
            [DebuggerStepThrough]
            public Boolean CanExecute(Object parameter)
            {
                return _canExecute == null ? true : _canExecute();
            } // CanExecute

            /// <summary>
            /// Método público encargado de ejecutar el método.
            /// </summary>
            /// <remarks>
            /// Sin comentarios adicionales.
            /// </remarks>
            /// <param name="parameter">
            /// Parámetro de tipo <see cref="Object"/> de entrada al método.
            /// </param>
            public void Execute(Object parameter)
            {
                _execute();
            } // Execute

        #endregion

    } // RelayCommand

} // Company.Product.Shared.SharedCore.UI.MVVM