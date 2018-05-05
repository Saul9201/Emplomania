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


        private IEnumerable<WorkplaceVO> workplaces;
        public IEnumerable<WorkplaceVO> Workplaces
        {
            get
            {
                if (workplaces == null)
                    workplaces = ServiceLocator.Get<IBusinessService>().GetWorkPlaces(InsertEmployerModel.BusinessVO.Id);
                return workplaces;
            }
            set { workplaces = value; }
        }
        public InsertClient_EmployerSheetViewModel(EMMainViewModel centralEMMain, InsertEmployerModel insertEmployerModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "ficha del empleador";
            InsertEmployerModel = insertEmployerModel;
            CentralEMMain.ResetScrollContent();
        }

    }
}
