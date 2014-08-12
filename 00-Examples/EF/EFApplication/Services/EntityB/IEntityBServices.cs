using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Inflexion2.Domain;
using Inflexion2.Application.DataTransfer.Core;

using CommonDomain;
using EFApplication.Dtos;

namespace EFApplication.Services
{
    public interface IEntityBServices
    {
        #region methods crud

        int Create(EntityBDto entityADto);
        //Int32 Create(EntityADto entityADto, UserContextDto userContextDto);// invocacion con identificación de usuario

        bool Delete(Int32 Entity1Id);
        //bool Delete(Int32 Entity1Id, UserContextDto userContextDto);// invocacion con identificación de usuario

        IEnumerable<EntityBDto> GetAll();
        //IEnumerable<EntityADto> GetAll(UserContextDto userContextDto);// invocación con identificación de usuario

        PagedElements<EntityBDto> GetPaged(SpecificationDto specificationDto);
        //PagedElements<Entity1Dto> GetPaged(SpecificationDto specificationDto, UserContextDto userContextDto);

        EntityBDto GetById(Int32 entityAId);
        //EntityADto GetById(Int32 entityAId, UserContextDto userContextDto);


        bool Update(EntityBDto entity1Dto);
        //bool Update(EntityADto entity1Dto, UserContextDto userContextDto);
        #endregion

        #region methods entity
        #endregion
    }
}
