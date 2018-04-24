using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.UserViewMoldels
{
    public class InsertBankDepositViewModel : EMViewModelBase
    {
        public InsertBankDepositViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "Insertar depósito bancario";
        }
    }
}
