using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inflexion2.Domain.Data
{
    /// <summary>
    /// .es Esta enumeración se usa para indicar como se ha de rellenar un combobox de entidades parentales. 
    /// Por esta razón simpre se usa como parametro en combinación con un parametro de tipo "Id".
    /// </summary>
    [Flags]
    public enum EnumPopulationType
    {
        /// <summary>
        /// .es Opción para indicar que se han de cargar todas las entidades parentales.
        /// Esta es la opción por defecto.
        /// </summary>
        All = 1,

        /// <summary>
        /// .es Opción para indicar que se han de cargar todas las entidades parentales excepto la indicada.
        /// </summary>
        AllExceptOwnId = 2,

        /// <summary>
        /// .es Opción para indicar que se han de cargar todas las entidades parentales excepto la indicada y los hijos. Esta opcion solo es valida cuando es una relacion reflexiva donde los padres son del mismo tipo que los hijos.
        /// </summary>
        AllExceptOwnIdAndChildren = 4,

        /// <summary>
        ///  .es Opción para indicar que se han de cargar exclusivamente la indicada en el id. 
        /// </summary>
        OnlyId = 8,

        /// <summary>
        /// .es Opción para indicar que despues de cargar la selección hay que añadir una opción al combobox para añadir una opción vacia.
        /// Esto nos proporciona la posibilidad de borrar la relación parental (si la relación de es de agregación no de composición)
        /// </summary>
        AddNullOrNoneOption = 16,

        /// <summary>
        /// .es Opción para cargar de forma paginada. en este caso se necesitara un segundo parametro que indique que página.
        /// </summary>
        Paged = 32

         
    }
}
