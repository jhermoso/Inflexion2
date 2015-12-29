using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using EFexample;
using Inflexion2;

using CommonDomain;
using EFApplication.Dtos;

namespace EFApplication.Mappers
{
    class EntityBMapper: IEntityBMapper
    {
        public EntityBMapper()
        { }

        public EntityBDto EntityMapping(IEntityB entityB)
        {
            // Comprobamos el parámetro de entrada.
            Guard.ArgumentIsNotNull(
                                    entityB,
                                    string.Format(
                                                    Inflexion2.Resources.Framework.MapperErrorEntityNull,
                                                    "Entity B") // usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.CategoriaAlias
                                                 );

            EntityBDto entityBDto = new EntityBDto();

            entityBDto.Id = entityB.Id;
            entityBDto.Name = entityB.Name;

            // Devolvemos el resultado.
            return entityBDto;

        } // EntityMapping

        /// <summary>
        /// Metodo encargado de obtener una nueva entidad a partir de la información de un Dto 
        /// L
        /// </summary>
        /// <param name="entityBDto"></param>
        /// <returns></returns>
        public IEntityB DataMapping(EntityBDto entityBDto)
        {
            // Comprobamos el parámetro de entrada.
            Guard.ArgumentIsNotNull(
                                    entityBDto,
                                    string.Format(
                                                    Inflexion2.Resources.Framework.MapperErrorEntityNull,
                                                    "Entity B DTo") // usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.CategoriaAlias
                                                 );
            Guard.ArgumentIsNotNull(
                                    entityBDto.Name,
                                    string.Format(
                                                    Inflexion2.Resources.Framework.PropertyRequired,
                                                    "Name","Entity B DTo") // usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.CategoriaAlias
                                                 );

            IEntityB entityB = EntityBFactory.Create(entityBDto.Name);
            
            return entityB;
        }

    }
}
