using Caliburn.Micro;
using WPFLocalizationExtensionDemoApplication.ViewModels.Examples;
using WPFLocalizationExtensionDemoApplication.Models;
using System.Windows.Controls;
using System.Collections.Generic;
using WPFLocalizeExtension.Engine;
using System.Linq;

namespace WPFLocalizationExtensionDemoApplication.ViewModels
{
    public class MainViewModel : Conductor<Screen>.Collection.OneActive
    {
        public List<FlagLanguage> FlagsAndLanguages { get; set; }

        public MainViewModel()
        {
            this.Items.Add(new GapTextWpfExampleViewModel());
            this.Items.Add(new TextLocalizationExampleViewModel());

            //FlagsAndLanguages = LocalizeDictionary.Instance.MergedAvailableCultures.Select(c => new FlagLanguage() { c.TwoLetterISOLanguageName.ToString(), c.EnglishName });
           // Banderas = LocalizeDictionary.Instance.MergedAvailableCultures.Select(c => "/Images/" + c.TwoLetterISOLanguageName + ".png");
        }
    }
}