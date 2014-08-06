//----------------------------------------------------------------------------------------------
// <copyright file="PrivateReflectionDynamicObjectExtensions.cs" company="HexaSystems Inc">
// Copyright (c) HexaSystems Inc. Licensed under the Apache License, Version 2.0 (the "License")
// </copyright>
//-----------------------------------------------------------------------------------------------

namespace Inflexion2.DynamicExtensions
{
    /// <summary>
    /// .es extension de refelxion para objetos dinamicos 
    /// .en reflexion extension to dinamic objects
    /// </summary>
    public static class PrivateReflectionDynamicObjectExtensions
    {

        public static dynamic AsDynamic(this object o)
        {
            return PrivateReflectionDynamicObject.WrapObjectIfNeeded(o);
        }
    }
}