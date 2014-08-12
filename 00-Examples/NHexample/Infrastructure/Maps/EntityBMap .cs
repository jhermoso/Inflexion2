//----------------------------------------------------------------------------------------------
// <copyright file="EntityBMap.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace NHexample
{
    using Inflexion2.Domain;


    public class EntityBMap : EntityMap<EntityB,int>
    {
        public EntityBMap()
        {
            Map(h => h.Name);

            HasManyToMany(h => h.EntitiesofA )
            .Access.CamelCaseField()
            .Table("EntityA_EntityB")
            .ParentKeyColumn("EntityBUniqueId")
            .ChildKeyColumn("EntityAUniqueId");
        }
    }
}