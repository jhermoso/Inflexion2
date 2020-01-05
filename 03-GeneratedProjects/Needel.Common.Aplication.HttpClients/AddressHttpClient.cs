

namespace Needel.Common.Aplication.HttpClients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Configuration;
    using System.Text;
    using System.Threading.Tasks;
    using Application.WcfService.Contracts;

    using System.Net.Http.Headers;
    using Application.Dtos;
    using Inflexion2.Domain;

    public class AddressHttpClient : IAddressClient
    {
        HttpClient client;
        public AddressHttpClient()
        {
            client = new HttpClient();
            var baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            client.BaseAddress =  new Uri("http://localhost:30303/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Int32 Create(Application.Dtos.AddressDto addressDto)
        {
            Int32 result = 0;
            HttpResponseMessage response = client.GetAsync("api/address/new").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<Int32>().Result;
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            HttpResponseMessage response = client.GetAsync("api/address/Delete").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<bool>().Result;
            }

            return result;
        }

        public IEnumerable<int> DeleteAll()
        {
            IEnumerable<Int32> result = null;
            HttpResponseMessage response = client.GetAsync("api/address/DeleteAll").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<Int32>>().Result;
            }

            return result;
        }

        public IEnumerable<Application.Dtos.AddressDto> GetAll()
        {
            IEnumerable<Application.Dtos.AddressDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/address/getall").Result;

            if (response.IsSuccessStatusCode)
            {
                 result = response.Content.ReadAsAsync<IEnumerable<AddressDto>>().Result;
            }

            return result;
        }

        public IEnumerable<Application.Dtos.AddressDto> GetAllExceptId(int addressId)
        {
            IEnumerable<Application.Dtos.AddressDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/address/GetAllExceptId").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<AddressDto>>().Result;
            }

            return result;
        }

        public IEnumerable<Application.Dtos.AddressDto> GetAllExceptIds(IEnumerable<int> addressIds)
        {
            IEnumerable<Application.Dtos.AddressDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/address/GetAllExcept").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<AddressDto>>().Result;
            }

            return result;
        }

        public Application.Dtos.AddressDto GetById(int addressId)
        {
            AddressDto result = null;
            HttpResponseMessage response = client.GetAsync("api/address").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<AddressDto>().Result;
            }

            return result;
        }

        public IEnumerable<Application.Dtos.AddressDto> GetFiltered(global::Inflexion2.Application.SpecificationDto specificationDto)
        {
            IEnumerable<Application.Dtos.AddressDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/address/GetFiltered").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<AddressDto>>().Result;
            }

            return result;
        }

        public global::Inflexion2.Domain.PagedElements<Application.Dtos.AddressDto> GetPaged(global::Inflexion2.Application.SpecificationDto specificationDto)
        {
            PagedElements<Application.Dtos.AddressDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/address/GetPaged").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<PagedElements<AddressDto>>().Result;
            }

            return result;
        }

        public IEnumerable<Application.Dtos.AddressDto> GetSelectedIds(IEnumerable<int> addressIds)
        {
            IEnumerable<Application.Dtos.AddressDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/address/GetSelectedIds").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<AddressDto>>().Result;
            }

            return result;
        }

        public bool Update(Application.Dtos.AddressDto addressDto)
        {
           bool result = false;
            HttpResponseMessage response = client.GetAsync("api/address/update").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<bool>().Result;
            }

            return result;
        }
    }
}
