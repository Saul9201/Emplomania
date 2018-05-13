using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.Data.VO.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;

namespace Emplomania.UI.Infrastucture
{
    #region Extencion para bindear enum a combobox
    public class EnumerationExtension : MarkupExtension
    {
        private Type _enumType;

        public EnumerationExtension(Type enumType)
        {
            EnumType = enumType ?? throw new ArgumentNullException("enumType");
        }

        public Type EnumType
        {
            get { return _enumType; }
            private set
            {
                if (_enumType == value)
                    return;

                var enumType = Nullable.GetUnderlyingType(value) ?? value;

                if (enumType.IsEnum == false)
                    throw new ArgumentException("Type must be an Enum.");

                _enumType = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var enumValues = Enum.GetValues(EnumType);

            var result = (
              from object enumValue in enumValues
              where GetDescription(enumValue)!="NotShow"
              select new EnumerationMember
              {
                  Value = enumValue,
                  Description = GetDescription(enumValue)
              }).ToArray();
            return result;
        }

        private string GetDescription(object enumValue)
        {
            var descriptionAttribute = EnumType
              .GetField(enumValue.ToString())
              .GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;


            return descriptionAttribute != null
              ? descriptionAttribute.Description
              : enumValue.ToString();
        }

        public class EnumerationMember
        {
            public string Description { get; set; }
            public object Value { get; set; }
        }
    }

    #endregion

    #region Nomencladores propios de la app administrativa
    public enum ScaleNR
    {
        [Description("1")]
        uno,
        [Description("2")]
        dos,
        [Description("3")]
        tres
    }

    public enum YesNotAnswer
    {
        No,
        Yes,
    }

    public enum MoneyType
    {
        CUC,
        CUP,
    }
    #endregion

    #region Nomencladores comunes con la web

    #region Nomencladores comunes con la web pero que no pueden variar

    //public enum Gender
    //{
    //    Masculino,
    //    Femenino
    //}
    #endregion


    public class WebNomenclatorsCache : BindableBase
    {
        public static WebNomenclatorsCache Instance { get; set; }

        public static void Load()
        {
            Instance.Categories = ServiceLocator.Get<ICategoryService>().GetAll().ToList();
            Instance.CivilStatuses = ServiceLocator.Get<ICivilStatusService>().GetAll().ToList();
            Instance.Complexions = ServiceLocator.Get<IComplexionService>().GetAll().ToList();
            Instance.Currencies = ServiceLocator.Get<ICurrencyService>().GetAll().ToList();
            Instance.DriverLicenses = ServiceLocator.Get<IDriverLicenseService>().GetAll().ToList();
            Instance.EyeColors = ServiceLocator.Get<IEyeColorService>().GetAll().ToList();
            Instance.SchoolGrades = ServiceLocator.Get<ISchoolGradeService>().GetAll().ToList();
            Instance.Languages = ServiceLocator.Get<ILanguageService>().GetAll().ToList();
            Instance.LanguageLevels = ServiceLocator.Get<ILanguageLevelService>().GetAll().ToList();
            Instance.Provinces = ServiceLocator.Get<IProvinceService>().GetAll().ToList();
            Instance.Memberships = ServiceLocator.Get<IMembershipService>().GetAll().ToList();
            Instance.Prizes = ServiceLocator.Get<IPrizeService>().GetAll().ToList();
            Instance.Schedules = ServiceLocator.Get<IScheduleService>().GetAll().ToList();
            Instance.SkinColors = ServiceLocator.Get<ISkinColorService>().GetAll().ToList();
            Instance.Specialities = ServiceLocator.Get<ISpecialtyService>().GetAll().ToList();
            Instance.Vehicles = ServiceLocator.Get<IVehicleService>().GetAll().ToList();
            Instance.Workplaces = ServiceLocator.Get<IWorkplaceService>().GetAll().ToList();
            Instance.Courses = ServiceLocator.Get<ICourseService>().GetAll().ToList();
            Instance.Genders = ServiceLocator.Get<IGenderService>().GetAll().ToList();
            Instance.Municipalities = ServiceLocator.Get<IMunicipalityService>().GetAll().ToList();

            
        }

