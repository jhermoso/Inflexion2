﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Enumeracion" company="Atento">
//     Copyright (c) 2016. Atento. All Rights Reserved.
//     Copyright (c) 2016. Atento. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " ApplicationEnumerationDtoCT.tt" with "public class ApplicationEnumerationDtoCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "ApplicationEnumerationDtoCT.tt" con "public class ApplicationEnumerationDtoCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Atento.Suite.Shared.Application.Dtos
{
    using System.Runtime.Serialization;
    using System.ComponentModel;

    /// <summary>
    /// 
    /// </summary>    
    [DataContract(Name = "Enumeracion")]
    public enum EnumeracionDto 
    {
    
        //
        //Valor1 = 0
        [EnumMember] // los valores que no sea precedidos por estos atributos no pueden serializarse.
        Valor1 = 0

    } // Enumeracion

} // Atento.Suite.Shared.Application.Dtos
