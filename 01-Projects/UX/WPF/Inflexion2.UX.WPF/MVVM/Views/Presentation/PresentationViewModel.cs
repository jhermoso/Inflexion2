using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inflexion2.UX.WPF.MVVM.ViewModels
{

    using Inflexion2.Resources;

    /// <summary>
    /// presentation view model
    /// </summary>
    public class PresentationViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public PresentationViewModel()
        {
            // https://github.com/SeriousM/WPFLocalizationExtension/issues/87#issuecomment-174510689
            // bind the property title of the VM to a dependecy property for the view. To allow the localization of the property tittle.
            // becouse this property don´t belong the clas UserControl who is the base for the view
            // but avalon dock uses this property to set the title of the dockable elements
            // if we wont tha this can be updated when the selected culture is changed we need this work arround.
            var targetProperty = this.GetType().GetProperty(nameof(this.Title));
            var locBinding = new WPFLocalizeExtension.Extensions.LocTextExtension("Inflexion2.Resources:FrameworkResource:Home");
            locBinding.SetBinding(this, targetProperty);

            // after to bind the property with the depdendecy property watch if theres is a change of the 
            // the culture to raise an event to warning that the title property has changed
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Culture")
                {
                    this.RaisePropertyChanged(() => Title);
                }
            };
        }

        /// <summary>
        /// .es Obtiene el título del user control.
        /// .en Gets the window's user control.
        /// </summary>
        public override string Title
        {
            get; set;
            //{
            //    return "Home";
            //}
        }
    }
}
