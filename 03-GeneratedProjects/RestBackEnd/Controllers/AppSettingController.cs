

namespace RestBackEnd.Controllers
{
    using Needel.Common.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Inflexion2.Domain;
    using Inflexion2.Application;
    using Needel.Common.Application;
    using Needel.Common.Domain;
    using System.Web.Http.Description;
    using Newtonsoft.Json;

    public class AppSettingController : ApiController
    {

        #region Fields
        /// <summary>
        /// AppSetting service's API.
        /// </summary>
        private readonly Needel.Common.Application.IAppSettingServices service;

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="T:AppSettingService"/>.
        /// </summary>
        /// <remarks>
        /// Constructor de la clase <see cref="T:AppSettingService"/>.
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
        /// para la creación de la entidad <see cref="AppSetting"/>.
        /// </param>
        /// <returns>Devuelve el identificador único de la entidad creada.</returns>
        /// <example>
        /// to test with fiddler creating a file:
        /// 1.- create a file with json extension and the content with new values for the entity
        /// example of content for appsettingupdate.json file
        /// {"Key":"new key 2","Value":"new value","Remark":"new remark","AppSettingType":2}
        /// 2.- go to composer
        /// 3.- select POST
        /// 4.Write http://localhost:1964/Api/AppSetting/Create in the URI box.
        /// 5. Upload the file created in previous step 1: appsettingupdate.json
        ///  this action writes the correct content type header
        ///  
        /// to test with fiddler without to create a file
        /// asure the first line in header box is
        ///     Content-Type: application/json
        /// before the line 
        ///     User-Agent: Fiddler
        /// then write in the body box
        ///     {"Key":"new key 2","Value":"new value","Remark":"new remark","AppSettingType":2}
        /// </example>
        [HttpPost]
        [ResponseType(typeof(HttpResponseMessage))]
        public HttpResponseMessage Create([FromBody]AppSettingDto appSettingDto)
        {
            Int32 result = 0;
            try
            {
                result = this.service.Create(appSettingDto);
                return Request.CreateResponse(HttpStatusCode.OK, result); 
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError); 
            }
        } // end Create


        /// <summary>
        /// Función encargada de la actualziación de una entidad de tipo <see cref="AppSetting"/>.
        /// </summary>
        /// <param name="appSettingDto">
        /// Parámetro de tipo <see cref="AppSettingDto"/> con los datos necesarios
        /// para el borrado de la entidad <see cref="AppSetting"/>.
        /// </param>
        /// <returns>
        /// Devuelve <b>true</b> si la actualización ha sido correcta y
        /// <b>false</b> en caso contrario.
        /// </returns>
        /// <example>
        /// to test with fiddler creating a file:
        /// 1.- create a file with json extension and the content with new values for the entity
        /// example of content for appsettingupdate.json file
        /// {"Key":"updated key 2","Value":"updated value","Remark":"updated remark value","AppSettingType":3,"Id":2}
        /// 2.- go to composer
        /// 3.- select PUT
        /// 4.Write http://localhost:1964/Api/AppSetting/Update in the URI box.
        /// 5. Upload the file created in previous step 1: appsettingupdate.json
        ///  this action writes the correct content type header
        ///  
        /// to test with fiddler without to create a file
        /// asure the first line in header box is
        ///     Content-Type: application/json
        /// before the line 
        ///     User-Agent: Fiddler
        /// then write in the body box
        ///     {"Key":"updated key 2","Value":"updated value","Remark":"updated remark value","AppSettingType":3,"Id":2}
        /// </example>
        [HttpPut]
        [ResponseType(typeof(HttpResponseMessage))]
        public HttpResponseMessage Update([FromBody]AppSettingDto appSettingDto)
        {
            bool result = false;

            if (appSettingDto == null )
            {
                appSettingDto = new AppSettingDto() { Id = 2, Key = "updated key 2", AppSettingType = Needel.Common.Domain.Data.AppSettingType.ExternalUser, Remark = "updated remark value", Value = "updated value" };
                var text = JsonConvert.SerializeObject(appSettingDto);
                appSettingDto = JsonConvert.DeserializeObject<AppSettingDto>(text);
            }

            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                result = this.service.Update(appSettingDto);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        } // end Update

