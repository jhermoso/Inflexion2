using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EFexample;
using Inflexion2;

using CommonDomain;
using EFApplication.Dtos;

namespace EFApplication.Mappers
{
    /// <summary>
    /// los metodos de esta clase solo son invocados desde el agregado al que pertenece.
    /// </summary>
    class EntityCMapper :  IEntityCMapper
    {
        public EntityCDto EntityMapping(IEntityC entityC)
        {
            // Comprobamos el parámetro de entrada.
            Guard.ArgumentIsNotNull(
                                    entityC,
                                    string.Format(
                                                    Inflexion2.Resources.Framework.MapperErrorEntityNull,
                                                    "Entity C") // usar un fichero de recursos para el dominio de negocio Company.Product.BoundedContext.Resources.Business.CategoriaAlias
                                                 );

            EntityCDto entityCDto = new EntityCDto();

            entityCDto.Id = entityC.Id;
            entityCDto.Name = entityC.Name;
            return entityCDto;
        }

        public IEntityC DataMapping(EntityCDto entityADto)
        {
            // este metodo o no se invoca o lo que hace es invocar a la factoria correspondiente.
            throw new System.NotImplementedException();
        }
    }
}
