using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Inflexion2.Application.DataTransfer.Base;

namespace EFApplication.Dtos
{
    public class EntityCDto : BaseEntityDataTransferObject<int> 
    {
        
        public EntityCDto()
        {}

        public string Name { get; set; }

        public EntityADto FatherEntityA { get; set; }
    }
}
