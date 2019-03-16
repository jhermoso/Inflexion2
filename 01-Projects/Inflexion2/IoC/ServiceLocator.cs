//----------------------------------------------------------------------------------------------
// <copyright file="ServiceLocator.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2

{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Service Locator implementation
    /// </summary>
    public static class ServiceLocator
    {
        private static Action<Type, object> registerInstanceCallback;
        private static Action<Type, Type> registerTypeCallback;
        private static Func<Type, IEnumerable<object>> resolveAllCallback;
        private static Func<Type, object> resolveCallback;

        /// <summary>
        /// Get all the registeres instances
        /// </summary>
        /// <typeparam name="TDependency"></typeparam>
        /// <returns></returns>
        public static TDependency[] GetAllInstances<TDependency>()
        {
            IEnumerable<object> services = resolveAllCallback(typeof(TDependency));

            if (services != null)
            {
                return services.Cast<TDependency>().ToArray();
            }

            return default(TDependency[]);
        }

        /// <summary>
        /// Get one instance on function of the dependency
        /// </summary>
        /// <typeparam name="TDependency"></typeparam>
        /// <returns></returns>
        public static TDependency GetInstance<TDependency>()
        {
            return (TDependency)GetInstance(typeof(TDependency));
        }

        /// <summary>
        /// Get one instance on function of the dependency type in a parameter
        /// </summary>
        /// <param name="dependencyType"></param>
        /// <returns></returns>
        public static object GetInstance(Type dependencyType)
        {
            return resolveCallback(dependencyType);
        }

        /// <summary>
        /// .es Inicializa una nueva instancia de la clase <see cref="ServiceLocator"/>
        /// esto significa que este metodo es invocado al principio y se le pasan mediante
        /// expresiones lambda una serie de acciones y de funciones, es decir unos punteros a unos metodos anonimos.
        /// utilizando action y func
        /// .en Initializes a new instance of the <see cref="ServiceLocator"/> class.
        /// this means this method is called in the begining and their parameters are lambda expresions for methods.
        /// </summary>
        /// <example>
        ///             ServiceLocator.Initialize(
        ///     (x, y) => this.unityContainer.RegisterType(x, y),
        ///     (x, y) => this.unityContainer.RegisterInstance(x, y),
        ///     (x) => { return this.unityContainer.Resolve(x); },
        ///     (x) => { return this.unityContainer.ResolveAll(x); });
        /// </example>
        public static void Initialize(
            Action<Type, Type> registerType,
            Action<Type, object> registerInstance,
            Func<Type, object> resolve,
            Func<Type, IEnumerable<object>> resolveAll)
        {
            registerTypeCallback = registerType;
            registerInstanceCallback = registerInstance;
            resolveCallback = resolve;
            resolveAllCallback = resolveAll;
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <param name="instance">The instance.</param>
        public static void RegisterInstance<I>(object instance)
        {
            if (registerInstanceCallback != null)
            {
                registerInstanceCallback(typeof(I), instance);
            }
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="instance">The instance.</param>
        public static void RegisterInstance(Type @type, object instance)
        {
            if (registerInstanceCallback != null)
            {
                registerInstanceCallback(@type, instance);
            }
        }

        /// <summary>
        /// Registers a service implementation.
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <typeparam name="T"></typeparam>
        public static void RegisterType<I, T>()
        where T : I
        {
            if (registerTypeCallback != null)
            {
                registerTypeCallback(typeof(I), typeof(T));
            }
        }

        /// <summary>
        /// Registers the type.
        /// </summary>
        /// <param name="interface">The @interface.</param>
        /// <param name="type">The type.</param>
        public static void RegisterType(Type @interface, Type @type)
        {
            if (registerTypeCallback != null)
            {
                registerTypeCallback(@interface, @type);
            }
        }


        /// <summary>
        /// Try to resolve a dependency
        /// </summary>
        /// <typeparam name="TDependency"></typeparam>
        /// <returns></returns>
        public static TDependency TryGetInstance<TDependency>()
        {
            try
            {
                IEnumerable<TDependency> services = GetAllInstances<TDependency>();

                if (services != null)
                {
                    return (TDependency)services.FirstOrDefault();
                }
            }
            catch (NullReferenceException)
            {
                throw new InternalException("ServiceLocator has not been initialized; " +
                                            "I was trying to retrieve " + typeof(TDependency));
            }

            return default(TDependency);
        }
    }
}