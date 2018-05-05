using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.ViewModels.StartViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emplomania.UI.ViewModels.UserViewMoldels.InsertClientViewModels
{
    public class InsertClient_CreatePerfil1ViewModel : EMViewModelBase
    {
        public InsertWorkerModel InsertWorkerModel { get; set; }
        public bool FromWorkerSheet { get; set; }
        private ProvinceVO province;
        public ProvinceVO Province
        {
            get { return province; }
            set
            {
                province = value;
                InsertWorkerModel.Province = province;
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
                InsertWorkerModel.UserVO.ProfileImage = Image.FromFile(fd.FileName);
            }
        });

        public InsertClient_CreatePerfil1ViewModel(EMMainViewModel centralEMMain, InsertWorkerModel insertWorkerModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "crear perfil trabajador (paso 1)";
            InsertWorkerModel = insertWorkerModel;

            if (InsertWorkerModel.Province != null)
                Province = InsertWorkerModel.Province;
            if (InsertWorkerModel.Municipality != null)
                InsertWorkerModel.Municipality = Municipalities.Where(x => x.Id == InsertWorkerModel.Municipality.Id).FirstOrDefault();

        }

    }
}
