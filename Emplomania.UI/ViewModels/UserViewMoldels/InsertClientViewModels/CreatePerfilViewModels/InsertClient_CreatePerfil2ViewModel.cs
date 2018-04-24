using Emplomania.Data.VO;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using Emplomania.UI.ViewModels.StartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.UserViewMoldels.InsertClientViewModels
{
    public class InsertClient_CreatePerfil2ViewModel : EMViewModelBase
    {
        public InsertWorkerModel InsertWorkerModel { get; set; }
        public bool FromWorkerSheet { get; set; }

        public InsertClient_CreatePerfil2ViewModel(EMMainViewModel centralEMMain, InsertWorkerModel insertWorkerModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "crear perfil trabajador (paso 2)";
            InsertWorkerModel = insertWorkerModel;
            CentralEMMain.ResetScrollContent();
        }
        
        
    }
}
