using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.Views.UserViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.UserViewMoldels
{
    public class AlterClientViewModel : EMViewModelBase
    {
        public AlterClientViewModel(EMMainViewModel emMainViewModel) : base(emMainViewModel)
        {
            CentralEMMain.Subitle = "MODIFICAR CLIENTE";
        }

        //PROPIEDADES BINDEADAS
        public UserClientRole SelectedClientType { get; set; }
        public string UserName { get; set; }
        
    }
}
