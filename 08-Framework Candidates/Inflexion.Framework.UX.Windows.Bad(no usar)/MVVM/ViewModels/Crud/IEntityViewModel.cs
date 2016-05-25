using System;

namespace Inflexion.Framework.UX.Windows.MVVM.CRUD
{
    public interface IEntityViewModel
    {
        int Id { get; set; }

        bool Activo { get; set; }
    }
}
