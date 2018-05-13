using Emplomania.Data.Services;
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
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Emplomania.UI.ViewModels.UserViewMoldels.InsertClientViewModels
{
    public class InsertClient_CreatePerfil2ViewModel : EMViewModelBase
    {
        public InsertWorkerModel InsertWorkerModel { get; set; }
        public bool FromWorkerSheet { get; set; }
        
        public ICommand AddWorkReferenceComand => new RelayCommand(param =>
        {
            if (InsertWorkerModel?.SelectedWorkReferences == null)
                throw new Exception("Error no controlado");
            RadWindow.Prompt(new DialogParameters
            {
                Content = "Nombre del lugar.",
                Owner = Application.Current.MainWindow,
                Closed = new EventHandler<WindowClosedEventArgs>(OnAddWorkerPromptClosed)
            });
        });

        public ICommand DeleteWorkReferenceReferenceCommand => new RelayCommand(param =>
        {
            var toDel = param as WorkReferenceVO;
            if (!InsertWorkerModel.SelectedWorkReferences.Remove(toDel))
                MessageBox.Show("Error Interno");
        });

        private void OnAddWorkerPromptClosed(object sender, WindowClosedEventArgs e)
        {
            if(e.DialogResult!=null && e.DialogResult == true)
            {
                if (string.IsNullOrEmpty(e.PromptResult))
                {
                    MessageBox.Show("Debe introducir un lugar.");
                    return;
                }
                if (InsertWorkerModel.SelectedWorkReferences.Any(x => x.Place == e.PromptResult))
                {
                    MessageBox.Show("El lugar que decea introducir ya existe.");
                }
                else
                {
                    InsertWorkerModel.SelectedWorkReferences.Add(new WorkReferenceVO() { WorkerFK = InsertWorkerModel.WorkerVO.Id, Place = e.PromptResult });
                }
            }
        }
        public InsertClient_CreatePerfil2ViewModel(EMMainViewModel centralEMMain, InsertWorkerModel insertWorkerModel) : base(centralEMMain)
        {
            CentralEMMain.Subitle = "crear perfil trabajador (paso 2)";
            InsertWorkerModel = insertWorkerModel;
            CentralEMMain.ResetScrollContent();
            
        }
        
        
    }
}
