using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inflexion2.Domain;


namespace NHexample
{
    interface IEntityARepository : IRepository<EntityA, int>
    {
    }
}
