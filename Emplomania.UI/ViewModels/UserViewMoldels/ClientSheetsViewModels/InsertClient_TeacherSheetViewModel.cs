using Emplomania.Data.VO;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.ViewModels.PaymentGatewayViewModels;
using Emplomania.UI.ViewModels.UserViewMoldels.ClientFormsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.UserViewMoldels.InsertClientViewModels
{
    public class InsertClient_TeacherSheetViewModel : EMViewModelBase
    {
        public InsertTeacherModel InsertTeacherModel { get; set; }
        public InsertClient_TeacherSheetViewModel(EMMainViewModel centralEMMain, InsertTeacherModel insertTeacherModel) : base(centralEMMain)
        {
            Subtitle = "ficha del profesor";
            InsertTeacherModel = insertTeacherModel;
        }

    }
}
