using Emplomania.Data.VO;
using Emplomania.UI.Infrastucture;
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
    public class InsertClient_NaturalViewModel : EMViewModelBase
    {
        public InsertClientModel InsertClientModel { get; set; }

        public InsertClient_NaturalViewModel(EMMainViewModel centralEMMain, InsertClientModel insertClientModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "Insertar cliente natural";
            InsertClientModel = insertClientModel;
        }
        
    }
}
