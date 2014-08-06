
using Microsoft.Practices.Prism.Commands; // este namespace necesita del ensamblado presentation core para poder implementar la interface ICommand

namespace Inflexion2.UX.WPF.Common.GlobalCommands
{
    public static class LoadModuleBView2globalCommand
    {
        public static CompositeCommand Loadview2Comando = new CompositeCommand();
    }

    public class LoadModuleBView2globalCommandProxy
    {
        public virtual CompositeCommand Loadview2Comando
        {
            get
            {
                return LoadModuleBView2globalCommand.Loadview2Comando;
            }
        }
    }
}
