using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Infrastucture.Enums
{
    public enum UserAdminRole
    {
        Administrador,
        [Description("Atención a clientes")]
        Atención_a_clientes,
        Comercial
    }
}
