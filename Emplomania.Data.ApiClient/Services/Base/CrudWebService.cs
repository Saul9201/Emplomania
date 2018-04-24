using Emplomania.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.ApiClient.Services.Base
{
    internal abstract class CrudWebService<T> : BaseWebService<T>, ICrudWebService<T>
    {
        public CrudWebService() : base()
        {
        }

        public async Task<T> CreateAsync(T eyeColor)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("", eyeColor);
            T ec = default(T);
            if (response.IsSuccessStatusCode)
                ec = await response.Content.ReadAsAsync<T>();

            return ec;
        }

        public async Task<bool> UpdateAsync(T eyeColor)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("", eyeColor);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"?id={id}");
            return response.IsSuccessStatusCode;
        }
    }

    public interface ICrudWebService<T> : IBaseWebService<T>
    {
        Task<T> CreateAsync(T eyeColor);
        Task<bool> UpdateAsync(T eyeColor);
        Task<bool> DeleteAsync(Guid id);
    }
}
