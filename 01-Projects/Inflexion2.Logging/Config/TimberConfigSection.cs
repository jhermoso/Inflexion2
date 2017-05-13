//----------------------------------------------------------------------------------------------
// Derivative work based on https://github.com/cocowalla/Timber
// Copyright (c) Timber. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.Logging.Config
{
    using System.Configuration;

    public class LoggingSection : ConfigurationSection
    {
        [ConfigurationProperty("factory", IsRequired = true, IsKey = false)]
        public FactoryElement Factory
        {
            get { return (FactoryElement)base["factory"]; }
        }
    }
}
