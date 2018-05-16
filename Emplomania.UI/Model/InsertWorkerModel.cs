using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.Model
{
    public class InsertWorkerModel : InsertClientModel
    {
        public InsertWorkerModel(UserVO user)
        {
            UserClientRole = UserClientRole.Trabajador;
            UserVO = user;
            WorkerVO = new WorkerVO()
            {
                Id = Guid.NewGuid(),
                UserFK = user.Id,
                User = UserVO,
                Childrens = true,
                Gender = WebNomenclatorsCache.Instance.Genders.Where(x => x.Name == Gender.Masculino.ToString()).FirstOrDefault(),
            };

            SelectedCourses = new ObservableCollection<CourseVO>();
            SelectedLicenses = new ObservableCollection<DriverLicenseVO>();
            SelectedVehicles = new ObservableCollection<VehicleVO>();
            SelectedWorkAspirations = new ObservableCollection<WorkAspirationVO>();
            SelectedWorkerLanguages = new ObservableCollection<WorkerLanguageVO>();
            SelectedWorkReferences = new ObservableCollection<WorkReferenceVO>();

            WorkerLanguagesSource = (from l in WebNomenclatorsCache.Instance.Languages
                                     select new WorkerLanguageVO
                                     {
                                         Language = new LanguageVO
                                         {
                                             Id = l.Id,
                                             Name = l.Name,
                                         },
                                     }).ToList();
            var ll = WebNomenclatorsCache.Instance.LanguageLevels.Where(x => x.Name == "Básico").FirstOrDefault();
            if (ll == null)
                throw new Exception("Error interno");
            foreach (var item in WorkerLanguagesSource)
            {
                item.LanguageLevel = ll;
                item.WorkerFK = WorkerVO.Id;
            }

            WorkAspirationsSource = new List<WorkAspirationVO>();
            foreach (var item in WebNomenclatorsCache.Instance.Workplaces)
            {
                WorkAspirationsSource.Add(new WorkAspirationVO()
                {
                    WorkerFK = WorkerVO.Id,
                    Workplace = item,
                });
            }
        }
        public InsertWorkerModel(InsertWorkerModel toCopy)
        {
            this.UserVO = toCopy.UserVO;
            this.WorkerVO = toCopy.WorkerVO;
            this.UserClientRole = toCopy.UserClientRole;
            //this.AuthenticationTypes = toCopy.AuthenticationTypes;
            this.Province = toCopy.Province;
            this.Municipalities = toCopy.Municipalities;
            this.SelectedCourses = toCopy.SelectedCourses;
            this.SelectedLicenses = toCopy.SelectedLicenses;
            this.SelectedVehicles = toCopy.SelectedVehicles;
            this.SelectedWorkAspirations = new ObservableCollection<WorkAspirationVO>(toCopy.SelectedWorkAspirations);
            this.SelectedWorkReferences = new ObservableCollection<WorkReferenceVO>(toCopy.SelectedWorkReferences);
            this.SelectedWorkerLanguages= new ObservableCollection<WorkerLanguageVO>(toCopy.SelectedWorkerLanguages);

            this.WorkerLanguagesSource = toCopy.WorkerLanguagesSource;
            this.WorkAspirationsSource = toCopy.WorkAspirationsSource;
        }
        public InsertWorkerModel(Guid userId)
        {
            var workServ = ServiceLocator.Get<IWorkerService>();
            WorkerVO w = workServ.Get(x => x.UserFK == userId);
            w = workServ.LoadEnumerablesProperties(w);
            WorkerVO = w;
            UserVO = w.User;
            if (UserVO.Municipality!=null)
            {
                Province = WebNomenclatorsCache.Instance.Provinces.Where(x => x.Id == w.User.Municipality.ProvinciaId).FirstOrDefault();
                UserVO.Municipality = Municipalities.Where(x => x.Id == UserVO.Municipality.Id).FirstOrDefault();
            }
            UserClientRole = UserClientRole.Trabajador;
            //AuthenticationTypes = UserVO.AuthenticationType;
            SelectedCourses = new ObservableCollection<CourseVO>(w.Courses);
            SelectedLicenses = new ObservableCollection<DriverLicenseVO>(w.DriverLicenses);
            SelectedVehicles = new ObservableCollection<VehicleVO>(w.Vehicles);
            SelectedWorkAspirations = new ObservableCollection<WorkAspirationVO>(w.WorkAspirations);
            SelectedWorkerLanguages = new ObservableCollection<WorkerLanguageVO>(w.Languages);
            SelectedWorkReferences = new ObservableCollection<WorkReferenceVO>(w.WorkReferences);

            WorkerLanguagesSource = (from l in WebNomenclatorsCache.Instance.Languages
                                     select new WorkerLanguageVO
                                     {
                                         Language = new LanguageVO
                                         {
                                             Id = l.Id,
                                             Name = l.Name,
                                         },
                                     }).ToList();
            var ll = WebNomenclatorsCache.Instance.LanguageLevels.Where(x => x.Name == "Básico").FirstOrDefault();
            if (ll == null)
                throw new Exception("Error interno");
            foreach (var item in WorkerLanguagesSource)
            {
                item.LanguageLevel = ll;
                item.WorkerFK = WorkerVO.Id;
            }

            WorkAspirationsSource = new List<WorkAspirationVO>();
            foreach (var item in WebNomenclatorsCache.Instance.Workplaces)
            {
                WorkAspirationsSource.Add(new WorkAspirationVO()
                {
                    WorkerFK = WorkerVO.Id,
                    Workplace = item,
                });
            }
        }

        private ObservableCollection<CourseVO> selectedCourses;
        private ObservableCollection<DriverLicenseVO> selectedLicenses;
        private ObservableCollection<VehicleVO> selectedVehicles;
        private ObservableCollection<WorkAspirationVO> selectedWorkAspirations;
        private ObservableCollection<WorkerLanguageVO> selectedWorkerLanguages;
        private ObservableCollection<WorkReferenceVO> selectedWorkReferences;

        public WorkerVO WorkerVO { get; set; }
        public Gender Gender
        {
            get { return WorkerVO.Gender.Name == "Masculino" ? Gender.Masculino : Gender.Femenino; }
            set
            {
                WorkerVO.Gender = WebNomenclatorsCache.Instance.Genders.Where(x => x.Name == value.ToString()).FirstOrDefault();
                OnPropertyChanged();
            }
        }
        public List<WorkerLanguageVO> WorkerLanguagesSource { get; set; }
        public List<WorkAspirationVO> WorkAspirationsSource { get; set; }
        public ObservableCollection<CourseVO> SelectedCourses
        {
            get
            {
                return selectedCourses;
            }
            set
            {
                SetProperty(ref selectedCourses, value);
            }
        }
        public ObservableCollection<DriverLicenseVO> SelectedLicenses
        {
            get { return selectedLicenses; }
            set { SetProperty(ref selectedLicenses, value); }
        }
        public ObservableCollection<VehicleVO> SelectedVehicles
        {
            get { return selectedVehicles; }
            set { SetProperty(ref selectedVehicles, value); }
        }
        public ObservableCollection<WorkAspirationVO> SelectedWorkAspirations
        {
            get
            {
                return selectedWorkAspirations;
            }
            set
            {
                SetProperty(ref selectedWorkAspirations, value);
            }
        }
        public ObservableCollection<WorkerLanguageVO> SelectedWorkerLanguages
        {
            get
            {
                return selectedWorkerLanguages;
            }
            set
            {
                SetProperty(ref selectedWorkerLanguages, value);
            }
        }
        public ObservableCollection<WorkReferenceVO> SelectedWorkReferences
        {
            get { return selectedWorkReferences; }
            set { SetProperty(ref selectedWorkReferences, value); }
        }

    }
}
