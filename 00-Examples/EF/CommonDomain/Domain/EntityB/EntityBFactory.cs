using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
    /// <summary>
    /// Clase factoría para la creación de  una entidad de tipo <see cref="ICategoria"/>.
    /// </summary>
    public static class EntityBFactory
    {
        #region Constructor vacio de la clase
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CategoriaFactory"/>.
        /// </summary>
        /// <remarks>
        /// Constructor vacío de la clase <see cref="CategoriaFactory"/>.
        /// </remarks>
        /// <returns>
        /// Devuelve una instancia de dela clase CategoriaFactory />
        /// </returns>
        static EntityBFactory()
        {
        }
        #endregion

        #region Método (Patrón Factory)
        /// <summary>
        /// Función para crear una entidad dentro de la factoría a partir 
        /// de los argumentos especificados.
        /// </summary>
        /// <remarks>
        /// Crea una entidad de tipo <see cref="ICategoria"/>
        /// </remarks>
        /// <param name="nombre"> 
        /// 
        /// </param>
        /// <returns>
        /// Devuelve  una entidad de tipo <see cref="ICategoriaFactory"/>
        /// </returns>
        public static EntityB Create(string nombre)
        {
            // El Id viene dado cuando se inserte en la BBDD... de momento tiene uno temporal.

            // Creamos la nueva entidad.
            EntityB entityB = new EntityB(nombre);
            //devolvemos la entidad recien creada
            return entityB;
        }

        #endregion
    }
}
