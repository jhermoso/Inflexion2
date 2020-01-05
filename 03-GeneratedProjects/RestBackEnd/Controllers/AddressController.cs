
namespace RestBackEnd.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Inflexion2.Domain;
    using Inflexion2.Application;
    using Needel.Common.Application;
    using Needel.Common.Application.Dtos;
    using System.Web.Http.Description;

    public class AddressController : ApiController
    {
        #region Fields

        /// <summary>
        /// API de los servicios la entidad Address.
        /// </summary>
        private readonly Needel.Common.Application.IAddressServices service = new AddressServices();

        #endregion

        //#region constructors
        //public AddressController()
        //{
        //    this.service = new AddressServices();
        //}
        //#endregion

        [HttpGet]
        [ActionName("")]
        [Route("api/Address")]
        public string Get()
        {
            return "Hello Wordl";
        }



        [HttpGet]
        [ResponseType(typeof(HttpResponseMessage))]
        [ActionName("GetAll")]
        [Route("Api/Address/GetAll")]
        public   HttpResponseMessage GetAll()
        {  
            try
            {
                var result = this.service.GetAll();

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

    }
}
