using System;

namespace Inflexion2.UX.WPF.MVVM.CRUD
{
    public interface IEntityViewModel<TIdentifier>
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        TIdentifier Id { get; set; }

        //bool Activo { get; set; } // TODO: incluir en nuevas interfaces para entidades detipo bussines.
    }
}
