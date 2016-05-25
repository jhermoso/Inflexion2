using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inflexion.Framework.UX.WPF.ModuleA
{

    /// <summary>
    /// Esta es la razón por la cual la interface para la comunicación entre dos modulos se encuentra en un ensamblado diferente
    /// y es que cada modulo puede incorporar y registrar su propia implementación para un mismo sistema de comunicación.
    /// aunque esta clase támbien podria declarase dentor del proyecto del shell si varios modulo comparten un misma implementación
    ///  o dentro del modulo comun 
    /// </summary>
    class StringCopyServiceImpl : Inflexion.Framework.UX.WPF.Comms.IStringCopyService //implementamos los miembors de la interface
    {
        #region IStringCopyService Members

        public event Action<string> CopyStringEvent;

        public void Copy(string str)
        {
            if (CopyStringEvent != null)
                CopyStringEvent(str);
        }

        #endregion
    }
}
