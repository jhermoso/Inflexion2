//----------------------------------------------------------------------------------------------
// <copyright file="EntityARepository.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace NHexample
{
    using Inflexion2.Domain;
    using Inflexion2;
    using NHibernate;

    public class EntityANHRepository : NHRepository<EntityA, int>, IEntityARepository
    {
        public EntityANHRepository(ISession session)
        : base(session)
        {
        }
    }
}