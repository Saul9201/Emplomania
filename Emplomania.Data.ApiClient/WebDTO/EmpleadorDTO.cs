using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.ApiClient.WebDTO
{
    public class EmpleadorDTO : UserDTO
    {
        public string NoLicencia { get; set; }

        public NegocioDTO FirstNegocio { get; set; }

    }
}
