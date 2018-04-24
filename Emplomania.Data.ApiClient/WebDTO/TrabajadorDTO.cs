using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.ApiClient.WebDTO
{
    public class TrabajadorDTO : UserDTO
    {
        public DateTime FechaNacimiento { get; set; }
        public double Estatura { get; set; }
        public bool Hijos { get; set; }
        public string Barriada { get; set; }
        public string Habilidades { get; internal set; }
        public string Salario { get; set; }
        public string Experiencia { get; internal set; }

        public TrabajadorDataDTO TrabajadorAttributes { get; set; }
    }
}
