using Emplomania.UI.Infrastucture;
using Emplomania.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.ViewModels.ServicesViewModels
{
    public class InsertRecomendationViewModel : EMViewModelBase
    {
        public InsertRecomendationViewModel(EMMainViewModel emMainViewModel) : base(emMainViewModel)
        {
            Subtitle = "INSERTAR NIVEL DE RECOMENDACIÓN";
        }

        //Propiedades Bindeadas
        public string ClientName { get; set; }

        private string psicometricEvaluation;
        public string PsicometricEvaluation
        {
            get { return psicometricEvaluation; }
            set
            {
                SetProperty(ref psicometricEvaluation, value);
            }
        }

        private string referenceResults;
        public string ReferenceResults
        {
            get { return referenceResults; }
            set
            {
                SetProperty(ref referenceResults, value);
            }
        }

        private string evaluatorRecomenation;
        public string EvaluatorRecomenation
        {
            get { return evaluatorRecomenation; }
            set
            {
                SetProperty(ref evaluatorRecomenation, value);
            }
        }

        public ScaleNR Scale { get; set; }
    }
}
