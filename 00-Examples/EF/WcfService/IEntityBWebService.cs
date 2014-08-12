using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CommonDomain;
using EFApplication;
using EFApplication.Dtos;
using Inflexion2.Domain;
using Inflexion2.Application;
using Inflexion2.Application.DataTransfer.Core;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEntityBWebService
    {

        [OperationContract]
        int Create(EntityBDto entityBDto);

        [OperationContract]
        bool Delete(Int32 EntityBId);

        [OperationContract]
        IEnumerable<EntityBDto> GetAll();

        [OperationContract]
        PagedElements<EntityBDto> GetPaged(SpecificationDto specificationDto);

        [OperationContract]
        EntityBDto GetById(Int32 entityBId);

        [OperationContract]
        bool Update(EntityBDto entityBDto);

        //[OperationContract]
        //string GetHello();
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
