using Emplomania.Data.VO;
using Emplomania.UI.Infrastucture;
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
    public class InsertClient_CreatePerfil3ViewModel : EMViewModelBase
    {
        public InsertWorkerModel InsertWorkerModel { get; set; }

        public List<WorkAspirationVO> WorkAspirationsSource { get; set; }
        public InsertClient_CreatePerfil3ViewModel(EMMainViewModel centralEMMain, InsertWorkerModel insertWorkerModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "crear perfil trabajador (paso 3)";
            InsertWorkerModel = insertWorkerModel;
            CentralEMMain.ResetScrollContent();
            WorkAspirationsSource = new List<WorkAspirationVO>();
            foreach (var item in WebNomenclatorsCache.Instance.Workplaces)
            {
                WorkAspirationsSource.Add(new WorkAspirationVO()
                {
                    WorkerFK = InsertWorkerModel.WorkerVO.Id,
                    Workplace = item,
                });
            }
        }

    }
}
