using System;
namespace Inflexion2.UX.WPF.MVVM.ViewModels.Regions
{
    /// <summary>
    /// base class for work space view model
    /// </summary>
    public interface IWorkspaceViewModel
    {
        /// <summary>
        /// title of the work space
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// has focus
        /// </summary>
        bool IsBusy { get; set; }
    }
}
