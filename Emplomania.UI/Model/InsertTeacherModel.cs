using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emplomania.Data.VO;

namespace Emplomania.UI.Model
{
    public class InsertTeacherModel : InsertClientModel
    {
        public InsertTeacherModel(UserVO userVO)
        {
            UserVO = userVO;
        }
    }
}
