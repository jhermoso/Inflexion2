using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Inflexion2.Application.Core;
using EFexample;
using CommonDomain;
using EFApplication.Dtos;

namespace EFApplication.Mappers
{
    public interface IEntityBMapper : IDataEntityMapper<EntityBDto, IEntityB, Int32>
    {
    }
}
