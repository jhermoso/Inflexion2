using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inflexion2.UX.WPF.ItensoSettings
{
    using System.Windows;
    using Itenso.Configuration;
    class MainApplicationSettings : WindowsApplicationSettings
    {

        public MainApplicationSettings(Application application) :
			base( application, typeof(MainApplicationSettings) )
		{
            // example how to add a new application setting: step 1
            //Settings.Add(new PropertySetting(this, "HostName"));
        } 

        // step 2
        //public string HostName { get; set; }
    }
}
