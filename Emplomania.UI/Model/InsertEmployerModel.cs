using Emplomania.Data.Services;
using Emplomania.Data.VO;
using Emplomania.Data.VO.Base;
using Emplomania.UI.Infrastucture;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Emplomania.Infrastucture.Enums;
using System.Threading.Tasks;

namespace Emplomania.UI.Model
{
    public class InsertEmployerModel : InsertClientModel
    {
        public InsertEmployerModel(UserVO user)
        {
            UserClientRole = UserClientRole.Empleador;
            UserVO = user;

            EmployerVO = ServiceLocator.Get<IEmployerService>().Get(x => x.UserFK == user.Id);
            if (EmployerVO == null)//Caso que se crea un objeto insertemployer correspondiente a un nuevo empleador
            {
                EmployerVO = new EmployerVO()
                {
                    Id = Guid.NewGuid(),
                    UserFK = UserVO.Id
                };

                BusinessVO = new BusinessVO()
                {
                    Id = Guid.NewGuid(),
                    EmployerFK = EmployerVO.Id
                };
            }
            else //Caso que se crea un objeto insertemployer correspondiente a un empleador existente
            {
                BusinessVO = ServiceLocator.Get<IBusinessService>().Get(x => x.EmployerFK == EmployerVO.Id);
                BusinessVO = ServiceLocator.Get<IBusinessService>().LoadEnumerablesProperties(BusinessVO);
                if (BusinessVO == null)
                {
                    BusinessVO = new BusinessVO()
                    {
                        Id = Guid.NewGuid(),
                        EmployerFK = EmployerVO.Id
                    };
                }
                else
                {
                    if (BusinessVO.Municipality != null)
                    {
                        ProvinceNeg = WebNomenclatorsCache.Instance.Provinces.Where(x => x.Id == BusinessVO.Municipality.ProvinciaId).FirstOrDefault();
                    }
                }

                if (UserVO.Municipality != null)
                {
                    Province = WebNomenclatorsCache.Instance.Provinces.Where(x => x.Id == UserVO.Municipality.ProvinciaId).FirstOrDefault();
                }
            }
            SelectedWorkplaces = BusinessVO.Workplaces == null ? new ObservableCollection<WorkplaceVO>() : new ObservableCollection<WorkplaceVO>(BusinessVO.Workplaces);
        }

        private ProvinceVO provinceNeg;
        private List<MunicipalityVO> municipalitiesNeg;

        public EmployerVO EmployerVO { get; set; }
        public BusinessVO BusinessVO { get; set; }
        public ProvinceVO ProvinceNeg
        {
            get { return provinceNeg; }
            set
            {
                provinceNeg = value;
                if (provinceNeg != null)
                    MunicipalitiesNeg = WebNomenclatorsCache.Instance.Municipalities.Where(x => x.ProvinciaId == value.Id).ToList();
                else
                    MunicipalitiesNeg = new List<MunicipalityVO>();
            }
        }
        public List<MunicipalityVO> MunicipalitiesNeg
        {
            get { return municipalitiesNeg; }
            set
            {
                SetProperty(ref municipalitiesNeg, value);
            }
        }
        public ObservableCollection<WorkplaceVO> SelectedWorkplaces { get; set; }


    }
}
