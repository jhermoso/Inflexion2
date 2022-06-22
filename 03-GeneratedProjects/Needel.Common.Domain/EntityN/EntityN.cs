﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="EntityN" company="Company">
//     Copyright (c) 2020. Company. All Rights Reserved.
//     Copyright (c) 2020. Company. Todos los derechos reservados.
//
//     .en This code has been generated by a tool, please don't modify this file or  
//     you will lost all your modifications in the next regeneration.
//      The original t4 template to get this file is " DomainBaseEntityCT.tt" with "public class DomainBaseEntityCT : Template"
// 
//     .es Este código ha sido generado por una herramienta, por favor no modifique este fichero
//     o perdera las modificaciones al regenerar este fichero.
//      La plantilla con que se ha generado este fichero es "DomainBaseEntityCT.tt" con "public class DomainBaseEntityCT : Template"
//
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace Needel.Common.Domain
{

    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Needel.Common.Domain.Data;
    using Needel.Common.Infrastructure.Resources;
    using Inflexion2;
    using Inflexion2.Domain;

    using System.ComponentModel.DataAnnotations;
    #endregion

    /// <summary>
    /// <see cref="EntityN"/>
    /// </summary>
    [System.Runtime.InteropServices.Guid("8e14d329-51ba-4532-9351-2a2002f17b9d")]
    [Serializable]
    public partial class EntityN : Inflexion2.Domain.AggregateRoot<EntityN, Int32>, IEntityN , IEquatable<EntityN>, IComparable<EntityN>
    {

        #region Campos y constantes
        // Este campo proviene de una relación de tipo Composición y Asociación
        /// <summary>
        /// Campo privado para almacenar la colección de  mZs.
        /// </summary>
        /// <remarks>
        /// campo privado proveniente de una relación mZs.
        /// La relación es una Asociación  de tipo Composición 
        /// </remarks>
        private System.Collections.Generic.List<MNZ> mZs; 
        #endregion

        #region Constructors

        /// <summary>
        /// .en Empty Constructor for the class <see cref="EntityN"/> it is required by nHibernate and EntityFramework.
        /// .es Constructor vacio de la clase <see cref="EntityN"/> exigido por nHibernate o EntityFramework.
        /// </summary>
        /// <remarks>
        /// .en by convention the empty constructor initialize the default values and make the news for the collections.
        /// .es por convenicón el constructor vacio inizializa los valores por defecto y hace los news de las colecciones.
        /// </remarks>
        protected internal EntityN()                
        {
            this.SetMZs(new System.Collections.Generic.List<MNZ>());
        } // end empty constructor EntityN

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EntityN"/>.
        /// con un constructor parametrizado con los campos de tipo mandatory.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="EntityN"/>.
        /// </remarks>
        /// <param name="name"> 
        /// Parametro <see cref="EntityN.Name"/> del constructor de campos mandatory de la clase <see cref="EntityN"/>
        /// Propiedad deducida del rol source de una relación
        /// </param>
        protected internal EntityN( string name ) :  this()  //cbc.isDerivedFromOneEntity ='False', IsDerived(cbc.entitySuperClass ) = ''
        {
            // .en the mandatory fields are inserted like parameters in the constructor.
            // If there are any property which are collections from realtionship here  
            // is where insert the news o their injection.
            // Also is included the default values for the properties which has one.

            // .es Aqui introducimos los campos mandatory que intervienen en el constructor
            // si tiene atributos que son collecciones derivadas de relacionaes aqui es 
            // donde tenemos que hacer los news de dichas colecciones o su inyección.
            // También debemos incluir aquellos campos que tienen un valor por defecto.
            this.Name = name;


        }// Constructor
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad pública que permite obtener Name.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener Name.
        /// </value>
        [Required(ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource), 
                  ErrorMessageResourceName = "FieldIsMandatory" )]
        public virtual string Name 
            {
                get;
                set;
            }

        #endregion

        #region Propiedades procedentes de los roles de tipo 'target' en una asociación

        /// <summary>
        /// Propiedad pública que provine de una relación (Target) y permite establecer y obtener la coleción de valores MZs.
        /// </summary>
        /// <remarks>
        /// Nos permite establecer y obtener MZs.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener MZs.
        /// </value>
        [ChildrenRelationshipDeleteBehavior(Delete.Restrict)]
        public virtual System.Collections.Generic.List<MNZ> MZs 
        { 
            get
            {
                // Si es null, lo instanciamos y devolvemos, sino, solo lo devolvemos
                return this.mZs ?? (this.mZs = new System.Collections.Generic.List<MNZ>() );
            }
        }
        #endregion

        #region Métodos Set de propiedades comunes
        #endregion

        #region Métodos Set, Add y Remove de propiedades procedentes de los roles de tipo target en una asociación

        /// <summary>
        /// Método encargado de establecer la propiedad de MZs en la entidad MNZ.
        /// El MNZ ha de existir previamente.
        /// Permite introducir un valor nulo a la colección.
        /// </summary>
        /// <param name="mNZCollection "> 
        /// Parametro con el que se proporciona la colección <see cref="MNZ"/> a asociar. El valor de este paramentro puede ser null para borrar la relación.
        /// </param>
        /// <returns>
        /// Devuelve 'this' ( la propia entidad) de tipo <see cref="EntityN"/> para permitir fluent Interfaces/>
        /// </returns>
        public virtual EntityN SetMZs ( System.Collections.Generic.List<MNZ> mNZCollection )
        {
            this.mZs = (System.Collections.Generic.List<MNZ>)mNZCollection ;
            return this;
        }

        /// <summary>
        /// Método encargado de añadir un elemento a la colección MZs en la entidad MNZ.
        /// El MNZ ha de existir previamente.
        /// </summary>
        /// <param name="mNZCollection "> 
        /// Parametro con el que se proporciona la colección MNZ a asociar. El valor de este paramentro puede ser null para borrar la relación si es de agregación o asociación.
        /// </param>
        /// <returns>
        /// Devuelve 'this' ( la propia entidad) de tipo <see cref="EntityN"/> para permitir fluent Interfaces/>
        /// </returns>
        public virtual IEntityN AddMNZToMZs ( MNZ mNZ )
        {
            Guard.ArgumentIsNotNull(mNZ, "El parametro mNZ es null");          // comprobamos que el parametro no es nulo. Resources
            // se permiten valores repetidos en esta propiedad
            // observar que estamos utilizando el acceso al campo y no a la propiedad, 
            // esto se debe a que se debe utilizar a nivel de propiedades colecciones 
            // que no publiquen operaciones sobre las mismas y asi utilizar las colecciones de los campos.
            this.mZs.Add( mNZ ); 

            mNZ.SetEntityN(this); // Relación bidereccional: es necesario establecer el valor en el rol opuesto.
            return this;
        }

        /// <summary>
        /// Método encargado de eliminar un elemento de la colección MZs en la entidad MNZ.
        /// El MNZ ha de existir previamente.
        /// </summary>
        /// <param name="mNZCollection "> 
        /// Identificador a borrar MNZ a asociar. El valor de este paramentro puede ser null para borrar la relación si es de agregación o asociación.
        /// </param>
        /// <returns>
        /// Devuelve 'this' ( la propia entidad) de tipo <see cref="EntityN"/> para permitir fluent Interfaces/>
        /// </returns>
        public virtual IEntityN RemoveMNZFromMZs ( MNZ mNZ )
        {
            Guard.ArgumentIsNotNull(mNZ, "El parametro mNZ es null");          // comprobamos que el parametro no es nulo. Resources
            // observar que estamos utilizando el acceso al campo y no a la propiedad, 
            // esto se debe a que se debe utilizar a nivel de propiedades colecciones que 
            // no publiquen operaciones sobre las mismas y de esta forma se obliga a utilizar los métodos proporcionados
            this.mZs.Remove( mNZ );
                mNZ.SetEntityN(null);
            return this;
        }
        #endregion


    #region IEquatable implementation

        /// <summary>
        /// IEquatable implementation
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(IEntityN other)
        {
            return base.Equals(other);
        }

    #endregion

    #region IComparable implementation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual int CompareTo(IEntityN other)
        {
            // todo: move to code contract
            if (other == null)
            {
                throw new System.ArgumentNullException("EntityN");
            }

            int result = 0;
            result = this.Name.CompareTo(other.Name);
            if (result != 0) return result;

            return result;
        }	

    #endregion

    } // class EntityN 
} //  Needel.Common.Domain
