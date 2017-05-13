//----------------------------------------------------------------------------------------------
// <copyright file="Log4NetManager.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Logging
{
    using System;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Web;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// common adapter for the implementation class.
    /// </summary>
    public class Log4NetManager
    {
        private static bool initialized;

        /// <summary>
        /// initialize the log4net instance
        /// </summary>
        public static void Initialize()
        {
            Log4NetManager.Initialize(null);
        }

        /// <summary>
        /// initialize the log4net instance with a config file
        /// </summary>
        /// <param name="configFile"></param>
        public static void Initialize(FileInfo configFile)
        {
            if (!Log4NetManager.initialized)
            {
                if (configFile != null)
                {
                    XmlConfigurator.ConfigureAndWatch(configFile);
                }
                else
                {
                    XmlConfigurator.Configure();
                }

                // Register log4net context loggers..
                if (Log4NetManager.IsWebContext())
                {
                    GlobalContext.Properties["UserHostAddress"] = new UserHostAddressLogContext();
                    GlobalContext.Properties["User"] = new UserLogContext();
                    GlobalContext.Properties["SessionId"] = new UserSessionIdLogContext();
                }

                Log4NetManager.initialized = true;
            }
        }

        /// <summary>
        /// request of log instances by type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILogger Create(Type type)
        {
            return new Log4NetLogger(type);
        }


        /// <summary>
        /// request of log instances
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public ILogger Create(string typeName)
        {
            return new Log4NetLogger(typeName);
        }

        private static bool IsWebContext()
        {
            if (HttpContext.Current != null)
            {
                return true;
            }

            if (OperationContext.Current != null)
            {
                return true;
            }

            return false;
        }

        private class UserHostAddressLogContext
        {
            public override string ToString()
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.Request != null)
                    {
                        return HttpContext.Current.Request.UserHostAddress;
                    }

                    OperationContext context = OperationContext.Current;
                    if (context != null && context.IncomingMessageProperties != null &&
                        context.IncomingMessageProperties.ContainsKey(RemoteEndpointMessageProperty.Name))
                    {
                        var endpointProperty =
                            context.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as
                            RemoteEndpointMessageProperty;
                        return endpointProperty.Address;
                    }

                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }

        private class UserLogContext
        {
            public override string ToString()
            {
                try
                {
                    if (HttpContext.Current == null)
                    {
                        return null;
                    }

                    if (HttpContext.Current.User == null)
                    {
                        return null;
                    }

                    if (HttpContext.Current.User.Identity == null)
                    {
                        return null;
                    }

                    return HttpContext.Current.User.Identity.Name;
                }
                catch
                {
                    return null;
                }
            }
        }

        private class UserSessionIdLogContext
        {
            public override string ToString()
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.Request != null &&
                        HttpContext.Current.Session != null)
                    {
                        return HttpContext.Current.Session.SessionID;
                    }

                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}