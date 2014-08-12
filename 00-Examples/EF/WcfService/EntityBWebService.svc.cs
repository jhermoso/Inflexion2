using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CommonDomain;
using EFApplication.Services;
using EFApplication;
using EFApplication.Dtos;
using Inflexion2.Domain;
using Inflexion2.Application;
using Inflexion2.Application.DataTransfer.Core;

namespace WcfService
{

    public class EntityBWebService : IEntityBWebService
    {
        /// <summary>
        /// Referencia a los servicios de administración de la entidad.
        /// </summary>
        private readonly IEntityBServices service;

        public EntityBWebService()
        {
            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            // configuramos aqui el servicio o lo hacemos en el global asax
            // resolvemos con el ioc la interface de servicios de 
            this.service = new EntityBServices();
        }

        public int Create(EntityBDto entityBDto)
        {
            return this.service.Create(entityBDto);
        }

        public bool Update(EntityBDto entityBDto)
        {
            return this.service.Update(entityBDto);
        } // end Update

        public bool Delete(int id)
        {
            return this.service.Delete(id);
        } // Delete

        public IEnumerable<EntityBDto> GetAll()
        {
            return this.service.GetAll();
        } // GetAll

        public EntityBDto GetById(Int32 EntityId)
        {
            return this.service.GetById(EntityId);
        } // GetById

        public PagedElements<EntityBDto> GetPaged(SpecificationDto specificationDto)
        {
            return this.service.GetPaged(specificationDto);
        }

        //public string GetHello()
        //{ return "Hello"; }
    }
}
