using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.PaymentGatewayViewModels
{
    public class PaymentGatewayViewModel : EMViewModelBase
    {
        public bool UserClientIdetityKnow { get; set; } = false;
        public PaymentGatewayViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "Pasarela de pago";
        }

        public UserClientRole SelectedClientType { get; set; }
    }
}
