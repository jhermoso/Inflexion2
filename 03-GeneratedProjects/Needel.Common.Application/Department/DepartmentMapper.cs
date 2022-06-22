﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Department" company="Company">
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
    /// .en mapping class from Entity to dto <see cref="DepartmentMapper"/>
    /// .es Clase pública encargada de mapear los datos de una entidad <see cref="DepartmentMapper"/>.
    /// </summary>
    public class DepartmentMapper : IDepartmentMapper
    {
        #region Fields parent mappers
        #endregion

        #region Fields children mappers
        private Needel.Common.Application.IUserMapper userDtoMapper;
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// .en Get an instance of <see cref="DepartmentMapper"/>
        /// .es Inicializa una nueva instancia de la clase <see cref="DepartmentMapper"/>.
        /// </summary>
        public DepartmentMapper()
        {
        }
        #endregion

        #region Properties parent mappers
        #endregion

        #region Properties children mappers
        /// <summary>
        /// Mapper for Children
        /// </summary>
        protected Needel.Common.Application.IUserMapper UserDtoMapper
        {
            get
            {
                if (userDtoMapper == null) userDtoMapper = new UserMapper();
                return userDtoMapper;
            }
        }

        #endregion

        #region FUNCTIONS
        /// <summary>
        /// Default constructor parameters
        /// </summary>
        /// <param name="entityDepartment"></param>
        /// <returns></returns>
        public DepartmentDto EntityMapping(Department entityDepartment)
        {
            if (entityDepartment == null)
            {
                return null;
            }

            return EntityMapping(entityDepartment, true, false);
        }

        /// <summary>
        /// .en public function mapping from Entity to dto
        /// </summary>
        /// <param name="entityDepartment">
        /// </param>
        /// <param name="mapParents">
        /// .en option to map parent objects
        /// </param>
        /// <param name="mapChildren">
        /// .en option to map children objects
        /// </param>
        /// <returns>
        /// .en returns an DTO of type <see cref="DepartmentDto"/>
        /// </returns>
        public DepartmentDto EntityMapping(Department entityDepartment, bool mapParents , bool mapChildren)
        {
            if (entityDepartment == null)
            {
                return null;
            }

            DepartmentDto dtoDepartment = new DepartmentDto();
            dtoDepartment.Id = entityDepartment.Id;
            dtoDepartment.Name = entityDepartment.Name;
            dtoDepartment.Visible = entityDepartment.Visible;
            dtoDepartment.Description = entityDepartment.Description;
            dtoDepartment.CreationTime = entityDepartment.CreationTime;
            dtoDepartment.UpdateTime = entityDepartment.UpdateTime;

            if (mapChildren)
            {
                if (entityDepartment.Users != null)
                {
                    foreach (var item in entityDepartment.Users)
                    {
                        var childDto = UserDtoMapper.EntityMapping(item, false, false);
                        if (childDto != null)
                        {
                            dtoDepartment.Users.Add(childDto);
                        }
                    }
                }

            }

            return dtoDepartment;
        } // EntityMapping
        #endregion
    } // end class DepartmentMapper
} //  Needel.Common.Application