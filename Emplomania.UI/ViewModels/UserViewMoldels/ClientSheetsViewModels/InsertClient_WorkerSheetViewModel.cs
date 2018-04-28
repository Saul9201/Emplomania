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
    public class InsertClient_WorkerSheetViewModel : EMViewModelBase
    {
        public InsertWorkerModel InsertWorkerModel { get; set; }
        public InsertClient_WorkerSheetViewModel(EMMainViewModel centralEMMain, InsertWorkerModel insertWorkerModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "ficha del trabajador";
            CentralEMMain.ResetScrollContent();
            InsertWorkerModel = insertWorkerModel;
        }
    }
}
