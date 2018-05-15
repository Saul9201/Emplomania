using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.UI.Infrastucture;
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
    public class InsertClient_EmployerSheetViewModel : EMViewModelBase
    {
        public InsertEmployerModel InsertEmployerModel { get; set; }
        
        public InsertClient_EmployerSheetViewModel(EMMainViewModel centralEMMain, InsertEmployerModel insertEmployerModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "ficha del empleador";
            InsertEmployerModel = insertEmployerModel;
            CentralEMMain.ResetScrollContent();
        }

    }
}
