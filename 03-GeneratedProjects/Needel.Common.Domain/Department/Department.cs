﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Department" company="Company">
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
    /// <see cref="Department"/>
    /// </summary>
    [System.Runtime.InteropServices.Guid("91b853da-6d06-4b80-b354-74a5094994be")]
    [Serializable]
    public partial class Department : Inflexion2.Domain.AggregateRoot<Department, Int32>, IDepartment , IEquatable<Department>, IComparable<Department>
    {

        #region Campos y constantes
        /// <summary>
        /// Variable privada que identifica Name.
        /// Name of the department.
        /// </summary>
        /// <remarks>
        /// Please introduce here the name o identifcation of the department.
        /// </remarks>
        private string name; 

        /// <summary>
        /// Variable privada que identifica Visible.
        /// visibility mark
        /// </summary>
        /// <remarks>
        /// use this field to deactivate/activate this deparment.
        /// </remarks>
        private bool visible; 

        // Este campo proviene de una relación de tipo Agregación y Asociación
        /// <summary>
        /// Campo privado para almacenar la colección de  users.
        /// </summary>
        /// <remarks>
        /// campo privado proveniente de una relación users.
        /// La relación es una Asociación  de tipo Agregación 
        /// </remarks>
        private System.Collections.Generic.List<User> users; 
        #endregion

        #region Constructors

        /// <summary>
        /// .en Empty Constructor for the class <see cref="Department"/> it is required by nHibernate and EntityFramework.
        /// .es Constructor vacio de la clase <see cref="Department"/> exigido por nHibernate o EntityFramework.
        /// </summary>
        /// <remarks>
        /// .en by convention the empty constructor initialize the default values and make the news for the collections.
        /// .es por convenicón el constructor vacio inizializa los valores por defecto y hace los news de las colecciones.
        /// </remarks>
        protected internal Department()                
        {
            this.SetUsers(new System.Collections.Generic.List<User>());
        } // end empty constructor Department

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Department"/>.
        /// con un constructor parametrizado con los campos de tipo mandatory.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="Department"/>.
        /// </remarks>
        /// <param name="name"> 
        /// Parametro <see cref="Department.Name"/> del constructor de campos mandatory de la clase <see cref="Department"/>
        /// Propiedad deducida del rol source de una relación
        /// </param>
        /// <param name="visible"> 
        /// Parametro <see cref="Department.Visible"/> del constructor de campos mandatory de la clase <see cref="Department"/>
        /// Propiedad deducida del rol source de una relación
        /// </param>
        /// <param name="creationTime"> 
        /// Parametro <see cref="Department.CreationTime"/> del constructor de campos mandatory de la clase <see cref="Department"/>
        /// Propiedad deducida del rol source de una relación
        /// </param>
        protected internal Department( string name, bool visible = true, DateTime? creationTime = null ) :  this()  //cbc.isDerivedFromOneEntity ='False', IsDerived(cbc.entitySuperClass ) = ''
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
            this.Visible = visible;
            if (!creationTime.HasValue)
            {
                this.CreationTime = DateTime.Now;
            }
            else
            {
                this.CreationTime = (DateTime)creationTime;
            }

            // comienzan las asignaciones de los campos por defecto no mandatory. No confundir con campos derivados cya calculo es fijo.


        }// Constructor
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad públicacon set privado que permite obtener Name.
        /// </summary>
        /// <remarks>
        /// Name of the department.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener Name.
        /// </value>
        [Required(ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource), 
                  ErrorMessageResourceName = "FieldIsMandatory" )]
        public virtual string Name 
            {
                get  
                {
                    return this.name;
                }
                set
                {

                    this.name = value;
                }
            }


        /// <summary>
        /// Propiedad públicacon set privado que permite obtener Visible.
        /// </summary>
        /// <remarks>
        /// visibility mark
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener Visible.
        /// </value>
        [Required(ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource), 
                  ErrorMessageResourceName = "FieldIsMandatory" )]
        public virtual bool Visible 
            {
                get  
                {
                    return this.visible;
                }
                set
                {

                    this.visible = value;
                }
            }


        /// <summary>
        /// Propiedad pública que permite obtener Description.
        /// </summary>
        /// <remarks>
        /// Allow to the user to explain what is the responsabilities or functions of the department.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener Description.
        /// </value>
        public virtual string Description 
            {
                get;
                set;
            }


        /// <summary>
        /// Propiedad pública que permite obtener CreationTime.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener CreationTime.
        /// </value>
        [Required(ErrorMessageResourceType = typeof(Inflexion2.Resources.FrameworkResource), 
                  ErrorMessageResourceName = "FieldIsMandatory" )]
        public virtual DateTime CreationTime 
            {
                get;
                set;
            }


        /// <summary>
        /// Propiedad pública que permite obtener UpdateTime.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener UpdateTime.
        /// </value>
        public virtual DateTime? UpdateTime 
            {
                get;
                set;
            }

        #endregion

        #region Propiedades procedentes de los roles de tipo 'target' en una asociación

        /// <summary>
        /// Propiedad pública que provine de una relación (Target) y permite establecer y obtener la coleción de valores Users.
        /// </summary>
        /// <remarks>
        /// Nos permite establecer y obtener Users.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener Users.
        /// </value>
        [ChildrenRelationshipDeleteBehavior(Delete.Restrict)]
        public virtual System.Collections.Generic.List<User> Users 
        { 
            get
            {
                // Si es null, lo instanciamos y devolvemos, sino, solo lo devolvemos
                return this.users ?? (this.users = new System.Collections.Generic.List<User>() );
            }
        }
        #endregion

        #region Métodos Set de propiedades comunes
        #endregion

        #region Métodos Set, Add y Remove de propiedades procedentes de los roles de tipo target en una asociación

        /// <summary>
        /// Método encargado de establecer la propiedad de Users en la entidad User.
        /// El User ha de existir previamente.
        /// Permite introducir un valor nulo a la colección.
        /// </summary>
        /// <param name="userCollection "> 
        /// Parametro con el que se proporciona la colección <see cref="User"/> a asociar. El valor de este paramentro puede ser null para borrar la relación.
        /// </param>
        /// <returns>
        /// Devuelve 'this' ( la propia entidad) de tipo <see cref="Department"/> para permitir fluent Interfaces/>
        /// </returns>
        public virtual Department SetUsers ( System.Collections.Generic.List<User> userCollection )
        {
            this.users = (System.Collections.Generic.List<User>)userCollection ;
            return this;
        }

        /// <summary>
        /// Método encargado de añadir un elemento a la colección Users en la entidad User.
        /// El User ha de existir previamente.
        /// </summary>
        /// <param name="userCollection "> 
        /// Parametro con el que se proporciona la colección User a asociar. El valor de este paramentro puede ser null para borrar la relación si es de agregación o asociación.
        /// </param>
        /// <returns>
        /// Devuelve 'this' ( la propia entidad) de tipo <see cref="Department"/> para permitir fluent Interfaces/>
        /// </returns>
        public virtual IDepartment AddUserToUsers ( User user )
        {
            Guard.ArgumentIsNotNull(user, "El parametro user es null");          // comprobamos que el parametro no es nulo. Resources
            // se permiten valores repetidos en esta propiedad
            // observar que estamos utilizando el acceso al campo y no a la propiedad, 
            // esto se debe a que se debe utilizar a nivel de propiedades colecciones 
            // que no publiquen operaciones sobre las mismas y asi utilizar las colecciones de los campos.
            this.users.Add( user ); 

            user.SetUserDepartment(this); // Relación bidereccional: es necesario establecer el valor en el rol opuesto.
            return this;
        }

        /// <summary>
        /// Método encargado de eliminar un elemento de la colección Users en la entidad User.
        /// El User ha de existir previamente.
        /// </summary>
        /// <param name="userCollection "> 
        /// Identificador a borrar User a asociar. El valor de este paramentro puede ser null para borrar la relación si es de agregación o asociación.
        /// </param>
        /// <returns>
        /// Devuelve 'this' ( la propia entidad) de tipo <see cref="Department"/> para permitir fluent Interfaces/>
        /// </returns>
        public virtual IDepartment RemoveUserFromUsers ( User user )
        {
            Guard.ArgumentIsNotNull(user, "El parametro user es null");          // comprobamos que el parametro no es nulo. Resources
            // observar que estamos utilizando el acceso al campo y no a la propiedad, 
            // esto se debe a que se debe utilizar a nivel de propiedades colecciones que 
            // no publiquen operaciones sobre las mismas y de esta forma se obliga a utilizar los métodos proporcionados
            this.users.Remove( user );
                user.SetUserDepartment(null);
            return this;
        }
        #endregion


    #region IEquatable implementation

        /// <summary>
        /// IEquatable implementation
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(IDepartment other)
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
        public virtual int CompareTo(IDepartment other)
        {
            // todo: move to code contract
            if (other == null)
            {
                throw new System.ArgumentNullException("Department");
            }

            int result = 0;
            result = this.Name.CompareTo(other.Name);
            if (result != 0) return result;

            return result;
        }	

    #endregion

    } // class Department 
} //  Needel.Common.Domain
