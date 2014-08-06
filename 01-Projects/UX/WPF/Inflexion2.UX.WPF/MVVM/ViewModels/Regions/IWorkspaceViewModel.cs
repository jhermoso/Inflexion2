using System;
namespace Inflexion2.UX.WPF.MVVM.ViewModels.Regions
{
    public interface IWorkspaceViewModel
    {
        string Title { get; }
        bool IsBusy { get; set; }
    }
}
