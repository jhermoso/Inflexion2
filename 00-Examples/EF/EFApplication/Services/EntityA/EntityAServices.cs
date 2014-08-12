using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Inflexion2.Domain;
using Inflexion2.Application.DataTransfer.Core;
using Inflexion2.Application.Core;
//using EFexample;
using EFApplication.Dtos;

namespace EFApplication.Services
{
    public partial class EntityAServices : IEntityAServices // para implementar seguridad, hacer derivar de ApplicationServiceBase
    {
        #region methods crud

        //Int32 Create(EntityADto entityADto, UserContextDto userContextDto);// invocacion con identificación de usuario
        public Int32 Create(EntityADto entityADto)
        {
            throw new System.NotImplementedException();
        }

        //bool Delete(Int32 Entity1Id, UserContextDto userContextDto);// invocacion con identificación de usuario
        public bool Delete(Int32 Entity1Id)
        {
            throw new System.NotImplementedException();
        }

        //IEnumerable<EntityADto> GetAll(UserContextDto userContextDto);// invocación con identificación de usuario
        public IEnumerable<EntityADto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        //PagedElements<Entity1Dto> GetPaged(SpecificationDto specificationDto, UserContextDto userContextDto);
        public PagedElements<EntityADto> GetPaged(SpecificationDto specificationDto)
        {
            throw new System.NotImplementedException();
        }

        //EntityADto GetById(Int32 entityAId, UserContextDto userContextDto);
        public EntityADto GetById(Int32 entityAId)
        {
            throw new System.NotImplementedException();
        }


        //bool Update(EntityADto entity1Dto, UserContextDto userContextDto);
        public bool Update(EntityADto entity1Dto)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region methods entity
        #endregion
    }
}
