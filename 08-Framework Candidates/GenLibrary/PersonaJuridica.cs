//-----------------------------------------------------------------------
// <copyright file="PersonaJuridica" company="I3TV">
//     Copyright (c) 2012. I3TV. All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------


namespace I3TV.Suite.SPE.Common.Domain.Base
{
    using System;
    

    using I3TV.Suite.SPE.Common.Domain.Core;
    using I3TV.Framework.Domain.Base;
    
    /// <summary>
    /// Clase que representa a la entidad <see cref="T:PersonaJuridica"/>.
    /// </summary>
    /// <remarks>
    /// Crea un objeto <see cref="T:PersonaJuridica"/>.
    /// </remarks>
    public class PersonaJuridica : Clasificacion, IPersonaJuridica
    {
        
        #region FIELDS
            /// <summary>
            /// Variable privada que identifica NumEmpleados.
            /// </summary>
            /// <remarks>
            /// 
            /// </remarks>
            private Int32 numEmpleados;

        #endregion

        #region CONSTRUCTORS
        
            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="T:PersonaJuridica"/>.
            /// </summary>
            /// <remarks>
            /// Constructor de la clase <see cref="T:PersonaJuridica"/>.
            /// </remarks>
            internal PersonaJuridica() : base()
            {
            } // PersonaJuridica Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="T:PersonaJuridica"/>.
            /// </summary>
            /// <remarks>
            /// Constructor de la clase <see cref="T:PersonaJuridica"/>.
            /// </remarks>
            /// <param name="id">
            /// Parámetro que indica el identificador raiz de la entidad.
            /// </param>
            /// <param name="numEmpleados">
            /// .
            /// </param>
            internal PersonaJuridica(
                                       int id,
                                       string nombre,
                                       Int32 numEmpleados /* bucle 4*/
                                   ) : base(id, nombre)
                    {}
        #endregion
    } // IPersonaJuridicaRepositoryFactory

} //  I3TV.Suite.SPE.Common.Domain.Base
