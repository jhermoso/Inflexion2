//----------------------------------------------------------------------------------------------
// <copyright file="PrivateReflectionDynamicObjectExtensions.cs" company="Inflexion2 Inc">
// Copyright (c) Inflexion2 Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.DynamicExtensions
{
    /// <summary>
    /// .es extension de reflexion para objetos dinámicos 
    /// .en reflexion extension to dinamic objects
    /// </summary>
    public static class PrivateReflectionDynamicObjectExtensions
    {
        /// <summary>
        /// TODO: update comments
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static dynamic AsDynamic(this object o)
        {
            return PrivateReflectionDynamicObject.WrapObjectIfNeeded(o);
        }
    }
}