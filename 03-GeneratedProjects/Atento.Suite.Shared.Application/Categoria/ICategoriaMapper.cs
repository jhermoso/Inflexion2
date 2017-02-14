﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Categoria" company="Atento">
//     Copyright (c) 2017. Atento. All Rights Reserved.
//     Copyright (c) 2017. Atento. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " ApplicationEntityMapperInterfaceCT.tt" with "public class ApplicationEntityMapperInterfaceCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "ApplicationEntityMapperInterfaceCT.tt" con "public class ApplicationEntityMapperInterfaceCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Atento.Suite.Shared.Application
{

    using System;
    using System.Runtime.Serialization;
    using Inflexion2.Application;//.Core;
    using Atento.Suite.Shared.Application.Dtos;
    using Atento.Suite.Shared.Domain;

    /// <summary>
    /// Clase pública encargada de mapear los datos de una entidad <see cref="CategoriaMapper"/>.
    /// </summary>
    /// <remarks>
    /// Mapea los datos del Dto <see cref="CategoriaDto"/> con una entidad <see cref="CategoriaMapper"/>.
    /// </remarks>
    public interface ICategoriaMapper : IDataEntityMapper<CategoriaDto, ICategoria, Int32>
    {

    } // end class CategoriaMapper
} //  Atento.Suite.Shared.Application

