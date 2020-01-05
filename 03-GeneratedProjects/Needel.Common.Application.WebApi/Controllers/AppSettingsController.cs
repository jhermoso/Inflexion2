

namespace Needel.Common.Application.WebApi.Controllers
{
    using Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Inflexion2.Domain;
    using Inflexion2.Application;
    using Needel.Common.Application;
    using System.Web.Http.Description;
    using Newtonsoft.Json;

    [RoutePrefix("api/AppSetting")]
    public class AppSettingController : ApiController
    {

        #region Fields

        /// <summary>
        /// API de los servicios la entidad Address.
        /// </summary>
        private readonly Needel.Common.Application.IAppSettingServices service;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:AddressService"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:AddressService"/>.
        /// </remarks>
        public AppSettingController()
        {
            this.service = new AppSettingServices();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Función encargada de la creación de una entidad de tipo AppSetting.
        /// </summary>
        /// <param name="appSettingDto">
        /// Parámetro de tipo <see cref="AppSettingDto"/> con los datos necesarios
        /// para la creación de la entidad Address.
        /// </param>
        /// <returns>Devuelve el identificador único de la entidad creada.</returns>
        [HttpPost]
        [ResponseType(typeof(IHttpActionResult))]
        [ActionName("new")]
        public IHttpActionResult/*Int32*/ Create(AppSettingDto appSettingDto)
        {
            Int32 result = 0;
            try
            {
                result = this.service.Create(appSettingDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
                return InternalServerError(ex);
            }
        } // end Create


        /// <summary>
        /// Función encargada de la actualziación de una entidad de tipo Address.
        /// </summary>
        /// <param name="appSettingDto">
        /// Parámetro de tipo <see cref="AppSettingDto"/> con los datos necesarios
        /// para el borrado de la entidad Addressr.
        /// </param>
        /// <returns>
        /// Devuelve <b>true</b> si la actualización ha sido correcta y
        /// <b>false</b> en caso contrario.
        /// </returns>
        [HttpPut]
        [ResponseType(typeof(IHttpActionResult))]
        [ActionName("update")]
        public IHttpActionResult/*bool*/ Update(AppSettingDto appSettingDto)
        {
            bool result = false;

            if (!ModelState.IsValid)
                return BadRequest("Invalid Address");

            try
            {
                result = this.service.Update(appSettingDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
                return InternalServerError(ex);
            }

        } // end Update

        /// <summary>
        /// Función encargada del borrado de una entidad de tipo Address.
        /// </summary>
        /// <remarks>
        /// Se trata de un borrado lógico.
        /// </remarks>
        /// <param name="id">
        /// Parámetro que indica el identificador único de la entidad a borrar.
        /// </param>
        /// <returns>
        /// Devuelve <b>true</b> si la eliminación ha sido correcta y
        /// <b>false</b> en caso contrario.
        /// </returns>
        [HttpDelete]
        [ResponseType(typeof(IHttpActionResult))]
        [ActionName("Delete")]
        public IHttpActionResult /*bool*/ Delete(Int32 id)
        {

            bool result = false;
            try
            {
                result = this.service.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
                return InternalServerError(ex);
            }
        } // Delete

        /// <summary>
        ///  Método encargado de obtener todas las entidades Address.
        /// </summary>
        /// <returns>Devuelve listado de Dto´s de la entidad Address.</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<AppSettingDto>))]
        [ActionName("GetAll")]
        public HttpResponseMessage /*IHttpActionResult*/ /*IEnumerable<AppSettingDto>*/ GetAll()
        {
            IEnumerable<AppSettingDto> result = null;
            try
            {
                result = this.service.GetAll();
                

                if (result == null )
                {

                    return new HttpResponseMessage(HttpStatusCode.BadRequest);// /* for return IHttpActionResult*/ NotFound();
                }
                else
                {
                    var collection = new { result }; //warper to serialize with the root type name adding a new level 
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(result));
                    
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    return response;// /* for return IHttpActionResult*/ Ok(result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.WebThrow<Inflexion2.Application.FaultObject>(ie);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);// /* for return IHttpActionResult*/InternalServerError(ex);
            }
        }

        /// <summary>
        /// Método encargado de obtener una entidad Address de acuerdo a
        /// su identificador.
        /// </summary>
        /// <param name="addressId">
        /// Parámetro que indica el identificador único de la entidad cuya
        /// información se desea obtener.
        /// </param>
        /// <returns>
        /// Devuelve objeto dto <see cref="AppSettingDto"/> con la información
        /// requerida.
        /// </returns>
        [HttpGet]
        [ResponseType(typeof(IHttpActionResult))]
        //[Route("/byIdentity/{id}")]
        public IHttpActionResult/*AppSettingDto*/ GetById(Int32 addressId)
        {
            AppSettingDto result = null;

            if (addressId == default(Int32))
                return BadRequest("Invalid Id");

            try
            {
                result = this.service.GetById(addressId);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
                return InternalServerError(ex);
            }
        } // GetById

        /// <summary>
        /// Recupera una lista paginada de entidades Address, según la especificación indicada.
        /// </summary>
        /// <param name="specificationDto">
        /// Especificación que se va a aplicar.
        /// </param>
        /// <returns>
        /// La lista paginada de entidades Address, según la especificación indicada.
        /// </returns>
        [HttpGet]
        [ResponseType(typeof(IHttpActionResult))]
        [ActionName("GetPaged")]
        public IHttpActionResult/*PagedElements<AppSettingDto>*/ GetPaged(SpecificationDto specificationDto)
        {
            PagedElements<AppSettingDto> result = null;
            try
            {
                result = this.service.GetPaged(specificationDto);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [ResponseType(typeof(IHttpActionResult))]
        [ActionName("DeleteAll")]
        public IHttpActionResult/*IEnumerable<Int32>*/ DeleteAll()
        {
            IEnumerable<Int32> result = null;
            try
            {
                result = this.service.DeleteAll();
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [ResponseType(typeof(IHttpActionResult))]
        [ActionName("GetAllExceptId")]
        public IHttpActionResult/*IEnumerable<AppSettingDto>*/ GetAllExceptId(Int32 addressId)
        {
            IEnumerable<AppSettingDto> result = null;
            try
            {
                result = this.service.GetAllExceptId(addressId);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [ResponseType(typeof(IHttpActionResult))]
        [ActionName("GetSelectedIds")]
        public IHttpActionResult/*IEnumerable<AppSettingDto>*/ GetSelectedIds(IEnumerable<Int32> addressIds)
        {
            IEnumerable<AppSettingDto> result = null;
            try
            {
                result = this.service.GetSelectedIds(addressIds);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [ResponseType(typeof(IHttpActionResult))]
        [ActionName("GetAllExcept")]
        public IHttpActionResult/*IEnumerable<AppSettingDto>*/ GetAllExceptIds(IEnumerable<Int32> addressIds)
        {
            IEnumerable<AppSettingDto> result = null;
            try
            {
                result = this.service.GetAllExceptIds(addressIds);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [ResponseType(typeof(IHttpActionResult))]
        [ActionName("GetFiltered")]
        public IHttpActionResult/*IEnumerable<AppSettingDto>*/ GetFiltered(SpecificationDto specificationDto)
        {
            IEnumerable<AppSettingDto> result = null;
            try
            {
                result = this.service.GetPaged(specificationDto);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                //FaultObject.Throw<Inflexion2.Application.FaultObject>(ie);
                return InternalServerError(ex);
            }
        }
        #endregion
    }
}
