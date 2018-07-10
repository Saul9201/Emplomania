using Emplomania.Data.VO;
using Emplomania.Data.VO.Base;
using Emplomania.Infrastucture.Enums;
using Emplomania.UI.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.Model
{
    //TODO: OJO Recordar elimnar esta clase
    public class UserClientModel:BindableBase
    {

        public int ID { get; set; }

        public string NombreyApellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Referencias { get; set; }
        public int Escala { get; set; }
        public bool Rifa { get; set; }
        public string Direccion { get; set; }
        public int RecomendationLevel { get; set; }
        public UserClientRole TipoUsuario { get; set; }
        public string BornDate { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public bool VerificState { get; set; }

        public string DetallesDeRifa { get; set; }
        public string RequisitoGanado { get; set; }
        public string PublicDate { get; set; }

        public int NoTransaccion { get; set; }
        public int Monto { get; set; }
        public string ServicioQuePaga { get; set; }
        public string Date { get; set; }

        public MembershipVO Membresia { get; set; }

        public ContactDataModel ClientContact { get; set; }
    }
}
