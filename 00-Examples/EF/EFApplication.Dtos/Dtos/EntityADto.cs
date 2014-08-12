using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Inflexion2.Application.DataTransfer.Base;

namespace EFApplication.Dtos
{
    public class EntityADto : BaseEntityDataTransferObject<int> 
    {

        public EntityADto ()
        {}

        public string Name { get; set; }

        /// <summary>
        /// la relación con EntitieofB es de agregación luego no pertenece al agregado.
        /// por esta razón solo incluimos su id y el resultado de to string que debe tener la info mas relevante de la entidad 
        /// agregada
        /// </summary>
        public List<int> EntitiesofB { get; set; }

        /// <summary>
        /// La relación con EntitiesOfC es de composición luego si pertenece al agregado por esta razón incluimos su dto.
        /// </summary>
        public List<EntityCDto> EntitiesofC { get; set; }

        // cuando la cardinalidad maxima de la relación es a uno incluimos todos su datos independientemente de si es agrgación o composición.
  
    }
}
