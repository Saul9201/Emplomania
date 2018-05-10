using Emplomania.Data.ApiClient.Services;
using Emplomania.Data.ApiClient.Services.Base;
using Emplomania.Data.Services;
using Emplomania.Data.Services.Base;
using Emplomania.Data.VO;
using Emplomania.Data.VO.Base;
using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Emplomania.Infrastucture.Enums;

namespace Emplomania.UI.Infrastucture
{
    public class DataAdministrator
    {
        private static async Task<bool> Process<WS,LS,VOT,ENT>()
            where WS : ICrudWebService<VOT>
            where LS : ICrudService<VOT, ENT>
            where ENT : class
            where VOT : NomenclatorVO
        {
            try
            {
                var webServ = ServiceLocator.Get<WS>();
                var localServ = ServiceLocator.Get<LS>();
                var web = await webServ.GetAllAsync();
                var local = localServ.GetAll();
                foreach (var item in web)
                {
                    if (!local.Any(x => x.Id == item.Id))
                        localServ.Add(item, false);
                }
                localServ.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<bool> SincLocalDbWithWebSiteDb()
        {
            var webApiUtilsServ = ServiceLocator.Get<IUtilsWebService>();
            if (!await webApiUtilsServ.TestConnection())
                MessageBox.Show("La Api Web no esta accesible, pruebe conectandose a internet e intentelo nuevamente.");
            //Sincronizar nomencladores
            bool res = true;
            res &= await Process<ICategoryWebService, ICategoryService, CategoryVO, Category>();
            res &= await Process<ICivilStatusWebService, ICivilStatusService, CivilStatusVO, CivilStatus>();
            res &= await Process<IComplexionWebService, IComplexionService, ComplexionVO, Complexion>();
            res &= await Process<ICourseWebService, ICourseService, CourseVO, Course>();
            res &= await Process<ICurrencyWebService, ICurrencyService, CurrencyVO, Currency>();
            res &= await Process<IDriverLicenseWebService, IDriverLicenseService, DriverLicenseVO, DriverLicense>();
            res &= await Process<IEyeColorWebService, IEyeColorService, EyeColorVO, EyeColor>();
            res &= await Process<ILanguageWebService, ILanguageService, LanguageVO, Language>();
            res &= await Process<ILanguageLevelWebService, ILanguageLevelService, LanguageLevelVO, LanguageLevel>();
            res &= await Process<IMembershipWebService, IMembershipService, MembershipVO, Membership>();
            res &= await Process<IMunicipalityWebService, IMunicipalityService, MunicipalityVO, Municipality>();
            res &= await Process<IPrizeWebService, IPrizeService, PrizeVO, Prize>();
            res &= await Process<IProvinceWebService, IProvinceService, ProvinceVO, Province>();
            res &= await Process<IScheduleWebService, IScheduleService, ScheduleVO, Schedule>();
            res &= await Process<ISchoolGradeWebService, ISchoolGradeService, SchoolGradeVO, SchoolGrade>();
            res &= await Process<ISkinColorWebService, ISkinColorService, SkinColorVO, SkinColor>();
            res &= await Process<ISpecialtyWebService, ISpecialtyService, SpecialtyVO, Specialty>();
            res &= await Process<IVehicleWebService, IVehicleService, VehicleVO, Vehicle>();
            res &= await Process<IWorkplaceWebService, IWorkplaceService, WorkplaceVO, Workplace>();
            res &= await Process<IGenderWebService, IGenderService, GenderVO, Emplomania.Model.Gender>();
            WebNomenclatorsCache.Load();

            //TODO: Hacer otras cosas como sincronizar usuarios.
            return res;
        }

        internal static List<UserVO> GetUserByUserNameOrFullName(UserClientRole clientType, string userNameToSearch, string fullNameToSearch)
        {
            return ServiceLocator.Get<IUserService>().FilterByUserNameAndFullName(clientType, userNameToSearch, fullNameToSearch);
            //TODO: Buscar por la web y agregar el resultado a la lista.
            //Notificar aqui en caso de que se este buscando solamente por la db local.
            //UsersSearchResult = UserNameToSearch.Concat(ServiceLocator.Get<IUserWebService>(FilterByUserNameAndFullName(SelectedClientType, UserNameToSearch, FullNameToSearch)));

        }
    }
}
