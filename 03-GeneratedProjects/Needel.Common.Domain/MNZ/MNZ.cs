﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="MNZ" company="Company">
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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    #endregion

    /// <summary>
    /// <see cref="MNZ"/>
    /// </summary>
    [System.Runtime.InteropServices.Guid("305c82ec-dcb5-4379-b790-3827e864f864")]
    [Serializable]
    public partial class MNZ : Inflexion2.Domain.ValueObject<MNZ>, IMNZ , IEquatable<MNZ>, IComparable<MNZ>
    {

        #region Campos y constantes
        /// <summary>
        /// campo privado que almacena el valor de entityM.
        /// </summary>
        /// <remarks>
        /// campo privado proveniente de una relación entityM.
        /// La relación es de tipo Composición y Asociación
        /// </remarks>
        private EntityM entityM;
        /// <summary>
        /// campo privado que almacena el valor de entityN.
        /// </summary>
        /// <remarks>
        /// campo privado proveniente de una relación entityN.
        /// La relación es de tipo Composición y Asociación
        /// </remarks>
        private EntityN entityN;
        /// <summary>
        /// campo privado que almacena el valor de entityZ.
        /// </summary>
        /// <remarks>
        /// campo privado proveniente de una relación entityZ.
        /// La relación es de tipo Composición y Asociación
        /// </remarks>
        private EntityZ entityZ;
        #endregion

        #region Constructors

        /// <summary>
        /// .en Empty Constructor for the class <see cref="MNZ"/> it is required by nHibernate and EntityFramework.
        /// .es Constructor vacio de la clase <see cref="MNZ"/> exigido por nHibernate o EntityFramework.
        /// </summary>
        /// <remarks>
        /// .en by convention the empty constructor initialize the default values and make the news for the collections.
        /// .es por convenicón el constructor vacio inizializa los valores por defecto y hace los news de las colecciones.
        /// </remarks>
        protected internal MNZ()                
        {
        } // end empty constructor MNZ

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MNZ"/>.
        /// con un constructor parametrizado con los campos de tipo mandatory.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="MNZ"/>.
        /// </remarks>
        /// <param name="nZs">
        /// Parametro <see cref="MNZ.NZs"/> del constructor de campos mandatory de la clase <see cref="MNZ"/>
        /// Propiedad de unica instancia deducida del source rol source de una relación
        /// </param>
        /// <param name="mZs">
        /// Parametro <see cref="MNZ.MZs"/> del constructor de campos mandatory de la clase <see cref="MNZ"/>
        /// Propiedad de unica instancia deducida del source rol source de una relación
        /// </param>
        /// <param name="mNs">
        /// Parametro <see cref="MNZ.MNs"/> del constructor de campos mandatory de la clase <see cref="MNZ"/>
        /// Propiedad de unica instancia deducida del source rol source de una relación
        /// </param>
        internal MNZ( EntityM entityM, EntityN entityN, EntityZ entityZ)
        {
            // .en the mandatory fields are inserted like parameters in the constructor.
            // If there are any property which are collections from realtionship here  
            // is where insert the news o their injection.
            // Also is included the default values for the properties which has one.

            // .es Aqui introducimos los campos mandatory que intervienen en el constructor
            // si tiene atributos que son collecciones derivadas de relacionaes aqui es 
            // donde tenemos que hacer los news de dichas colecciones o su inyección.
            // También debemos incluir aquellos campos que tienen un valor por defecto.
            SetEntityM( entityM ); /*mandatoryPropertyFromSources*/
            SetEntityN( entityN ); /*mandatoryPropertyFromSources*/
            SetEntityZ( entityZ ); /*mandatoryPropertyFromSources*/


        }// Constructor
        #endregion

        #region Propiedades
        #endregion

        #region Propiedades procedentes de los roles de tipo 'source' en una asociación
        // Esta propiedad proviene de una relación de tipo Composición y Asociación Sources
        /// <summary>
        /// Propiedad pública que permite establecer y obtener EntityM.
        /// </summary>
        /// <value>
        /// Valor que es utilizado para establecer y obtener EntityM.
        /// </value>
        [Required(ErrorMessageResourceName = "FieldIsMandatory", ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource))]
        public virtual EntityM EntityM 
            {
                get 
                {
                    return this.entityM;
                }
                private set 
                {
                   this.entityM = value;
                }
            }


        /// <summary>
        /// field to help the mapping with the orm this object value
        /// </summary>
        [Required(ErrorMessageResourceName = "FieldIsMandatory", ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource))]
        public Int32 EntityM_Id { get; protected set;}

        // Esta propiedad proviene de una relación de tipo Composición y Asociación Sources
        /// <summary>
        /// Propiedad pública que permite establecer y obtener EntityN.
        /// </summary>
        /// <value>
        /// Valor que es utilizado para establecer y obtener EntityN.
        /// </value>
        [Required(ErrorMessageResourceName = "FieldIsMandatory", ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource))]
        public virtual EntityN EntityN 
            {
                get 
                {
                    return this.entityN;
                }
                private set 
                {
                   this.entityN = value;
                }
            }


        /// <summary>
        /// field to help the mapping with the orm this object value
        /// </summary>
        [Required(ErrorMessageResourceName = "FieldIsMandatory", ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource))]
        public Int32 EntityN_Id { get; protected set;}

        // Esta propiedad proviene de una relación de tipo Composición y Asociación Sources
        /// <summary>
        /// Propiedad pública que permite establecer y obtener EntityZ.
        /// </summary>
        /// <value>
        /// Valor que es utilizado para establecer y obtener EntityZ.
        /// </value>
        [Required(ErrorMessageResourceName = "FieldIsMandatory", ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource))]
        public virtual EntityZ EntityZ 
            {
                get 
                {
                    return this.entityZ;
                }
                private set 
                {
                   this.entityZ = value;
                }
            }


        /// <summary>
        /// field to help the mapping with the orm this object value
        /// </summary>
        [Required(ErrorMessageResourceName = "FieldIsMandatory", ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource))]
        public Int32 EntityZ_Id { get; protected set;}

        #endregion

        #region Métodos Set de propiedades comunes
        #endregion

        #region  Set methods properties from source roles

        /// <summary>
        /// .en Set method for the property EntityM.
        /// .es Método encargado de establecer un nuevo valor para la propiedad EntityM.
        /// </summary>
        /// <param name="entityM"> 
        /// Parametro con el que establecemos el nuevo valor de <see cref="EntityM"/>. de la clase <see cref="MNZ"/>
        /// </param>
        /// <returns>
        /// .en return value: the own object to allow fluent calls
        /// .es Devuelve el propio objeto para facilitar las interfaces 'fluent'/>
        /// </returns>
        public virtual MNZ SetEntityM ( EntityM entityM )
        {
            //Guard.ArgumentIsNotNull( entityM, "El parametro mNZ es null");          // si la multiplicidad minima es cero entonces puede ser null

            this.EntityM = entityM;
            this.EntityM_Id = entityM.Id;
            return this;
        }


        /// <summary>
        /// .en Set method for the property EntityN.
        /// .es Método encargado de establecer un nuevo valor para la propiedad EntityN.
        /// </summary>
        /// <param name="entityN"> 
        /// Parametro con el que establecemos el nuevo valor de <see cref="EntityN"/>. de la clase <see cref="MNZ"/>
        /// </param>
        /// <returns>
        /// .en return value: the own object to allow fluent calls
        /// .es Devuelve el propio objeto para facilitar las interfaces 'fluent'/>
        /// </returns>
        public virtual MNZ SetEntityN ( EntityN entityN )
        {
            //Guard.ArgumentIsNotNull( entityN, "El parametro mNZ es null");          // si la multiplicidad minima es cero entonces puede ser null

            this.EntityN = entityN;
            this.EntityN_Id = entityN.Id;
            return this;
        }


        /// <summary>
        /// .en Set method for the property EntityZ.
        /// .es Método encargado de establecer un nuevo valor para la propiedad EntityZ.
        /// </summary>
        /// <param name="entityZ"> 
        /// Parametro con el que establecemos el nuevo valor de <see cref="EntityZ"/>. de la clase <see cref="MNZ"/>
        /// </param>
        /// <returns>
        /// .en return value: the own object to allow fluent calls
        /// .es Devuelve el propio objeto para facilitar las interfaces 'fluent'/>
        /// </returns>
        public virtual MNZ SetEntityZ ( EntityZ entityZ )
        {
            //Guard.ArgumentIsNotNull( entityZ, "El parametro mNZ es null");          // si la multiplicidad minima es cero entonces puede ser null

            this.EntityZ = entityZ;
            this.EntityZ_Id = entityZ.Id;
            return this;
        }













        #endregion


    #region IEquatable implementation

        /// <summary>
        /// IEquatable implementation
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(IMNZ other)
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
        public virtual int CompareTo(MNZ other)
        {
            // todo: move to code contract
            if (other == null)
            {
                throw new System.ArgumentNullException("MNZ");
            }

            int result = 0;
            result = this.EntityM_Id.CompareTo(other.EntityM_Id);
            if (result != 0) return result;
            result = this.EntityN_Id.CompareTo(other.EntityN_Id);
            if (result != 0) return result;
            result = this.EntityZ_Id.CompareTo(other.EntityZ_Id);
            if (result != 0) return result;

            return result;
        }	

    #endregion

    } // class MNZ 
} //  Needel.Common.Domain

