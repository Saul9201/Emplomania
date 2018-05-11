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
        //TODO
        //public static InsertWorkerModel Build(UserVO worker)
        //{ 
        
        //    var res = new InsertWorkerModel()
        //    {
        //        WorkerVO = worker,
        //        UserVO = worker.User,
        //        AuthenticationTypes = worker.User.AuthenticationType,
        //        Childrens = worker.Childrens ? YesNotAnswer.Yes : YesNotAnswer.No,
        //    };

        //}
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
        public ProvinceVO Province { get; set; }


        public InsertWorkerModel()
        {
            SelectedCourses = new ObservableCollection<CourseVO>();
            SelectedLicenses = new ObservableCollection<DriverLicenseVO>();
            SelectedVehicles = new ObservableCollection<VehicleVO>();
            SelectedWorkAspirations = new ObservableCollection<WorkAspirationVO>();
            SelectedWorkerLanguages = new ObservableCollection<WorkerLanguageVO>();
            SelectedWorkReferences = new ObservableCollection<WorkReferenceVO>();
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

        private ObservableCollection<WorkerLanguageVO> selectedWorkerLanguages;
        public ObservableCollection<WorkerLanguageVO> SelectedWorkerLanguages
        {
            get { return selectedWorkerLanguages; }
            set { SetProperty(ref selectedWorkerLanguages, value); }
        }

        private ObservableCollection<WorkReferenceVO> selectedWorkReferences;
        public ObservableCollection<WorkReferenceVO> SelectedWorkReferences
        {
            get { return selectedWorkReferences; }
            set { SetProperty(ref selectedWorkReferences, value); }
        }



        //public YesNotAnswer Childrens
        //{
        //    get { return WorkerVO.Childrens?YesNotAnswer.Yes:YesNotAnswer.No; }
        //    set
        //    {
        //        OnPropertyChanged();
        //        WorkerVO.Childrens = value == YesNotAnswer.Yes;
        //    }
        //}
        //private MunicipalityVO municipality;
        //public MunicipalityVO Municipality
        //{
        //    get { return municipality; }
        //    set
        //    {
        //        SetProperty(ref municipality, value);
        //        if (municipality != null)
        //            UserVO.MunicipalityFK = municipality.Id;
        //    }
        //}


        //private EyeColorVO eyeColor;
        //private SkinColorVO skinColor;
        //private ComplexionVO complexion;
        //private CivilStatusVO civilStatus;
        //private SchoolGradeVO schoolGrade;
        //private SpecialtyVO specialty;
        //public EyeColorVO EyeColor
        //{
        //    get { return eyeColor; }
        //    set
        //    {
        //        SetProperty(ref eyeColor, value);
        //        WorkerVO.EyeColorFK = value?.Id;
        //    }
        //}
        //public SkinColorVO SkinColor
        //{
        //    get
        //    {
        //        return skinColor;
        //    }
        //    set
        //    {
        //        SetProperty(ref skinColor, value);
        //        WorkerVO.SkinColorFK = skinColor?.Id;
        //    }
        //}
        //public ComplexionVO Complexion
        //{
        //    get
        //    {
        //        return complexion;
        //    }
        //    set
        //    {
        //        SetProperty(ref complexion, value);
        //        WorkerVO.ComplexionFK = complexion?.Id;
        //    }
        //}
        //public CivilStatusVO CivilStatus
        //{
        //    get
        //    {
        //        return civilStatus;
        //    }
        //    set
        //    {
        //        SetProperty(ref civilStatus, value);
        //        WorkerVO.CivilStatusFK = value?.Id;
        //    }
        //}
        //public SchoolGradeVO SchoolGrade
        //{
        //    get
        //    {
        //        return schoolGrade;
        //    }
        //    set
        //    {
        //        SetProperty(ref schoolGrade, value);
        //        WorkerVO.SchoolGradeFK = schoolGrade?.Id;
        //    }
        //}
        //public SpecialtyVO Specialty
        //{
        //    get
        //    {
        //        return specialty;
        //    }
        //    set
        //    {
        //        SetProperty(ref specialty, value);
        //        WorkerVO.SpecialtyFK = specialty?.Id;
        //    }
        //}


        //public WorkReferenceVO[] WorkReferences { get; set; } = new WorkReferenceVO[5];
        //public WorkReferenceVO Wr0
        //{
        //    get
        //    {
        //        if (WorkReferences[0] == null)
        //            WorkReferences[0] = new WorkReferenceVO();
        //        return WorkReferences[0];
        //    }
        //    set
        //    {
        //        WorkReferences[0] = value;
        //    }
        //}
        //public WorkReferenceVO Wr1
        //{
        //    get
        //    {
        //        if (WorkReferences[1] == null)
        //            WorkReferences[1] = new WorkReferenceVO();
        //        return WorkReferences[1];
        //    }
        //    set
        //    {
        //        WorkReferences[1] = value;
        //    }
        //}
        //public WorkReferenceVO Wr2
        //{
        //    get
        //    {
        //        if (WorkReferences[2] == null)
        //            WorkReferences[2] = new WorkReferenceVO();
        //        return WorkReferences[2];
        //    }
        //    set
        //    {
        //        WorkReferences[2] = value;
        //    }
        //}
        //public WorkReferenceVO Wr3
        //{
        //    get
        //    {
        //        if (WorkReferences[3] == null)
        //            WorkReferences[3] = new WorkReferenceVO();
        //        return WorkReferences[3];
        //    }
        //    set
        //    {
        //        WorkReferences[3] = value;
        //    }
        //}
        //public WorkReferenceVO Wr4
        //{
        //    get
        //    {
        //        if (WorkReferences[4] == null)
        //            WorkReferences[4] = new WorkReferenceVO();
        //        return WorkReferences[4];
        //    }
        //    set
        //    {
        //        WorkReferences[4] = value;
        //    }
        //}

    }
}
