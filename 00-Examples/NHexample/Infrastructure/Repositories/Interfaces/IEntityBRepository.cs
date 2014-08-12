using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Inflexion2.Domain;
namespace NHexample
{
    interface IEntityBRepository : IRepository<EntityB, int>
    {
    }
}
