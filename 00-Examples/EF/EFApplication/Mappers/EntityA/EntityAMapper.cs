using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2;
using Inflexion2.Domain;
using Inflexion2.Resources;
using EFexample;
using EFApplication.Dtos;

using CommonDomain;

namespace EFApplication.Mappers
{
    class EntityAMapper : IEntityAMapper
    {
        public EntityAMapper()
        { 
        }

        public EntityADto EntityMapping(IEntityA entityA)//
        {
            // Comprobamos el parámetro de entrada.
            Guard.ArgumentIsNotNull(
                                    entityA,
                                    string.Format(
                                                    Inflexion2.Resources.Framework.MapperErrorEntityNull,
                                                    "Entity A") // usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.CategoriaAlias
                                                 );

            EntityADto entityADto = new EntityADto();
            // propiedades
            entityADto.Id = entityA.Id;
            entityADto.Name = entityA.Name;

            // composiciones
            entityADto.EntitiesofC = new List<EntityCDto>();
            var entityCMapper = new EntityCMapper();
            foreach (IEntityC entity in entityA.EntitiesofC)
            {
                var entityDto = entityCMapper.EntityMapping(entity);
                entityADto.EntitiesofC.Add(entityDto);
            }

            // agregados
            entityADto.EntitiesofB = new List<int>();
            foreach (var entity in entityA.EntitiesofB)
            {
                var Tidentifier = entity.Id; 
                entityADto.EntitiesofB.Add(Tidentifier);
            }

            // Devolvemos el resultado.
            return entityADto;

        } // EntityMapping


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityADto"></param>
        /// <returns></returns>
        public IEntityA DataMapping(EntityADto entityADto)
        {
            throw new System.NotImplementedException();
        }
    }
}
