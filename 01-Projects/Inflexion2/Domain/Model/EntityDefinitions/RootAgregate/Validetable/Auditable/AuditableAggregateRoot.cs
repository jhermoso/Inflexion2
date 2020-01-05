

namespace Inflexion2.Domain
{
    using Inflexion2.Domain.Validation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// http://msdn.microsoft.com/en-us/magazine/hh547108.aspx
    /// any aggregate root is an entity wich is the root for any write operation in the repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    public abstract class AuditableAggregateRoot<TEntity, TIdentifier> : AuditableEntity<TEntity, TIdentifier>, IAggregateRoot<TEntity, TIdentifier>, IEntity<TIdentifier>
        where TEntity : AuditableAggregateRoot<TEntity, TIdentifier>, System.IEquatable<TEntity>, System.IComparable<TEntity>
        where TIdentifier : System.IEquatable<TIdentifier>, System.IComparable<TIdentifier>
    {
        
        /// <summary>
        /// .es esta propiedad indica si podemos o no salvar el agregado
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
        
        virtual public bool CanBeSaved()
        {
            // comprobamos si tiene settings 
            // si no tiene settings devolvemos invocamos miramos si tiene validación o si es validable
            // si no tiene metodo metodo de validación devolvemos true
            // 
            // si tiene settings tenemos las siguientes posibilidades.
            // true -siempre grabamos - esto es util para cqrs o determinados repositorios.
            // false si tiene validador depende del validador
            if (this.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IValidatable<>)))
            {
                Type callType = this.GetType();

                object result = callType.InvokeMember("IsValid",
                                BindingFlags.InvokeMethod | BindingFlags.Public,
                                null, null, null);
                return (bool) result;
            }
            return true;

        }

        /// <summary>
        /// this method decide is is possible to delete / deactivate this entity
        /// </summary>
        /// <returns></returns>
        virtual public  Boolean CanBeDeleted()
        {
            // nos preguntamos si es transient
            //if (IsTransient()) return true;
            // nos preguntamos si tiene el atributo de borrado logico.// si no tiene dicho atributo podemos borrarlo en caso contrario no 
            // nos preguntamos si tiene el atributo de prohibido borrar

            // recorremos la lista de propiedades hijas provenientes de relaciones con otras entidades u objetos valor
            // nos preguntamos si se compone de entidades que no se pueden borrar
            // nos preguntamos si tiene borrado en cascada

            IEnumerable < PropertyInfo >  navigationProperties = this.GetType().GetProperties().Where(
                    p => Attribute.IsDefined(p, typeof(ChildrenRelationshipDeleteBehaviorAttribute), true));

            ChildrenRelationshipDeleteBehaviorAttribute myAttribute = null;
                
            foreach (PropertyInfo property in navigationProperties)
            {
                myAttribute = (ChildrenRelationshipDeleteBehaviorAttribute) Attribute.GetCustomAttribute(property, typeof(ChildrenRelationshipDeleteBehaviorAttribute));
                if (myAttribute.Behavior == Delete.Restrict)
                {
                    // si podemos obtener el elemenot 0 de una collección que tiene un primer elemento entonces
                    if (property.GetValue(this, new object[]{0}) != null)
                    return false;
                }
            }

            return true;
        }
       
        ///<summary>
        /// este metodo nos obliga a definir la entidad como un generico en el que se incluye como primer parametro la propia entidad
        /// este metodo necesita la refelxión sobre la clase que hereda y que queda marcada como root agregate.
        ///</summary>
        /// <returns></returns>
        virtual public bool IsLogicalDelete()
        {
            return typeof(AuditableAggregateRoot<TEntity, TIdentifier>).GetCustomAttributes(typeof(LogicalDeleteAttribute), true).Any(); 
        }
    }
}
