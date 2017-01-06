using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLocalizationExtensionDemoApplication.Models
{
    public class FlagLanguage
    {
        string ImageUrl = AppDomain.CurrentDomain.BaseDirectory + "Images\\";
        string Flag { get; set; }
        string Language { get; set; }

        public FlagLanguage()
        {

        }
        public FlagLanguage( string flagName, string languageName)
        {
            this.Flag = ImageUrl + flagName;
            this.Language = languageName;
        }
    }
}
