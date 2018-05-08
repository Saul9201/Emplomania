using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Infrastucture.Enums
{
    public enum IncomeType
    {
        [Description("Oficina Comercial")]
        CommercialOffice,
        [Description("Depósito Bancario")]
        BankDeposit,
        [Description("Venta de Cupón")]
        CouponSale,
    }
}
