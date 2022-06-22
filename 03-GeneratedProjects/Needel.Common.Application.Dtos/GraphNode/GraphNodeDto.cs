﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="GraphNode" company="Company">
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
    /// Clase que representa a la entidad <see cref="GraphNodeDto"/>.
    /// </summary>
    /// <remarks>
    /// Crea un objeto <see cref="GraphNodeDto"/>.
    /// </remarks>
    // no tiene subclases
    // no tiene superclases
    [DataContract]
    public  class GraphNodeDto : BaseEntityDataTransferObject<Int32> 
    {
        #region CONSTRUCTORS
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GraphNodeDto"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="GraphNodeDto"/>.
        /// </remarks>
        public GraphNodeDto()
        {
            this.RightNodes = new System.Collections.Generic.List<GraphNodeDto>();
            this.LeftNodes = new System.Collections.Generic.List<GraphNodeDto>();
        } // GraphNodeDto Constructor

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Variable privada que identifica Name.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [DataMember]
        public string Name {get; set;}

        // Este campo proviene de una relación de tipo  y Asociación
        /// <summary>
        /// Propiedad que almacena el valor de LeftNodes.
        /// </summary>
        /// <remarks>
        /// Propiedad proveniente del rol source de una relación.
        /// </remarks>
        [DataMember]
       public System.Collections.Generic.List<GraphNodeDto> LeftNodes {get; set;} /*from sources*/


        /// <summary>
        /// Campo privado para almacenar la colección de  RightNodes.
        /// </summary>
        /// <remarks>
        /// Nos permite establecer y obtener RightNodes.
        /// Propiedad proveniente del rol target de una relación.
        /// </remarks>
        [DataMember]
        public System.Collections.Generic.List<GraphNodeDto> RightNodes {get; set;}/*from targets*/
        #endregion

        #region Actual IClonable implementation

        /// <summary>
        /// Actual IClonable implementation to help the IEditableObject Implementation 
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            var obj = new GraphNodeDto();
            obj.Id = this.Id;
            obj.Name = this.Name;

            //Parents from sources
            if (this.LeftNodes != null && this.LeftNodes.Count > 0)
            {
                obj.LeftNodes = new System.Collections.Generic.List<GraphNodeDto>();
                foreach (var item in this.LeftNodes)
                {
                    obj.LeftNodes.Add((GraphNodeDto)item.Clone());
                }                
            }

            //Children from targets
            if (this.RightNodes != null && this.RightNodes.Count > 0)
            {
                obj.RightNodes = new System.Collections.Generic.List<GraphNodeDto>();
                foreach (var item in this.RightNodes)
                {
                    obj.RightNodes.Add((GraphNodeDto)item.Clone());
                }                
            }

            return obj;
        }
        #endregion

    } // end class GraphNodeDto
} //  Needel.Common.Application.Dtos
