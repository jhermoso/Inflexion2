using System;

namespace Inflexion2.UX.WPF.MVVM.CRUD
{
    /// <summary>
    /// Interface base para los viewmodels de entidades
    /// </summary>
    /// <typeparam name="TIdentifier"></typeparam>
    public interface IEntityViewModel<TIdentifier>
    where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        /// <summary>
        /// Identificador de la entidad
        /// </summary>
        TIdentifier Id { get; set; }

        //bool Activo { get; set; } // TODO: incluir en nuevas interfaces para entidades detipo bussines.
    }
}
