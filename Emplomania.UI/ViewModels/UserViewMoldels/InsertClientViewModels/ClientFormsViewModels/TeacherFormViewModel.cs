using Emplomania.Data.VO;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.ViewModels.UserViewMoldels.InsertClientViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.UserViewMoldels.ClientFormsViewModels
{
    public class TeacherFormViewModel : EMViewModelBase
    {
        public InsertTeacherModel InsertTeacherModel { get; set; }
        public TeacherFormViewModel(EMMainViewModel centralEMMain, InsertTeacherModel insertTeacherModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "crear perfil profesor";
            InsertTeacherModel = insertTeacherModel;
            CentralEMMain.ResetScrollContent();
        }
    }
}
