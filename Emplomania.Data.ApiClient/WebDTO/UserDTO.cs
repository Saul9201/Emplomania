using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.ApiClient.WebDTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        #region Scalar Properties
        public string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        //public virtual string SecurityStamp { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string Email { get; set; }
        public bool PerfilCreado { get; set; }
        #endregion

        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string DireccionParticular { get; set; }
        public string TelefonoFijo { get; set; }
        //public int Tiques { get; set; }
        public bool Verificado { get; set; }
        public bool Activo { get; set; }
        public double Saldo { get; set; }
        public byte[] ProfileImage { get; set; }
        public Guid MunicipioId { get; set; }
    }

}
