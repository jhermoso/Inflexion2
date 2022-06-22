﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Component" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " ApplicationEntityDtoCT.tt" with "public class ApplicationEntityDtoCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "ApplicationEntityDtoCT.tt" con "public class ApplicationEntityDtoCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.Application.Dtos
{

    #region SharedKernel usings
    #endregion

    #region usings
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Inflexion2.Application;//.DataTransfer.Base;

    using Needel.Common.Domain.Data;

    using System.Collections.ObjectModel;
    #endregion

    /// <summary>
    /// Clase que representa a la entidad <see cref="ComponentDto"/>.
    /// </summary>
    /// <remarks>
    /// Crea un objeto <see cref="ComponentDto"/>.
    /// </remarks>
    // no tiene subclases
    // no tiene superclases
    [DataContract]
    public  class ComponentDto : BaseEntityDataTransferObject<Int32> 
    {
        #region CONSTRUCTORS
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ComponentDto"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="ComponentDto"/>.
        /// </remarks>
        public ComponentDto()
        {
            this.Children = new System.Collections.Generic.List<ComponentDto>();
        } // ComponentDto Constructor

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Variable privada que identifica Name.
        /// </summary>
        /// <remarks>
        /// Name of component
        /// </remarks>
        [DataMember]
        public string Name {get; set;}

        /// <summary>
        /// Variable privada que identifica PartNumber.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [DataMember]
        public string PartNumber {get; set;}

        /// <summary>
        /// Variable privada que identifica Description.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [DataMember]
        public string Description {get; set;}

        // Este campo proviene de una relación de tipo Agregación y Asociación
        /// <summary>
        /// Propiedad que almacena el valor de Parent.
        /// </summary>
        /// <remarks>
        /// Propiedad proveniente del rol source de una relación.
        /// </remarks>
        [DataMember]
        public ComponentDto Parent {get; set;} /*entity from source asociation, target rol*/

        /// <summary>
        /// Campo privado para almacenar la colección de  Children.
        /// </summary>
        /// <remarks>
        /// Nos permite establecer y obtener Children.
        /// Propiedad proveniente del rol target de una relación.
        /// </remarks>
        [DataMember]
        public System.Collections.Generic.List<ComponentDto> Children {get; set;}/*from targets*/
        #endregion

        #region Actual IClonable implementation

        /// <summary>
        /// Actual IClonable implementation to help the IEditableObject Implementation 
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var obj = new ComponentDto();
            obj.Id = this.Id;
            obj.Name = this.Name;
            obj.PartNumber = this.PartNumber;
            obj.Description = this.Description;

            //Parents from sources
            obj.Parent = (this.Parent != null) ? (ComponentDto)this.Parent.Clone() : null;

            //Children from targets
            if (this.Children != null && this.Children.Count > 0)
            {
                obj.Children = new System.Collections.Generic.List<ComponentDto>();
                foreach (var item in this.Children)
                {
                    obj.Children.Add((ComponentDto)item.Clone());
                }                
            }

            return obj;
        }
        #endregion

    } // end class ComponentDto
} //  Needel.Common.Application.Dtos