        static WebNomenclatorsCache()
        {
            Instance = new WebNomenclatorsCache()
            {
                Statures = new List<float>()
                {
                    1.50F,
                    1.51F,
                    1.52F,
                    1.53F,
                    1.54F,
                    1.55F,
                    1.56F,
                    1.57F,
                    1.58F,
                    1.59F,
                    1.60F,
                    1.61F,
                    1.62F,
                    1.63F,
                    1.64F,
                    1.65F,
                    1.66F,
                    1.67F,
                    1.68F,
                    1.69F,
                    1.70F,
                    1.71F,
                    1.72F,
                    1.73F,
                    1.74F,
                    1.75F,
                    1.76F,
                    1.77F,
                    1.78F,
                    1.79F,
                    1.80F,
                    1.81F,
                    1.82F,
                    1.83F,
                    1.84F,
                    1.85F,
                    1.86F,
                    1.87F,
                    1.88F,
                    1.89F,
                    1.90F,
                    1.91F,
                    1.92F,
                    1.93F,
                    1.94F,
                    1.95F,
                    1.96F,
                    1.97F,
                    1.98F,
                    1.99F,
                    2.00F,
                    2.01F,
                    2.02F,
                    2.03F,
                    2.04F,
                    2.05F,
                    2.06F,
                    2.07F,
                    2.08F,
                    2.09F,
                    2.10F
                },
                WorkPlaceCount=new List<int>()
                {
                    1,2,3,4,5,6,7,8,9,10,
                },
                WorkedTimes = new List<string>()
                {
                    "menos 1 año",
                    "1 año",
                    "2 años",
                    "3 años",
                    "4 años",
                    "5 años",
                    "6 años",
                    "7 años",
                    "8 años",
                    "9 años",
                    "10 años",
                    "mas de 10 años",
                },
                HowKnowEM = new List<string>()
                {
                    "Por un anuncio de clasificados",
                    "Porque me lo recomendaron",
                    "Por publicidad impresa",
                    "Recibí promoción por email",
                    "Por el paquete semanal",
                    "Por las redes sociales",
                }
            };
            Load();

        }

        public List<float> Statures { get; set; }

        public List<string> WorkedTimes { get; set; }

        public List<int> WorkPlaceCount { get; set; }

        public List<string> HowKnowEM { get; set; }

        private List<CategoryVO> categories;
        public List<CategoryVO> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                SetProperty(ref categories, value);
            }
        }

        private List<CivilStatusVO> civilStatuses;
        public List<CivilStatusVO> CivilStatuses
        {
            get
            {
                return civilStatuses;
            }
            set
            {
                SetProperty(ref civilStatuses, value);
            }
        }

        private List<ComplexionVO> complexions;
        public List<ComplexionVO> Complexions
        {
            get { return complexions; }
            set { SetProperty(ref complexions, value); }
        }

        private List<CurrencyVO> currencies;
        public List<CurrencyVO> Currencies
        {
            get { return currencies; }
            set { SetProperty(ref currencies, value); }
        }

        private List<DriverLicenseVO> driverLicenses;
        public List<DriverLicenseVO> DriverLicenses
        {
            get { return driverLicenses; }
            set { SetProperty(ref driverLicenses, value); }
        }

        private List<EyeColorVO> eyeColor;
        public List<EyeColorVO> EyeColors
        {
            get { return eyeColor; }
            set { SetProperty(ref eyeColor, value); }
        }

        private List<SchoolGradeVO> schoolGrades;
        public List<SchoolGradeVO> SchoolGrades
        {
            get { return schoolGrades; }
            set { SetProperty(ref schoolGrades, value); }
        }

        private List<LanguageVO> languages;
        public List<LanguageVO> Languages
        {
            get { return languages; }
            set { SetProperty(ref languages, value); }
        }

        private List<LanguageLevelVO> languageLevels;
        public List<LanguageLevelVO> LanguageLevels
        {
            get { return languageLevels; }
            set { SetProperty(ref languageLevels, value); }
        }

        private List<ProvinceVO> provinces;
        public List<ProvinceVO> Provinces
        {
            get { return provinces; }
            set { SetProperty(ref provinces, value); }
        }

        private List<MembershipVO> memberships;
        public List<MembershipVO> Memberships
        {
            get { return memberships; }
            set { SetProperty(ref memberships, value); }
        }

        private List<PrizeVO> prizes;
        public List<PrizeVO> Prizes
        {
            get { return prizes; }
            set { SetProperty(ref prizes, value); }
        }

        private List<ScheduleVO> schedules;
        public List<ScheduleVO> Schedules
        {
            get { return schedules; }
            set { SetProperty(ref schedules, value); }
        }

        private List<SkinColorVO> skinColors;
        public List<SkinColorVO> SkinColors
        {
            get { return skinColors; }
            set { SetProperty(ref skinColors, value); }
        }

        private List<SpecialtyVO> specialities;
        public List<SpecialtyVO> Specialities
        {
            get { return specialities; }
            set { SetProperty(ref specialities, value); }
        }

        private List<VehicleVO> vehicles;
        public List<VehicleVO> Vehicles
        {
            get { return vehicles; }
            set { SetProperty(ref vehicles, value); }
        }

        private List<WorkplaceVO> workplaces;
        public List<WorkplaceVO> Workplaces
        {
            get { return workplaces; }
            set { SetProperty(ref workplaces, value); }
        }

        private List<CourseVO> courses;
        public List<CourseVO> Courses
        {
            get { return courses; }
            set { SetProperty(ref courses, value); }
        }

        private List<MunicipalityVO> municipalities;
        public List<MunicipalityVO> Municipalities
        {
            get { return municipalities; }
            set { SetProperty(ref municipalities, value); }
        }

        //public List<WorkerLanguageVO> WorkerLanguages { get; private set; }
        public List<GenderVO> Genders { get; private set; }

    }

    //public enum Membresy
    //{
    //    Gratis,
    //    Turqueza,
    //    Esmeralda,
    //    [Description("Rubí")]
    //    Rubi,
    //    Zafiro,
    //    Diamante
    //}
    #endregion



}
