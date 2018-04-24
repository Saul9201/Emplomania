using Emplomania.Data.ApiClient.Services.Base;
using Emplomania.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.ApiClient.Services
{
    internal class CategoryWebService : CrudWebService<CategoryVO>, ICategoryWebService
    {
    }
    public interface ICategoryWebService : ICrudWebService<CategoryVO>
    {
    }

    internal class CivilStatusWebService : CrudWebService<CivilStatusVO>, ICivilStatusWebService
    {
    }
    public interface ICivilStatusWebService : ICrudWebService<CivilStatusVO>
    {
    }

    internal class ComplexionWebService : CrudWebService<ComplexionVO>, IComplexionWebService
    {
    }
    public interface IComplexionWebService : ICrudWebService<ComplexionVO>
    {
    }

    internal class CurrencyWebService : CrudWebService<CurrencyVO>, ICurrencyWebService
    {
    }
    public interface ICurrencyWebService : ICrudWebService<CurrencyVO>
    {
    }

    internal class DriverLicenseWebService : CrudWebService<DriverLicenseVO>, IDriverLicenseWebService
    {
    }
    public interface IDriverLicenseWebService : ICrudWebService<DriverLicenseVO>
    {
    }

    internal class EyeColorWebService : CrudWebService<EyeColorVO>, IEyeColorWebService
    {
    }
    public interface IEyeColorWebService : ICrudWebService<EyeColorVO>
    {
    }
    
    internal class CourseWebService : CrudWebService<CourseVO>, ICourseWebService
    {
    }
    public interface ICourseWebService : ICrudWebService<CourseVO>
    {
    }

    internal class LanguageWebService : CrudWebService<LanguageVO>, ILanguageWebService
    {
    }
    public interface ILanguageWebService : ICrudWebService<LanguageVO>
    {
    }

    internal class LanguageLevelWebService : CrudWebService<LanguageLevelVO>, ILanguageLevelWebService
    {
    }
    public interface ILanguageLevelWebService : ICrudWebService<LanguageLevelVO>
    {
    }

    internal class MembershipWebService : CrudWebService<MembershipVO>, IMembershipWebService
    {
    }
    public interface IMembershipWebService : ICrudWebService<MembershipVO>
    {
    }

    internal class MunicipalityWebService : CrudWebService<MunicipalityVO>, IMunicipalityWebService
    {
    }
    public interface IMunicipalityWebService : ICrudWebService<MunicipalityVO>
    {
    }

    internal class PrizeWebService : CrudWebService<PrizeVO>, IPrizeWebService
    {
    }
    public interface IPrizeWebService : ICrudWebService<PrizeVO>
    {
    }

    internal class ProvinceWebService : CrudWebService<ProvinceVO>, IProvinceWebService
    {
    }
    public interface IProvinceWebService : ICrudWebService<ProvinceVO>
    {
    }

    internal class ScheduleWebService : CrudWebService<ScheduleVO>, IScheduleWebService
    {
    }
    public interface IScheduleWebService : ICrudWebService<ScheduleVO>
    {
    }

    internal class SchoolGradeWebService : CrudWebService<SchoolGradeVO>, ISchoolGradeWebService
    {
    }
    public interface ISchoolGradeWebService : ICrudWebService<SchoolGradeVO>
    {
    }

    internal class SkinColorWebService : CrudWebService<SkinColorVO>, ISkinColorWebService
    {
    }
    public interface ISkinColorWebService : ICrudWebService<SkinColorVO>
    {
    }

    internal class SpecialtyWebService : CrudWebService<SpecialtyVO>, ISpecialtyWebService
    {
    }
    public interface ISpecialtyWebService : ICrudWebService<SpecialtyVO>
    {
    }
    
    internal class VehicleWebService : CrudWebService<VehicleVO>, IVehicleWebService
    {
    }
    public interface IVehicleWebService:ICrudWebService<VehicleVO>
    {
    }

    internal class WorkplaceWebService : CrudWebService<WorkplaceVO>, IWorkplaceWebService
    {
    }
    public interface IWorkplaceWebService:ICrudWebService<WorkplaceVO>
    {
    }

    internal class GenderWebService : CrudWebService<GenderVO>, IGenderWebService
    {
    }
    public interface IGenderWebService : ICrudWebService<GenderVO>
    {
    }
}
