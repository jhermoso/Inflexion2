using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;
using System.ComponentModel.DataAnnotations;

namespace CommonDomain
{

    public interface IEntityC : IEntity<int>
    {
        [Required]
        string Name { get; }

        [Required]
        EntityA FatherEntityA { get; }

    }


}
