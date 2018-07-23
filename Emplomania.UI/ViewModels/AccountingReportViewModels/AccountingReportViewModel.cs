using Emplomania.Data.Model;
using Emplomania.Data.Services;
using Emplomania.Infrastucture.Enums;
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
        public DateTime? EndDate { get; set; }
        public ClientCategory SelectedClientCategory { get; set; }

        private AccountingReportModel accountingReportModel;
        public AccountingReportModel AccountingReportModel
        {
            get { return accountingReportModel; }
            set { SetProperty(ref accountingReportModel, value); }
        }

        public ICommand SearchCommand => new RelayCommand(param =>
        {
            SelectedClientCategory = ClientCategory.CommonCustomer;
            AccountingReportModel = ServiceLocator.Get<IIncomeService>().GetReport(InitDate,EndDate, SelectedClientCategory);
        });


        public AccountingReportViewModel(EMMainViewModel centralEMMain) : base(centralEMMain)
        {
            Subtitle = "Reporte Contable";
            AccountingReportModel = new AccountingReportModel();
        }
    }
}
