//----------------------------------------------------------------------------------------------
// <copyright file="UnitOfWorkScope.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------
namespace Inflexion2.Domain
{
    /// <summary>
    /// El objeto de esta clase es evitar la necesidad de pasar como parametro la unidad de trabajo en el repositorio.
    /// </summary>
    public class UnitOfWorkScope
    {
        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <returns></returns>
        public static IUnitOfWork Start()
        {
            return Start<IUnitOfWork>();
        }

        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <typeparam name="TUnitOfWork"></typeparam>
        /// <returns></returns>
        public static IUnitOfWork Start<TUnitOfWork>()
        where TUnitOfWork : IUnitOfWork
        {
            IUnitOfWork unitOfWork = ServiceLocator.GetInstance<TUnitOfWork>();
            return unitOfWork;
        }
    }
}