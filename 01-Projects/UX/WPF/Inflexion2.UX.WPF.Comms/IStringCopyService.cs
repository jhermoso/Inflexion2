using System;

namespace Inflexion2.UX.WPF.Comms
{
    /// <summary>
    /// Interface común para el intercambio de datos entre dos módulos usando un servicio
    /// basado en un evento.
    /// Declaramos una interface con un evento cuyo delegado es Action y cuyo "evenst args" es string
    /// </summary>
    public interface IStringCopyService
    {
        event Action<string> CopyStringEvent;

        void Copy(string str);
    }
}
