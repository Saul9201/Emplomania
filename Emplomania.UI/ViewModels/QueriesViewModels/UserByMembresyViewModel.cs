using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.QueriesViewModels
{
    public class UserByMembresyViewModel : EMViewModelBase
    {
        public UserByMembresyViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            Subtitle = "usuarios por membresía";
        }


        
    }
}
