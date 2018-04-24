using Emplomania.Data.VO;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.ViewModels.UserViewMoldels.ClientFormsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.UserViewMoldels.InsertClientViewModels
{
    public class InsertClient_ByInvitationViewModel : EMViewModelBase
    {
        public InsertClientModel InsertClientModel { get; set; }

        public InsertClient_ByInvitationViewModel(EMMainViewModel centralEMMain, InsertClientModel insertClientModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "Insertar cliente por invitación";
            InsertClientModel = insertClientModel;
        }
    }
}
