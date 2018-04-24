using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.ServicesViewModels
{
    public class QueryUserToRecomendationLevelViewModel : EMViewModelBase
    {
        public QueryUserToRecomendationLevelViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            

        }

        public IEnumerable<UserClientModel> UserClientCollection { get; set; }

    }
}
