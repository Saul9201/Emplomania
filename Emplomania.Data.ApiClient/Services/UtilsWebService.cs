using Emplomania.Data.ApiClient.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.ApiClient.Services
{
    internal class UtilsWebService : IUtilsWebService
    {
        public async Task<bool> TestConnection()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(BaseWebService<object>.ServerUrl)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("Utils/ConnectionTest");
            return response.IsSuccessStatusCode;
        }
    }

    public interface IUtilsWebService
    {
        Task<bool> TestConnection();
    }
}
