using Emplomania.Data.VO;
using Emplomania.Data.VO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.ApiClient.Services.Base
{
    internal abstract class BaseWebService<T> : IBaseWebService<T>
    {
        internal const string ServerUrl = "http://localhost/Emplomania/api/";
        protected HttpClient client;
        protected static Dictionary<string, string> VO_ControlerNameDictionary = new Dictionary<string, string>
        {
            { "CategoryVO","Categoria"},
            { "CivilStatusVO", "EstadoCivil"},
            { "ComplexionVO","Complexion"},
            { "CurrencyVO","Moneda"},
            { "DriverLicenseVO","LicenciaConduccion"},
            { "EyeColorVO","ColorOjos"},
            { "SchoolGradeVO","GradoEscolar"},
            { "LanguageVO","Idioma"},
            { "LanguageLevelVO","NivelIdioma"},
            { "ProvinceVO","Provincia"},
            { "MembershipVO","Membresia"},
            { "PrizeVO","Premio"},
            { "ScheduleVO","Horario"},
            { "SkinColorVO","ColorPiel"},
            { "SpecialtyVO","Especialidad"},
            { "VehicleVO","Vehiculo"},
            { "WorkplaceVO","Plaza"},
            { "CourseVO","Curso"},
            { "MunicipalityVO","Municipio"},
            { "GenderVO", "Genero"}
        };


        public BaseWebService()
        {
            var controlName = VO_ControlerNameDictionary[typeof(T).Name];
            this.client = new HttpClient()
            {
                BaseAddress = new Uri(ServerUrl+ controlName)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<T> GetAsync(Guid id)
        {
            T res=default(T);
            HttpResponseMessage response = await client.GetAsync($"?Id={id}");
            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<T>();
            }
            return res;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> res = null;
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<List<T>>();
            }
            return res;
        }


    }

    public interface IBaseWebService<T>
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
