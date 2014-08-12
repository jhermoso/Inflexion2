using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Inflexion2.Application.DataTransfer.Base;

namespace EFApplication.Dtos
{
    
    public class EntityBDto: BaseEntityDataTransferObject<int> 
    {

        public EntityBDto()
        {}
       
        public string Name { get; set; }
      
        public List<int> EntitiesofA { get; set; }


    }
}
