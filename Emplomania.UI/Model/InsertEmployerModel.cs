using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.Data.VO.Base;
using Emplomania.UI.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.Model
{
    public class InsertEmployerModel : InsertClientModel
    {
        public EmployerVO EmployerVO { get; set; }
        public BusinessVO BusinessVO { get; set; }

        public ProvinceVO Province { get; set; }
        public ProvinceVO ProvinceNeg { get; set; }

        private MunicipalityVO municipality;
        public MunicipalityVO Municipality
        {
            get
            {
                return municipality;
            }
            set
            {
                SetProperty(ref municipality, value);
                if(value!=null)
                    UserVO.MunicipalityFK = value.Id;
            }
        }

        private MunicipalityVO municipalityNeg;
        public MunicipalityVO MunicipalityNeg
        {
            get
            {
                return municipalityNeg;
            }
            set
            {
                SetProperty(ref municipalityNeg, value);
                if(value!=null)
                    BusinessVO.MunicipalityFK = value.Id;
            }
        }

        private CategoryVO categoryNeg;
        public CategoryVO CategoryNeg
        {
            get { return categoryNeg; }
            set
            {
                SetProperty(ref categoryNeg, value);
                if(value!=null)
                    BusinessVO.CategoryFK = value.Id;
            }
        }

        public WorkplaceVO Place0
        {
            get
            {
                return BusinessVO.WorkPlaces[0];
            }
            set
            {
                BusinessVO.WorkPlaces[0] = value;
                OnPropertyChanged();
            }
        }
        public WorkplaceVO Place1
        {
            get
            {
                return BusinessVO.WorkPlaces[1];
            }
            set
            {
                BusinessVO.WorkPlaces[1] = value;
                OnPropertyChanged();
            }
        }
        public WorkplaceVO Place2
        {
            get
            {
                return BusinessVO.WorkPlaces[2];
            }
            set
            {
                BusinessVO.WorkPlaces[2] = value;
                OnPropertyChanged();
            }
        }
        public WorkplaceVO Place3
        {
            get
            {
                return BusinessVO.WorkPlaces[3];
            }
            set
            {
                BusinessVO.WorkPlaces[3] = value;
                OnPropertyChanged();
            }
        }
        public WorkplaceVO Place4
        {
            get
            {
                return BusinessVO.WorkPlaces[4];
            }
            set
            {
                BusinessVO.WorkPlaces[4] = value;
                OnPropertyChanged();
            }
        }
        public WorkplaceVO Place5
        {
            get
            {
                return BusinessVO.WorkPlaces[5];
            }
            set
            {
                BusinessVO.WorkPlaces[5] = value;
                OnPropertyChanged();
            }
        }
        public WorkplaceVO Place6
        {
            get
            {
                return BusinessVO.WorkPlaces[6];
            }
            set
            {
                BusinessVO.WorkPlaces[6] = value;
                OnPropertyChanged();
            }
        }


    }
}
