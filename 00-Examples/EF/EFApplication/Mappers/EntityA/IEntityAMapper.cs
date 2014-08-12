

namespace EFApplication.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Inflexion2.Application.Core;
    using EFexample;

    using CommonDomain;
    using EFApplication.Dtos;

    public interface IEntityAMapper : IDataEntityMapper<EntityADto, IEntityA, Int32>
    {
    }
}
