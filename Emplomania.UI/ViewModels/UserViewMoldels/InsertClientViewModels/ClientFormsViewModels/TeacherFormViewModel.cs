using Emplomania.Data.VO;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.ViewModels.UserViewMoldels.InsertClientViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emplomania.UI.ViewModels.UserViewMoldels.ClientFormsViewModels
{
    public class TeacherFormViewModel : EMViewModelBase
    {
        public InsertTeacherModel InsertTeacherModel { get; set; }

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
                InsertTeacherModel.UserVO.ProfileImage = Image.FromFile(fd.FileName);
            }
        });

        public TeacherFormViewModel(EMMainViewModel centralEMMain, InsertTeacherModel insertTeacherModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "crear perfil profesor";
            InsertTeacherModel = insertTeacherModel;
            CentralEMMain.ResetScrollContent();
        }
    }
}
