using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Inflexion2.Domain;
using Inflexion2.Application.DataTransfer.Core;
using EFApplication.Dtos;

namespace EFApplication.Services
{
    /// <summary>
    ///  Define el contrato para los servicios de administración de la entidad 
    ///  con todos los metodos que se hayan definido para esta clase asi como los 
    ///  que tienen que ver con la persistencia
    /// de tipo <see cref="EFExampleWCF.Aplication.IEntityA"/>.
    /// </summary>
    interface IEntityAServices
    {
        #region methods crud
        /// <summary>
        /// Función encargada de la creación de una entidad de tipo IEntityA.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="entity1Dto">
        /// Parámetro de tipo <see cref="Entity1Dto"> con los datos necesarios
        /// para la creación de la entidad Entity1.
        /// </param>
        /// <param name="userContextDto"> 
        /// Parámetro de tipo <see cref="UserContextDto"/> que representa el contexto del usuario.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Lanzada cuando el valor de alguno de los argumentos de entrada es <b>null</b>.
        /// </exception>
        /// <returns>
        /// Devuelve el identificador único de la entidad creada.
        /// </returns>
        Int32 Create(EntityADto entityADto);

        //Int32 Create(EntityADto entityADto, UserContextDto userContextDto);// invocacion con identificación de usuario

        /// <summary>
        /// Función encargada del borrado de una entidad de tipo Entity1.
        /// </summary>
        /// <remarks>
        /// Se trata de un borrado lógico.
        /// </remarks>
        /// <param name="Entity1Id">
        /// Parámetro que indica el identificador único de la entidad.
        /// </param>
        /// <param name="userContextDto">
        /// Parámetro de tipo <see cref="UserContextDto"/> que representa el contexto del usuario.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Lanzada cuando el valor del argumento de entrada <c>userContextDto<c> es <b>null</b>.
        /// </exception>
        /// <returns>
        /// Devuelve <b>True</b> si la eliminación ha sido correcta y
        /// <b>False</b> en caso contrario.
        /// </returns>
        bool Delete(Int32 Entity1Id);
        //bool Delete(Int32 Entity1Id, UserContextDto userContextDto);// invocacion con identificación de usuario

        /// <summary>
        /// Función encargada de obtener todas las entidades de tipo IEntity1.
        /// </summary>
        /// <remarks>
        /// Devuelve la totalidad de las entidades.
        /// </remarks>
        /// <param name="userContextDto">
        /// Parámetro de tipo <see cref="UserContextDto"/> que representa el contexto del usuario.
        /// </param>
        /// <returns>
        /// Devuelve listado de Dto´s de tipo <see cref="Entity1Dto"/>.
        /// </returns>
        IEnumerable<EntityADto> GetAll();
        //IEnumerable<EntityADto> GetAll(UserContextDto userContextDto);// invocación con identificación de usuario

        /// <summary>
        /// Recupera una lista paginada de entidades Entity1, según la especificación indicada.
        /// </summary>
        /// <param name="specificationDto">
        /// Especificación que se va a aplicar.
        /// </param>
        /// <param name="userContextDto">
        /// Información de contexto del usuario.
        /// </param>
        /// <returns>
        /// La lista paginada de entidades Entity1, según la especificación indicada.
        /// </returns>
        PagedElements<EntityADto> GetPaged(SpecificationDto specificationDto);
        //PagedElements<Entity1Dto> GetPaged(SpecificationDto specificationDto, UserContextDto userContextDto);

        /// <summary>
        /// Función encargada de obtener una entidad IEntityA de acuerdo a
        /// su identificador.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="entity1Id">
        /// Parámetro que indica el identificador único de la entidad.
        /// </param>
        /// <param name="userContextDto">
        /// Parámetro de tipo <see cref="UserContextDto"/> que representa el contexto del usuario.
        /// </param>
        /// <returns>
        /// Devuelve objeto Dto <see cref="Entity1Dto"/> con la información requerida.
        /// </returns>
        EntityADto GetById(Int32 entityAId);
        //EntityADto GetById(Int32 entityAId, UserContextDto userContextDto);

        /// <summary>
        /// Actualiza una determinada entidad Entity1.
        /// </summary>
        /// <param name="entity1Dto">
        /// DTO que contiene la información de la entidad que se va a actualizar.
        /// </param>
        /// <param name="userContextDto">
        /// Información de contexto del usuario.
        /// </param>
        /// <returns>
        /// Es <b>true</b> si la actualización ha sido correcta; en caso contrario <b>false</b>.
        /// </returns>
        bool Update(EntityADto entity1Dto);
        //bool Update(EntityADto entity1Dto, UserContextDto userContextDto);
        #endregion

        #region methods entity
        #endregion
    }
}
