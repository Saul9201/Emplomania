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
        public WorkerVO WorkerVO { get; set; }

        private Gender gender;
        public Gender Gender
        {
            get { return gender; }
            set
            {
                SetProperty(ref gender, value);
                WorkerVO.GenderFK = ServiceLocator.Get<IGenderService>().Get(x => x.Name == gender.ToString()).Id;
            }
        }

        private YesNotAnswer childrens;
        public YesNotAnswer Childrens
        {
            get { return childrens; }
            set
            {
                SetProperty(ref childrens, value);
                WorkerVO.Childrens = childrens == YesNotAnswer.Yes;
            }
        }

        public InsertWorkerModel()
        {
            SelectedCourses = new ObservableCollection<CourseVO>();
            SelectedLicenses = new ObservableCollection<DriverLicenseVO>();
            SelectedVehicles = new ObservableCollection<VehicleVO>();
            SelectedWorkAspirations = new ObservableCollection<WorkAspirationVO>();
        }

        private ObservableCollection<CourseVO> selectedCourses;
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

        private ObservableCollection<DriverLicenseVO> selectedLicenses;
        public ObservableCollection<DriverLicenseVO> SelectedLicenses
        {
            get { return selectedLicenses; }
            set { SetProperty(ref selectedLicenses, value); }
        }

        private ObservableCollection<VehicleVO> selectedVehicles;
        public ObservableCollection<VehicleVO> SelectedVehicles
        {
            get { return selectedVehicles; }
            set { SetProperty(ref selectedVehicles, value); }
        }

        private ObservableCollection<WorkAspirationVO> selectedWorkAspirations;
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


        private EyeColorVO eyeColor;
        private SkinColorVO skinColor;
        private ComplexionVO complexion;
        private CivilStatusVO civilStatus;
        private SchoolGradeVO schoolGrade;
        private SpecialtyVO specialty;
        public EyeColorVO EyeColor
        {
            get { return eyeColor; }
            set
            {
                SetProperty(ref eyeColor, value);
                WorkerVO.EyeColorFK = value?.Id;
            }
        }
        public SkinColorVO SkinColor
        {
            get
            {
                return skinColor;
            }
            set
            {
                SetProperty(ref skinColor, value);
                WorkerVO.SkinColorFK = skinColor?.Id;
            }
        }
        public ComplexionVO Complexion
        {
            get
            {
                return complexion;
            }
            set
            {
                SetProperty(ref complexion, value);
                WorkerVO.ComplexionFK = complexion?.Id;
            }
        }
        public CivilStatusVO CivilStatus
        {
            get
            {
                return civilStatus;
            }
            set
            {
                SetProperty(ref civilStatus, value);
                WorkerVO.CivilStatusFK = value?.Id;
            }
        }
        public SchoolGradeVO SchoolGrade
        {
            get
            {
                return schoolGrade;
            }
            set
            {
                SetProperty(ref schoolGrade, value);
                WorkerVO.SchoolGradeFK = schoolGrade?.Id;
            }
        }
        public SpecialtyVO Specialty
        {
            get
            {
                return specialty;
            }
            set
            {
                SetProperty(ref specialty, value);
                WorkerVO.SpecialtyFK = specialty?.Id;
            }
        }

        public ProvinceVO Province { get; set; }

        private MunicipalityVO municipality;
        public MunicipalityVO Municipality
        {
            get { return municipality; }
            set
            {
                SetProperty(ref municipality, value);
                if (municipality != null)
                    UserVO.MunicipalityFK = municipality.Id;
            }
        }

        public WorkerLanguageVO[] Languages { get; set; } = new WorkerLanguageVO[5];
        public WorkerLanguageVO Wl0
        {
            get
            {
                if (Languages[0] == null)
                    Languages[0] = new WorkerLanguageVO();
                return Languages[0];
            }
            set { Languages[0] = value; }
        }
        public WorkerLanguageVO Wl1
        {
            get
            {
                if (Languages[1] == null)
                    Languages[1] = new WorkerLanguageVO();
                return Languages[1];
            }
            set { Languages[1] = value; }
        }
        public WorkerLanguageVO Wl2
        {
            get
            {
                if (Languages[2] == null)
                    Languages[2] = new WorkerLanguageVO();
                return Languages[2];
            }
            set { Languages[2] = value; }
        }
        public WorkerLanguageVO Wl3
        {
            get
            {
                if (Languages[3] == null)
                    Languages[3] = new WorkerLanguageVO();
                return Languages[3];
            }
            set { Languages[3] = value; }
        }
        public WorkerLanguageVO Wl4
        {
            get
            {
                if (Languages[4] == null)
                    Languages[4] = new WorkerLanguageVO();
                return Languages[4];
            }
            set { Languages[4] = value; }
        }

        public WorkReferenceVO[] WorkReferences { get; set; } = new WorkReferenceVO[5];
        public WorkReferenceVO Wr0
        {
            get
            {
                if (WorkReferences[0] == null)
                    WorkReferences[0] = new WorkReferenceVO();
                return WorkReferences[0];
            }
            set
            {
                WorkReferences[0] = value;
            }
        }
        public WorkReferenceVO Wr1
        {
            get
            {
                if (WorkReferences[1] == null)
                    WorkReferences[1] = new WorkReferenceVO();
                return WorkReferences[1];
            }
            set
            {
                WorkReferences[1] = value;
            }
        }
        public WorkReferenceVO Wr2
        {
            get
            {
                if (WorkReferences[2] == null)
                    WorkReferences[2] = new WorkReferenceVO();
                return WorkReferences[2];
            }
            set
            {
                WorkReferences[2] = value;
            }
        }
        public WorkReferenceVO Wr3
        {
            get
            {
                if (WorkReferences[3] == null)
                    WorkReferences[3] = new WorkReferenceVO();
                return WorkReferences[3];
            }
            set
            {
                WorkReferences[3] = value;
            }
        }
        public WorkReferenceVO Wr4
        {
            get
            {
                if (WorkReferences[4] == null)
                    WorkReferences[4] = new WorkReferenceVO();
                return WorkReferences[4];
            }
            set
            {
                WorkReferences[4] = value;
            }
        }
        
    }
}
