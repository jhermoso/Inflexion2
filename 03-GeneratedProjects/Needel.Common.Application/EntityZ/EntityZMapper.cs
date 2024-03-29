﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="EntityZ" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " ApplicationEntityMapperCT.tt" with "public class ApplicationEntityMapperCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "ApplicationEntityMapperCT.tt" con "public class ApplicationEntityMapperCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.Application
{

    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Inflexion2;

    using Needel.Common.Application.Dtos;
    using Needel.Common.Domain;
    #endregion

    /// <summary>
    /// .en mapping class from Entity to dto <see cref="EntityZMapper"/>
    /// .es Clase pública encargada de mapear los datos de una entidad <see cref="EntityZMapper"/>.
    /// </summary>
    public class EntityZMapper : IEntityZMapper
    {
        #region Fields parent mappers
        #endregion

        #region Fields children mappers
        private Needel.Common.Application.IMNZMapper mNZDtoMapper;
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// .en Get an instance of <see cref="EntityZMapper"/>
        /// .es Inicializa una nueva instancia de la clase <see cref="EntityZMapper"/>.
        /// </summary>
        public EntityZMapper()
        {
        }
        #endregion

        #region Properties parent mappers
        #endregion

        #region Properties children mappers
        /// <summary>
        /// Mapper for Children
        /// </summary>
        protected Needel.Common.Application.IMNZMapper MNZDtoMapper
        {
            get
            {
                if (mNZDtoMapper == null) mNZDtoMapper = new MNZMapper();
                return mNZDtoMapper;
            }
        }

        #endregion

        #region FUNCTIONS
        /// <summary>
        /// Default constructor parameters
        /// </summary>
        /// <param name="entityEntityZ"></param>
        /// <returns></returns>
        public EntityZDto EntityMapping(EntityZ entityEntityZ)
        {
            if (entityEntityZ == null)
            {
                return null;
            }

            return EntityMapping(entityEntityZ, true, false);
        }

        /// <summary>
        /// .en public function mapping from Entity to dto
        /// </summary>
        /// <param name="entityEntityZ">
        /// </param>
        /// <param name="mapParents">
        /// .en option to map parent objects
        /// </param>
        /// <param name="mapChildren">
        /// .en option to map children objects
        /// </param>
        /// <returns>
        /// .en returns an DTO of type <see cref="EntityZDto"/>
        /// </returns>
        public EntityZDto EntityMapping(EntityZ entityEntityZ, bool mapParents , bool mapChildren)
        {
            if (entityEntityZ == null)
            {
                return null;
            }

            EntityZDto dtoEntityZ = new EntityZDto();
            dtoEntityZ.Id = entityEntityZ.Id;
            dtoEntityZ.Name = entityEntityZ.Name;

            if (mapChildren)
            {
                if (entityEntityZ.MNs != null)
                {
                    foreach (var item in entityEntityZ.MNs)
                    {
                        var childDto = MNZDtoMapper.ValueObjectMapping(item, false, false);
                        if (childDto != null)
                        {
                            dtoEntityZ.MNs.Add(childDto);
                        }
                    }
                }

            }

            return dtoEntityZ;
        } // EntityMapping
        #endregion
    } // end class EntityZMapper
} //  Needel.Common.Application
