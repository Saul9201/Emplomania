using AutoMapper.QueryableExtensions;
using Emplomania.Data.Services.Base;
using Emplomania.Data.VO;
using Emplomania.Data.VO.Base;
using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Services
{
    internal class CategoryService : CrudService<CategoryVO, Category>, ICategoryService
    {
        public CategoryService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface ICategoryService : ICrudService<CategoryVO, Category>
    {
    }

    internal class CourseService : CrudService<CourseVO, Course>, ICourseService
    {
        public CourseService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface ICourseService : ICrudService<CourseVO, Course>
    {
    }

    internal class CivilStatusService : CrudService<CivilStatusVO, CivilStatus>, ICivilStatusService
    {
        public CivilStatusService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface ICivilStatusService : ICrudService<CivilStatusVO, CivilStatus>
    {
    }

    internal class ComplexionService : CrudService<ComplexionVO, Complexion>, IComplexionService
    {
        public ComplexionService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface IComplexionService : ICrudService<ComplexionVO, Complexion>
    {
    }

    internal class CurrencyService : CrudService<CurrencyVO, Currency>, ICurrencyService
    {
        public CurrencyService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface ICurrencyService : ICrudService<CurrencyVO, Currency>
    {
    }

    internal class DriverLicenseService : CrudService<DriverLicenseVO, DriverLicense>, IDriverLicenseService
    {
        public DriverLicenseService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface IDriverLicenseService : ICrudService<DriverLicenseVO, DriverLicense>
    {
    }

    internal class EyeColorService : CrudService<EyeColorVO, EyeColor>, IEyeColorService
    {
        public EyeColorService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface IEyeColorService : ICrudService<EyeColorVO, EyeColor>
    {
    }

    internal class LanguageService : CrudService<LanguageVO, Language>, ILanguageService
    {
        public LanguageService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface ILanguageService : ICrudService<LanguageVO, Language>
    {
    }

    internal class LanguageLevelService : CrudService<LanguageLevelVO, LanguageLevel>, ILanguageLevelService
    {
        public LanguageLevelService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface ILanguageLevelService : ICrudService<LanguageLevelVO, LanguageLevel>
    {
    }

    internal class MembershipService : CrudService<MembershipVO, Membership>, IMembershipService
    {
        public MembershipService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
        public IQueryable<MembershipVO> GetMembershipsByUserType(Infrastucture.Enums.UserClientRole userType)
        {
            var readDb = new EmplomaniaAdminDBContext();
            var q = from m in readDb.Memberships
                    where m.UserType == userType
                    select m;
            return q.ProjectTo<MembershipVO>();
        }
    }
    public interface IMembershipService : ICrudService<MembershipVO, Membership>
    {
        IQueryable<MembershipVO> GetMembershipsByUserType(Infrastucture.Enums.UserClientRole userType);
    }

    internal class AditionalServiceService : CrudService<AditionalServiceVO, AditionalService>, IAditionalServiceService
    {
        public AditionalServiceService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public IQueryable<AditionalServiceVO> GetAditionalServicesByUserType(Infrastucture.Enums.UserClientRole userType)
        {
            var readDb = new EmplomaniaAdminDBContext();
            var q = from s in readDb.AditionalServices
                    where s.UserType == userType
                    select s;
            return q.ProjectTo<AditionalServiceVO>();
        }
    }
    public interface IAditionalServiceService : ICrudService<AditionalServiceVO, AditionalService>
    {
        IQueryable<AditionalServiceVO> GetAditionalServicesByUserType(Infrastucture.Enums.UserClientRole userType);
    }

    internal class MunicipalityService : CrudService<MunicipalityVO, Municipality>, IMunicipalityService
    {
        public MunicipalityService(EmplomaniaAdminDBContext db) : base(db)
        {
        }

        public IQueryable<MunicipalityVO> GetMunicByProvince(Guid id)
        {
            var query = from m in db.Municipalities
                        where m.ProvinceFK == id
                        select m;
            return query.ProjectTo<MunicipalityVO>();

        }
    }
    public interface IMunicipalityService : ICrudService<MunicipalityVO, Municipality>
    {
        IQueryable<MunicipalityVO> GetMunicByProvince(Guid id);
    }

    internal class PrizeService : CrudService<PrizeVO, Prize>, IPrizeService
    {
        public PrizeService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface IPrizeService : ICrudService<PrizeVO, Prize>
    {
    }

    internal class ProvinceService : CrudService<ProvinceVO, Province>, IProvinceService
    {
        public ProvinceService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface IProvinceService : ICrudService<ProvinceVO, Province>
    {
    }

    internal class ScheduleService : CrudService<ScheduleVO, Schedule>, IScheduleService
    {
        public ScheduleService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface IScheduleService : ICrudService<ScheduleVO, Schedule>
    {
    }

    internal class SchoolGradeService : CrudService<SchoolGradeVO, SchoolGrade>, ISchoolGradeService
    {
        public SchoolGradeService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface ISchoolGradeService : ICrudService<SchoolGradeVO, SchoolGrade>
    {
    }

    internal class SkinColorService : CrudService<SkinColorVO, SkinColor>, ISkinColorService
    {
        public SkinColorService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface ISkinColorService : ICrudService<SkinColorVO, SkinColor>
    {
    }

    internal class SpecialtyService : CrudService<SpecialtyVO, Specialty>, ISpecialtyService
    {
        public SpecialtyService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface ISpecialtyService : ICrudService<SpecialtyVO, Specialty>
    {
    }

    internal class VehicleService : CrudService<VehicleVO, Vehicle>, IVehicleService
    {
        public VehicleService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface IVehicleService : ICrudService<VehicleVO, Vehicle>
    {
    }

    internal class WorkplaceService : CrudService<WorkplaceVO, Workplace>, IWorkplaceService
    {
        public WorkplaceService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface IWorkplaceService : ICrudService<WorkplaceVO, Workplace>
    {
    }

    internal class GenderService : CrudService<GenderVO, Gender>, IGenderService
    {
        public GenderService(EmplomaniaAdminDBContext db) : base(db)
        {
        }
    }
    public interface IGenderService : ICrudService<GenderVO, Gender>
    {
    }
}
