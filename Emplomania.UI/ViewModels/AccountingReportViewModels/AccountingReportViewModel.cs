using Emplomania.UI.Infrastucture;
using Emplomania.UI.Model;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emplomania.UI.ViewModels.AccountingReportViewModels
{
    public class AccountingReportViewModel : EMViewModelBase
    {
        public DateTime? InitDate { get; set; }
        public DateTime? FinalDate { get; set; }

        private AccountingReportModel accountingReportModel;
        public AccountingReportModel AccountingReportModel
        {
            get { return accountingReportModel; }
            set { SetProperty(ref accountingReportModel, value); }
        }

        public ICommand SearchCommand => new RelayCommand(param =>
        {
            //TODO:Calcular aqui el reporte contable mediante IncomeService
        });


        public AccountingReportViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            AccountingReportModel = new AccountingReportModel();
        }
    }
}
