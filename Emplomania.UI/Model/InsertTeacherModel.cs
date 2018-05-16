using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emplomania.Data.VO;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using Emplomania.Data.Services;

namespace Emplomania.UI.Model
{
    public class InsertTeacherModel : InsertClientModel
    {
        public InsertTeacherModel(UserVO user)
        {
            UserClientRole = UserClientRole.Profesor;
            UserVO = user;

            TeacherVO = ServiceLocator.Get<ITeacherService>().Get(x => x.UserFK == user.Id);
            if (TeacherVO == null)//Caso que se crea un objeto insertTeacher correspondiente a un nuevo teacher
            {
                TeacherVO = new TeacherVO()
                {
                    Id = Guid.NewGuid(),
                    UserFK = user.Id,
                };
            }
            else//Caso que se crea un objeto insertTeacher correspondiente a un teacher existente
            {
                if (UserVO.Municipality != null)
                {
                    Province = WebNomenclatorsCache.Instance.Provinces.Where(x => x.Id == UserVO.Municipality.ProvinciaId).FirstOrDefault();
                }
            }

        }

        public TeacherVO TeacherVO { get; set; }

    }
}
