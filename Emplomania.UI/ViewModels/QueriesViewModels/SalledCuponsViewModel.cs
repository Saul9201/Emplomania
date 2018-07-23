using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.QueriesViewModels
{
    public class SalledCuponsViewModel : EMViewModelBase
    {
        public SalledCuponsViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            Subtitle = "Cupones Vendidos";
        }
    }
}
