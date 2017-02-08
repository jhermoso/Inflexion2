using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inflexion2.UX.WPF.MVVM.ViewModels
{

    /// <summary>
    /// presentation view model
    /// </summary>
    public class PresentationViewModel : WorkspaceViewModel
    {
        /// <summary>
        /// Obtiene el título de la ventana.
        /// </summary>
        public override string Title
        {
            get
            {
                return "Inicio";
            }
        }
    }
}
