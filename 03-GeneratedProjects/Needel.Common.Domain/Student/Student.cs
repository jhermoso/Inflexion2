﻿
#region Copyright info
//-----------------------------------------------------------------------
// <copyright file="Student" company="Company">
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
    /// <see cref="Student"/>
    /// </summary>
    [System.Runtime.InteropServices.Guid("aaab6bc2-267f-4042-8dd1-8432072357b0")]
    [Serializable]
    public partial class Student : Inflexion2.Domain.AggregateRoot<Student, Int32>, IStudent , IEquatable<Student>, IComparable<Student>
    {

        #region Campos y constantes
        // Este campo proviene de una relación de tipo  y Asociación
        /// <summary>
        /// Campo privado para almacenar la colección de  teachers.
        /// </summary>
        /// <remarks>
        /// campo privado proveniente de una relación teachers.
        /// La relación es una Asociación  
        /// </remarks>
        private System.Collections.Generic.List<Teacher> teachers; 
        #endregion

        #region Constructors

        /// <summary>
        /// .en Empty Constructor for the class <see cref="Student"/> it is required by nHibernate and EntityFramework.
        /// .es Constructor vacio de la clase <see cref="Student"/> exigido por nHibernate o EntityFramework.
        /// </summary>
        /// <remarks>
        /// .en by convention the empty constructor initialize the default values and make the news for the collections.
        /// .es por convenicón el constructor vacio inizializa los valores por defecto y hace los news de las colecciones.
        /// </remarks>
        protected internal Student()                
        {
            this.SetTeachers(new System.Collections.Generic.List<Teacher>());
        } // end empty constructor Student

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Student"/>.
        /// con un constructor parametrizado con los campos de tipo mandatory.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="Student"/>.
        /// </remarks>
        /// <param name="name"> 
        /// Parametro <see cref="Student.Name"/> del constructor de campos mandatory de la clase <see cref="Student"/>
        /// Propiedad deducida del rol source de una relación
        /// </param>
        protected internal Student( string name ) :  this()  //cbc.isDerivedFromOneEntity ='False', IsDerived(cbc.entitySuperClass ) = ''
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
        /// Propiedad pública que provine de una relación (Target) y permite establecer y obtener la coleción de valores Teachers.
        /// </summary>
        /// <remarks>
        /// Nos permite establecer y obtener Teachers.
        /// </remarks>
        /// <value>
        /// Valor que es utilizado para establecer y obtener Teachers.
        /// </value>
        public virtual System.Collections.Generic.List<Teacher> Teachers 
        { 
            get
            {
                // Si es null, lo instanciamos y devolvemos, sino, solo lo devolvemos
                return this.teachers ?? (this.teachers = new System.Collections.Generic.List<Teacher>() );
            }
        }
        #endregion

        #region Métodos Set de propiedades comunes
        #endregion

        #region Métodos Set, Add y Remove de propiedades procedentes de los roles de tipo target en una asociación

        /// <summary>
        /// Método encargado de establecer la propiedad de Teachers en la entidad Teacher.
        /// El Teacher ha de existir previamente.
        /// Permite introducir un valor nulo a la colección.
        /// </summary>
        /// <param name="teacherCollection "> 
        /// Parametro con el que se proporciona la colección <see cref="Teacher"/> a asociar. El valor de este paramentro puede ser null para borrar la relación.
        /// </param>
        /// <returns>
        /// Devuelve 'this' ( la propia entidad) de tipo <see cref="Student"/> para permitir fluent Interfaces/>
        /// </returns>
        public virtual Student SetTeachers ( System.Collections.Generic.List<Teacher> teacherCollection )
        {
            this.teachers = (System.Collections.Generic.List<Teacher>)teacherCollection ;
            return this;
        }

        /// <summary>
        /// Método encargado de añadir un elemento a la colección Teachers en la entidad Teacher.
        /// El Teacher ha de existir previamente.
        /// </summary>
        /// <param name="teacherCollection "> 
        /// Parametro con el que se proporciona la colección Teacher a asociar. El valor de este paramentro puede ser null para borrar la relación si es de agregación o asociación.
        /// </param>
        /// <returns>
        /// Devuelve 'this' ( la propia entidad) de tipo <see cref="Student"/> para permitir fluent Interfaces/>
        /// </returns>
        public virtual IStudent AddTeacherToTeachers ( Teacher teacher )
        {
            Guard.ArgumentIsNotNull(teacher, "El parametro teacher es null");          // comprobamos que el parametro no es nulo. Resources
            // se permiten valores repetidos en esta propiedad
            // observar que estamos utilizando el acceso al campo y no a la propiedad, 
            // esto se debe a que se debe utilizar a nivel de propiedades colecciones 
            // que no publiquen operaciones sobre las mismas y asi utilizar las colecciones de los campos.
            this.teachers.Add( teacher ); 

            return this;
        }

        /// <summary>
        /// Método encargado de eliminar un elemento de la colección Teachers en la entidad Teacher.
        /// El Teacher ha de existir previamente.
        /// </summary>
        /// <param name="teacherCollection "> 
        /// Identificador a borrar Teacher a asociar. El valor de este paramentro puede ser null para borrar la relación si es de agregación o asociación.
        /// </param>
        /// <returns>
        /// Devuelve 'this' ( la propia entidad) de tipo <see cref="Student"/> para permitir fluent Interfaces/>
        /// </returns>
        public virtual IStudent RemoveTeacherFromTeachers ( Teacher teacher )
        {
            Guard.ArgumentIsNotNull(teacher, "El parametro teacher es null");          // comprobamos que el parametro no es nulo. Resources
            // observar que estamos utilizando el acceso al campo y no a la propiedad, 
            // esto se debe a que se debe utilizar a nivel de propiedades colecciones que 
            // no publiquen operaciones sobre las mismas y de esta forma se obliga a utilizar los métodos proporcionados
            this.teachers.Remove( teacher );
                teacher.SetStudents(null);
            return this;
        }
        #endregion


    #region IEquatable implementation

        /// <summary>
        /// IEquatable implementation
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool Equals(IStudent other)
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
        public virtual int CompareTo(IStudent other)
        {
            // todo: move to code contract
            if (other == null)
            {
                throw new System.ArgumentNullException("Student");
            }

            int result = 0;
            result = this.Name.CompareTo(other.Name);
            if (result != 0) return result;

            return result;
        }	

    #endregion

    } // class Student 
} //  Needel.Common.Domain

