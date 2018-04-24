using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.UserViewMoldels
{
    public class SaleCredCuponViewModel : EMViewModelBase
    {
        public SaleCredCuponViewModel(EMMainViewModel emMainViewModel) : base(emMainViewModel)
        {
            CentralEMMain.Subitle = "VENTA DE CUPÓN DE CRÉDITO";
        }
        
        public UserClientRole SelectedClientType { get; set; }
    }
}
