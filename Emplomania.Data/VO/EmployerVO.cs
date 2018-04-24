using System;
using System.Collections.Generic;

namespace Emplomania.Data.VO
{
    public class EmployerVO
    {
        public Guid Id { get; set; }
        public string NoLicencia { get; set; }
        public Guid UserFK { get; set; }
        //public UserVO User { get; set; }
    }
}