using System;
namespace Inflexion.Framework.UX.Windows.MVVM.ViewModels.Regions
{
    public interface IWorkspaceViewModel
    {
        string Title { get; }
        bool IsBusy { get; set; }
    }
}
