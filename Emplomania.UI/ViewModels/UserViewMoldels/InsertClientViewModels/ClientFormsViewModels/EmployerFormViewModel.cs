using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.ViewModels.UserViewMoldels.InsertClientViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emplomania.UI.ViewModels.UserViewMoldels.ClientFormsViewModels
{
    public class EmployerFormViewModel : EMViewModelBase
    {
        public InsertEmployerModel InsertEmployerModel { get; set; }

        private ProvinceVO province;
        public ProvinceVO Province
        {
            get { return province; }
            set
            {
                province = value;
                InsertEmployerModel.Province = province;
                if (province != null)
                    Municipalities = ServiceLocator.Get<IMunicipalityService>().GetMunicByProvince(province.Id).ToList();
                else
                    Municipalities = new List<MunicipalityVO>();
            }
        }

        private List<MunicipalityVO> municipalities;
        public List<MunicipalityVO> Municipalities
        {
            get { return municipalities; }
            set
            {
                SetProperty(ref municipalities, value);
            }
        }

        private ProvinceVO provinceNeg;
        public ProvinceVO ProvinceNeg
        {
            get { return provinceNeg; }
            set
            {
                provinceNeg = value;
                InsertEmployerModel.ProvinceNeg = provinceNeg;
                if (provinceNeg != null)
                    MunicipalitiesNeg = ServiceLocator.Get<IMunicipalityService>().GetMunicByProvince(provinceNeg.Id).ToList();
                else
                    MunicipalitiesNeg = new List<MunicipalityVO>();
            }
        }

        private List<MunicipalityVO> municipalitiesNeg;
        public List<MunicipalityVO> MunicipalitiesNeg
        {
            get { return municipalitiesNeg; }
            set
            {
                SetProperty(ref municipalitiesNeg, value);
            }
        }

        public ICommand SelectImagePerfilCommand => new RelayCommand(param =>
        {
            OpenFileDialog fd = new OpenFileDialog()
            {
                DefaultExt = ".png",
                CheckFileExists = true,
                Multiselect = false,
                Filter = "Archivos de imágenes|*.bmp;*.jpg;*.png",
            };
            if (fd.ShowDialog().GetValueOrDefault())
            {
                InsertEmployerModel.UserVO.ProfileImage = Image.FromFile(fd.FileName);
            }
        });

        public EmployerFormViewModel(EMMainViewModel centralEMMain, InsertEmployerModel insertEmployerModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "crear perfil empleador";
            InsertEmployerModel = insertEmployerModel;
            if (InsertEmployerModel.Province != null)
                Province = InsertEmployerModel.Province;
            if (InsertEmployerModel.Municipality != null)
                InsertEmployerModel.Municipality = Municipalities.Where(x => x.Id == InsertEmployerModel.Municipality.Id).FirstOrDefault();

            if (InsertEmployerModel.ProvinceNeg != null)
                ProvinceNeg = InsertEmployerModel.ProvinceNeg;
            if (InsertEmployerModel.MunicipalityNeg != null)
                InsertEmployerModel.MunicipalityNeg = MunicipalitiesNeg.Where(x => x.Id == InsertEmployerModel.MunicipalityNeg.Id).FirstOrDefault();
        }
    }
}
