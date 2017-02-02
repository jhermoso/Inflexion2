

namespace Inflexion2.Domain
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/magazine/hh547108.aspx
    /// any aggregate root is an entity wich is the root for any write operation in the repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    public interface IAggregateRoot<TEntity, TIdentifier> : IEntity<TIdentifier>
        where TEntity : IAggregateRoot<TEntity, TIdentifier>, IEntity<TIdentifier>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {

        /// <summary>
        /// .es estos metodos indican si podemos o no salvar el agregado
        /// por norma general esto dependera de si se cumplen  los invariantes o no
        /// o por el contrario si hemos de salvarla incluso aunque no cumplan dichos invariantes.
        /// no son virtuales por que estas propiedaes no se guardan solo se consultan en memoria
        /// igualmente no existe una implementación de rootaggregate sino que actua como marcador.
        /// la funcion puede establecerse mediante la recuperación de los settings para esta clase
        /// es decir como una preferencia del administrador para la clase. Esta preferencia indicaria si esta clase puede grabarse sin cumplir las validaciones o si por el contrario depende de las validaciones.
        /// de forma similar se puede indicar si se permite borrar o solo desactivar.
        /// Si el setting no existe la clase podra grabarse  no en funcion de su metodo de validación. si la entidad no es validable entonces la propiedad devuelve true.
        /// .en this property indicate if is it posible to save the root agregate.
        /// in the original this has not set but for CQRS is posible to save with out complmete the invariants
        /// </summary>
        bool CanBeSaved();

        /// <summary>
        /// .es al invocar este metodo indicamos si es posible borrar a nivel de dominio la entidad que se ha solicitado borrar.
        /// nada tiene que ver con las necesidades de borrado del repositorio que puedne ser completamente diferentes.
        /// por ejemplo en una relación m:n podemos marcar que el borrado introduce un valor nulo en los hijos borrando las entidades del rootagregate
        /// esta acción borrara o no ademas los registros de la tabla intermedia pero esa responsabilidad es del orm.
        /// </summary>
        /// <returns>devolvemos un valor true si la respuesta es que si podemos borrar y false en caso contrario</returns>
        bool CanBeDeleted();


        /// <summary>
        /// para aquellas entidades de tipo business el borrado puede marcarse como logico y tendran un campo que indicara si la 
        /// entidad esta activa o no.
        /// </summary>
        /// <returns>devolvemos true si el root aggragte esta marcado como de borrado logico </returns>
        bool IsLogicalDelete();

    }
}
