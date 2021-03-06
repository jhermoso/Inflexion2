﻿#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Component" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " InfraestructureEntityRepositoryCT.tt" with "public class InfraestructureEntityRepositoryCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "InfraestructureEntityRepositoryCT.tt" con "public class InfraestructureEntityRepositoryCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.Infrastructure
{

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Inflexion2;
    using Inflexion2.Domain;
    using Needel.Common.Domain;
    using Needel.Common.Domain.Data;
    using System.Data.Entity;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Clase pública repositorio para persistir y 
    /// obtener información a partir de entidades <see cref="Component"/>.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public partial class ComponentRepository : EFRepository<Component,Int32>, IComponentRepository
    {

        #region constructors
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ComponentRepository"/>.
        /// </summary>
        /// <remarks>
        /// el constructor ha de ser publico para poder ser resuelto por unity.
        /// </remarks>
        /// <param name="dbContext">
        /// Parámetro de tipo <see cref="DbContext"/> que hace referencia 
        /// a la unidad de trabajo para el acceso a datos.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Lanzada cuando el valor del parámetro <c>dbContext</c> es null.
        /// </exception>
        public ComponentRepository(DbContext dbContext) : base(dbContext) 
        {
        } // ComponentRepository Constructor
        #endregion


        #region Getting for Self reference hierarchical entyties
        /// <summary>
        /// this getting action is to populate combobox entities avoiding self reference chidren an roots 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// only for selfrelationships
        /// </remarks>
        public IEnumerable<Component> GetAllExceptIdAndChildren(Int32 id)
        {
            this.logger_.Debug(string.Format(CultureInfo.InvariantCulture, "Get all entities except {0} with Id {1}.", typeof(Component).Name, id));
            var childrenIds = this.Query().Where(c => c.Parent.Id.Equals(id)).Select(c =>c.Id).ToArray();
            var result = this.Query().Where(c => !c.Id.Equals(id) && !childrenIds.Contains(c.Id)).ToList();
            return result;
        }
        #endregion
    } // Component

} // Needel.Common.Infrastructure
