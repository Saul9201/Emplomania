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
            CentralEMMain.ResetScrollContent();
        }
    }
}
