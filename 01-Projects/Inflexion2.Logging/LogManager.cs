//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using Inflexion2.Logging.Config;

    /// <summary>
    /// Provides <see cref="ILogger"/> instances. Note that the <see cref="GetLogger()"/> methods
    /// will never return null - if configuration is invalid they will return a <see cref="NullLogger"/> 
    /// instance
    /// 
    /// Can be configured by either code or configuration:
    /// 
    /// Code:
    ///   Call <see cref="InitialiseLoggerFactory{T}"/>, specified an <see cref="ILoggerFactory"/> as type parameter
    /// 
    /// Configuration:
    ///   Set 'type' attribute of 'factory' element to the full type name of an <see cref="ILoggerFactory"/>
    ///   See samples for an example
    /// </summary>
    public static class LogManager
    {
        private static Lazy<ILoggerFactory> loggerFactory = new Lazy<ILoggerFactory>(InitialiseLoggerFactory);

        /// <summary>
        /// Get the logger factory used to generate <see cref="ILogger"/> instances
        /// </summary>
        public static ILoggerFactory LoggerFactory
        {
            get { return loggerFactory.Value; }
        }

        /// <summary>
        /// Set the logger factory programmatically
        /// </summary>
        /// <typeparam name="T">Type of logger factory to use</typeparam>
        public static void InitialiseLoggerFactory<T>() where T : ILoggerFactory, new()
        {
            loggerFactory = new Lazy<ILoggerFactory>(() => Activator.CreateInstance<T>());
            Trace.WriteLine("Using {0}", typeof(T).FullName);
        }

        /// <summary>
        /// Set the logger factory from configuration file (i.e. app.config or web.config)
        /// </summary>
        /// <remarks>
        /// NullLogFactory will be used if a factory was not found or could not be loaded
        /// </remarks>
        /// <returns>Logger factory instance</returns>
        private static ILoggerFactory InitialiseLoggerFactory()
        {
            var config = ConfigurationManager.GetSection("Inflexion2.Logging") as LoggingSection;

            if (config == null)
            {
                Trace.WriteLine("Logging config section 'LoggingSection' not found");
                return UseDefaultLoggerFactory();
            }

            var factoryType = Type.GetType(config.Factory.Type);

            if (factoryType == null)
            {
                Trace.WriteLine("Inflexion2.Logging config element 'factory' not found");
                return UseDefaultLoggerFactory();
            }

            var factory = Activator.CreateInstance(factoryType) as ILoggerFactory;

            if (factory == null)
            {
                Trace.WriteLine("Unable to instantiate factory {0} - does it implement ILoggerFactory?", 
                    factoryType.FullName);
                return UseDefaultLoggerFactory();
            }

            Trace.WriteLine("Using {0} from config file", factoryType.FullName);
            return factory;
        }

        /// <summary>
        /// Returns the default logger factory <see cref="NullLoggerFactory"/>
        /// </summary>
        /// <returns>Instance of <see cref="NullLoggerFactory"/></returns>
        private static ILoggerFactory UseDefaultLoggerFactory()
        {
            var defaultFactory = new NullLoggerFactory();
            Trace.WriteLine("Using default log factory {0}", defaultFactory.GetType().FullName);
            return defaultFactory;
        }

        /// <summary>
        /// Gets a logger from the configured <see cref="ILoggerFactory"/> for the calling class
        /// </summary>
        /// <returns>Logger instance from the configured <see cref="ILoggerFactory"/></returns>
        public static ILogger GetLogger()
        {
            // Get the type that called this method 
            var frame = new StackFrame(1, false);
            Type declaringType = frame.GetMethod().DeclaringType;

            return loggerFactory.Value.GetLogger(declaringType);
        }

        /// <summary>
        /// Gets a logger from the configured <see cref="ILoggerFactory"/> using the specified type
        /// </summary>
        /// <typeparam name="T">Type of the requested logger</typeparam>
        /// <returns>Logger instance from the configured <see cref="ILoggerFactory"/></returns>
        public static ILogger GetLogger<T>()
        {
            return loggerFactory.Value.GetLogger(typeof(T));
        }

        /// <summary>
        /// Gets a logger from the configured <see cref="ILoggerFactory"/> using the specified type
        /// </summary>
        /// <param name="type">
        /// Type of the requested logger. If null, <see cref="ILoggerFactory"/> for the calling class 
        /// will be returned instead
        /// </param>
        /// <returns>Logger instance from the configured <see cref="ILoggerFactory"/></returns>
        public static ILogger GetLogger(Type type)
        {
            if (type == null)
            {
                return GetLogger();
            }

            return loggerFactory.Value.GetLogger(type);
        }

        /// <summary>
        /// Gets a logger from the configured <see cref="ILoggerFactory"/> using the specified name
        /// </summary>
        /// <param name="name">
        /// Name of the requested logger. If null, <see cref="ILoggerFactory"/> for the calling class 
        /// will be returned instead
        /// </param>
        /// <returns>Logger instance from the configured <see cref="ILoggerFactory"/></returns>
        public static ILogger GetLogger(string name)
        {
            if (name == null)
            {
                return GetLogger();
            }

            return loggerFactory.Value.GetLogger(name);
        }
    }
}
