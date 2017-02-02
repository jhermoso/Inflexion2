//----------------------------------------------------------------------------------------------
// <copyright file="Guard.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    /// Provides utility methods to guard parameter and local variables.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// M�todo encargado de comprobar el valor de la afirmaci�n y
        /// lanzar la excepci�n de tipo <see cref="InvalidOperationException"/>
        /// en caso afirmativo.
        /// </summary>
        /// <param name="assertion">
        /// Par�metro que indica si se lanzar� la excepci�n.
        /// </param>
        /// <param name="exception">
        /// Par�metro que indica el tipo de excepci�n que se lanzar�.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        /// Lanzada cuando el valor de <c>assertion</c> es <c>true</c>.
        /// </exception>
        public static void Against(
            bool assertion,
            Exception exception)
        {
            if (assertion)
            {
                throw exception;
            }
        }

        /// <summary>
        /// M�todo p�blico encargado de comprobar si el argumento es null.
        /// </summary>
        /// <param name="argumentValue">
        /// Par�metro a comprobar si es <c>null</c>.
        /// </param>
        /// <param name="argumentName">
        /// Par�metro que indica el nombre del argumento que se est� comprobando.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Lanzada cuando el par�metro <c>argumentValue</c> es nulo.
        /// </exception>
        public static void ArgumentIsNotNull(
            object argumentValue,
            string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// M�todo p�blico encargado de comprobar si el valor
        /// del argumento es null o cadena vac�a.
        /// </summary>
        /// <param name="argumentValue">
        /// Par�metro a comprobar si es <c>null</c>.
        /// </param>
        /// <param name="argumentName">
        /// Par�metro que indica el nombre del argumento que se est� comprobando.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Lanzada cuando el par�metro <c>argumentValue</c> es nulo o cadena vac�a.
        /// </exception>
        public static void ArgumentNotNullOrEmpty(
            string argumentValue,
            string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> with the specified message
        /// when the assertion statement is true.
        /// </summary>
        /// <typeparam name="TException">The type of exception to throw.</typeparam>
        /// <param name="assertion">The assertion to evaluate. If true then the <typeparamref name="TException"/> exception is thrown.</param>
        /// <param name="message">string. The exception message to throw.</param>
        [SuppressMessage("Microsoft.Design",
                         "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void Against<TException>(bool assertion, string message)
        where TException : Exception
        {
            if (assertion)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> with the specified message
        /// when the assertion statement is true.
        /// </summary>
        /// <typeparam name="TException">The type of exception to throw.</typeparam>
        /// <param name="assertion">The assertion to evaluate. If true then the <typeparamref name="TException"/> exception is thrown.</param>
        /// <param name="message">string. The exception message to throw.</param>
        /// <param name="args"></param>
        [SuppressMessage("Microsoft.Design",
                         "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void Against<TException>(bool assertion, string message, params object[] args)
        where TException : Exception
        {
            if (assertion)
            {
                string msg = string.Format(CultureInfo.InvariantCulture, message, args);
                throw (TException)Activator.CreateInstance(typeof(TException), msg);
            }
        }

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> with the specified message
        /// when the assertion
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="assertion"></param>
        /// <param name="message"></param>
        [SuppressMessage("Microsoft.Design",
                         "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void Against<TException>(Func<bool> assertion, string message)
        where TException : Exception
        {
            // Execute the lambda and if it evaluates to true then throw the exception.
            if (assertion())
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        /// <summary>
        /// Throws a <see cref="InvalidOperationException"/> when the specified object
        /// instance does not implement the <typeparamref name="TInterface"/> interface.
        /// </summary>
        /// <typeparam name="TInterface">The interface type the object instance should implement.</typeparam>
        /// <param name="instance">The object insance to check if it implements the <typeparamref name="TInterface"/> interface</param>
        /// <param name="message">string. The exception message to throw.</param>
        [SuppressMessage("Microsoft.Design",
                         "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void Implements<TInterface>(object instance, string message)
        {
            Implements<TInterface>(instance.GetType(), message);
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> when the specified type does not
        /// implement the <typeparamref name="TInterface"/> interface.
        /// </summary>
        /// <typeparam name="TInterface">The interface type that the <paramref name="type"/> should implement.</typeparam>
        /// <param name="type">The <see cref="Type"/> to check if it implements from <typeparamref name="TInterface"/> interface.</param>
        /// <param name="message">string. The exception message to throw.</param>
        [SuppressMessage("Microsoft.Design",
                         "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void Implements<TInterface>(Type type, string message)
        {
            if (!typeof(TInterface).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Throws a <see cref="InvalidOperationException"/> when the specified object
        /// instance does not inherit from <typeparamref name="TBase"/> type.
        /// </summary>
        /// <typeparam name="TBase">The base type to check for.</typeparam>
        /// <param name="instance">The object to check if it inherits from <typeparamref name="TBase"/> type.</param>
        /// <param name="message">string. The exception message to throw.</param>
        [SuppressMessage("Microsoft.Design",
                         "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void InheritsFrom<TBase>(object instance, string message)
        where TBase : Type
        {
            InheritsFrom<TBase>(instance.GetType(), message);
        }

        /// <summary>
        /// Throws a <see cref="InvalidOperationException"/> when the specified type does not
        /// inherit from the <typeparamref name="TBase"/> type.
        /// </summary>
        /// <typeparam name="TBase">The base type to check for.</typeparam>
        /// <param name="type">The <see cref="Type"/> to check if it inherits from <typeparamref name="TBase"/> type.</param>
        /// <param name="message">string. The exception message to throw.</param>
        [SuppressMessage("Microsoft.Design",
                         "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void InheritsFrom<TBase>(Type type, string message)
        {
            if (type.BaseType != typeof(TBase))
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Throws an exception if an instance of an object is not equal to another object instance.
        /// </summary>
        /// <typeparam name="TException">The type of exception to throw when the guard check evaluates false.</typeparam>
        /// <param name="compare">The comparison object.</param>
        /// <param name="instance">The object instance to compare with.</param>
        /// <param name="message">string. The message of the exception.</param>
        [SuppressMessage("Microsoft.Design",
                         "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void IsEqual<TException>(object compare, object instance, string message)
        where TException : Exception
        {
            if (compare != instance)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        /// <summary>
        /// Throws an exception if instance is null.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="message">The message.</param>
        public static void IsNotNull(object instance, string message)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Throws an exception if instance is null or empty.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="message">The message.</param>
        public static void IsNotNullNorEmpty(string instance, string message)
        {
            if (string.IsNullOrEmpty(instance))
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> when the specified object instance is
        /// not of the specified type.
        /// </summary>
        /// <typeparam name="TType">The Type that the <paramref name="instance"/> is expected to be.</typeparam>
        /// <param name="instance">The object instance whose type is checked.</param>
        /// <param name="message">The message of the <see cref="InvalidOperationException"/> exception.</param>
        [SuppressMessage("Microsoft.Design",
                         "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void TypeOf<TType>(object instance, string message)
        {
            if (!(instance is TType))
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}