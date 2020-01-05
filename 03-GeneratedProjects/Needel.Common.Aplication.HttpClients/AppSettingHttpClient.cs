

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

    public class AppSettingHttpClient : IAppSettingClient
    {
        HttpClient client;
        public AppSettingHttpClient()
        {
            client = new HttpClient();
            var baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            client.BaseAddress =  new Uri("http://localhost:30303/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Int32 Create(Application.Dtos.AppSettingDto appSettingDto)
        {
            Int32 result = 0;
            HttpResponseMessage response = client.GetAsync("api/appSetting/new").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<Int32>().Result;
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            HttpResponseMessage response = client.GetAsync("api/appSetting/Delete").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<bool>().Result;
            }

            return result;
        }

        public IEnumerable<int> DeleteAll()
        {
            IEnumerable<Int32> result = null;
            HttpResponseMessage response = client.GetAsync("api/appSetting/DeleteAll").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<Int32>>().Result;
            }

            return result;
        }

        public IEnumerable<Application.Dtos.AppSettingDto> GetAll()
        {
            IEnumerable<Application.Dtos.AppSettingDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/appSetting/getall").Result;

            if (response.IsSuccessStatusCode)
            {
                 result = response.Content.ReadAsAsync<IEnumerable<AppSettingDto>>().Result;
            }

            return result;
        }

        public IEnumerable<Application.Dtos.AppSettingDto> GetAllExceptId(int addressId)
        {
            IEnumerable<Application.Dtos.AppSettingDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/appSetting/GetAllExceptId").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<AppSettingDto>>().Result;
            }

            return result;
        }

        public IEnumerable<Application.Dtos.AppSettingDto> GetAllExceptIds(IEnumerable<int> addressIds)
        {
            IEnumerable<Application.Dtos.AppSettingDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/appSetting/GetAllExcept").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<AppSettingDto>>().Result;
            }

            return result;
        }

        public Application.Dtos.AppSettingDto GetById(int addressId)
        {
            AppSettingDto result = null;
            HttpResponseMessage response = client.GetAsync("api/appSetting").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<AppSettingDto>().Result;
            }

            return result;
        }

        public IEnumerable<Application.Dtos.AppSettingDto> GetFiltered(global::Inflexion2.Application.SpecificationDto specificationDto)
        {
            IEnumerable<Application.Dtos.AppSettingDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/appSetting/GetFiltered").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<AppSettingDto>>().Result;
            }

            return result;
        }

        public global::Inflexion2.Domain.PagedElements<Application.Dtos.AppSettingDto> GetPaged(global::Inflexion2.Application.SpecificationDto specificationDto)
        {
            PagedElements<Application.Dtos.AppSettingDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/appSetting/GetPaged").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<PagedElements<AppSettingDto>>().Result;
            }

            return result;
        }

        public IEnumerable<Application.Dtos.AppSettingDto> GetSelectedIds(IEnumerable<int> addressIds)
        {
            IEnumerable<Application.Dtos.AppSettingDto> result = null;
            HttpResponseMessage response = client.GetAsync("api/appSetting/GetSelectedIds").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<IEnumerable<AppSettingDto>>().Result;
            }

            return result;
        }

        public bool Update(Application.Dtos.AppSettingDto addressDto)
        {
           bool result = false;
            HttpResponseMessage response = client.GetAsync("api/appSetting/update").Result;

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<bool>().Result;
            }

            return result;
        }
    }
}
