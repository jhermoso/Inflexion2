//----------------------------------------------------------------------------------------------
// <copyright file="EntityAMap.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace NHexample
{
    using Inflexion2.Domain;



    public class EntityAMap : EntityMap<EntityA, int>
    {
        public EntityAMap()
        {
            Map(h => h.Name);

            HasManyToMany(h => h.EntitiesofB )
            .Access.CamelCaseField()
            .Table("EntityA_EntityB")
            .ParentKeyColumn("EntityAUniqueId")
            .ChildKeyColumn("EntityBUniqueId");
        }
    }
}