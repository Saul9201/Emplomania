using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.ServicesViewModels
{
    public class QueryUserWithRecomendationLevelViewModel : EMViewModelBase
    {
        public QueryUserWithRecomendationLevelViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            Subtitle = "USUARIOS CON NIVEL DE RECOMENDACIóN (DETALLES)";

        }

        public IEnumerable<UserClientModel> UserClientCollection { get; set; }

    }
}