        /// <summary>
        /// Función encargada del borrado de una entidad de tipo <see cref="AppSetting"/>.
        /// </summary>
        /// <param name="appsettingId">
        /// Parámetro que indica el identificador único de la entidad a borrar.
        /// </param>
        /// <returns>
        /// Devuelve <b>true</b> si la eliminación ha sido correcta y
        /// <b>false</b> en caso contrario.
        /// </returns>
        /// <example>
        /// fiddler examples composer DELETE: 
        /// http://localhost:1964/api/AppSetting/Delete?appsettingId=19
        /// </example>
        [HttpDelete]
        [ResponseType(typeof(HttpResponseMessage))]
        public HttpResponseMessage Delete([FromUri]Int32 appsettingId)
        {

            bool result = false;
            try
            {
                result = this.service.Delete(appsettingId);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        } // Delete

        /// <summary>
        ///  Método encargado de obtener todas las entidades <see cref="AppSetting"/>.
        /// </summary>
        /// <returns>Devuelve listado de Dto´s de la entidad <see cref="AppSetting"/>.</returns>
        /// <example>
        /// fiddler examples composer GET:
        /// http://localhost:1964/api/AppSetting/getall
        /// </example>
        [HttpGet]
        [ResponseType(typeof(HttpResponseMessage))]
        public HttpResponseMessage GetAll()
        {
            IEnumerable<AppSettingDto> result = null;
            try
            {
                result = this.service.GetAll();
                

                if (result == null )
                {

                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(result));                    
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    return response;
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Método encargado de obtener una entidad <see cref="AppSetting"/> de acuerdo a
        /// su identificador.
        /// </summary>
        /// <param name="appsettingId">
        /// Parámetro que indica el identificador único de la entidad cuya
        /// información se desea obtener.
        /// </param>
        /// <returns>
        /// Devuelve objeto dto <see cref="AppSettingDto"/> con la información
        /// requerida.
        /// </returns>
        /// <example>
        /// fiddler examples composer GET:
        /// http://localhost:1964/Api/AppSetting/GetById?appsettingId=2
        /// </example>
        [HttpGet]
        [ResponseType(typeof(HttpResponseMessage))]
        public HttpResponseMessage GetById([FromUri]Int32 appsettingId)
        {
            AppSettingDto result = null;

            if (appsettingId == default(Int32))
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            try
            {
                result = this.service.GetById(appsettingId);
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        } // GetById

        /// <summary>
        /// /
        /// </summary>
        /// <param name="PageIndex">PageIndex</param>
        /// <param name="PageSize"></param>
        /// <param name="Filter"></param>
        /// <param name="SortColum"></param>
        /// <param name="SortOrder"></param>
        /// <returns></returns>
        /// <example>
        /// How to get serialized filter strings?
        /// var spec = new SpecificationDto() { PageIndex = 0, PageSize = 5 };
        /// spec.CompositeFilter.Filters.Add(new Filter() { Property = "Id", Operator = "IsEqualTo", Value = "3" });//this.ObjectElement.Id.ToString()
        /// var fltr = JsonConvert.SerializeObject(spec.CompositeFilter);
        /// this generate the string filter {"Filters":[{"Operator":"IsEqualTo","Property":"Id","Value":"3"}],"LogicalOperator":0}
        /// fiddler examples composer GET: 
        /// http://localhost:1964/api/AppSetting/GetPaged?PageIndex=0&PageSize=20&Filter={"Filters":[{"Operator":"IsEqualTo","Property":"Id","Value":"3"}],"LogicalOperator":0}
        /// http://localhost:1964/api/AppSetting/GetPaged
        /// http://localhost:1964/api/AppSetting/GetPaged?PageIndex=1&PageSize=20
        /// </example>
        [HttpGet]
        [ResponseType(typeof(HttpResponseMessage))]
        //[ActionName("GetPaged")]
        //[Route("Api/AppSetting/GetPaged/{PageIndex:int=0}/{PageSize:int=20}/{Filter}/{SortColum}/{SortOrder}")]
        public HttpResponseMessage GetPaged(int PageIndex = 0, int PageSize = 20, string Filter = null, string SortColum = null, string SortOrder = null)
        {
            Func<string, CompositeFilter> deserializer = (f) => JsonConvert.DeserializeObject<CompositeFilter>(Filter);// fltr
            SpecificationDto specificationDto = new SpecificationDto(deserializer, PageIndex, PageSize, Filter, SortColum, SortOrder);// fltr

            PagedElements<AppSettingDto> result = null;
            try
            {
                result = this.service.GetPaged(specificationDto);
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [ResponseType(typeof(HttpResponseMessage))]
        //[ActionName("DeleteAll")]
        //[Route("Api/AppSetting/DeleteAll)]")]
        public HttpResponseMessage DeleteAll()
        {
            IEnumerable<Int32> result = null;
            try
            {
                result = this.service.DeleteAll();
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [ResponseType(typeof(HttpResponseMessage))]
        //[ActionName("GetAllExceptId")]
        //[Route("Api/AppSetting/GetAllExceptId/{appsettingId}")]
        public HttpResponseMessage GetAllExceptId([FromUri]Int32 appsettingId)
        {
            IEnumerable<AppSettingDto> result = null;
            try
            {
                result = this.service.GetAllExceptId(appsettingId);
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [ResponseType(typeof(HttpResponseMessage))]
        //[ActionName("GetSelectedIds")]
        //[Route("Api/AppSetting/GetSelectedIds/{appsettingIds}")]
        public HttpResponseMessage GetSelectedIds([FromUri]IEnumerable<Int32> appsettingIds)
        {
            IEnumerable<AppSettingDto> result = null;
            try
            {
                result = this.service.GetSelectedIds(appsettingIds);
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [ResponseType(typeof(HttpResponseMessage))]
        //[ActionName("GetAllExcept")]
        //[Route("Api/AppSetting/GetAllExcept/{appsettingIds}")]
        public HttpResponseMessage GetAllExceptIds([FromUri]IEnumerable<Int32> appsettingIds)
        {
            IEnumerable<AppSettingDto> result = null;
            try
            {
                result = this.service.GetAllExceptIds(appsettingIds);
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [ResponseType(typeof(HttpResponseMessage))]
        //[ActionName("GetFiltered")]
        //[Route("Api/AppSetting/GetFiltered/PageIndex:int=0/PageSize:int=20/{Filter}/{SortColum}/{SortOrder}")]
        public HttpResponseMessage GetFiltered(int PageIndex, int PageSize, string Filter = null, string SortColum = null, string SortOrder = null)
        {
            Func<string, CompositeFilter> deserializer = (f) => JsonConvert.DeserializeObject<CompositeFilter>(Filter);
            SpecificationDto specificationDto = new SpecificationDto(deserializer, PageIndex, PageSize, Filter, SortColum, SortOrder);
            IEnumerable<AppSettingDto> result = null;
            try
            {
                result = this.service.GetPaged(specificationDto);
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                Inflexion2.Application.InternalException ie = new Inflexion2.Application.InternalException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        #endregion
    }
}
