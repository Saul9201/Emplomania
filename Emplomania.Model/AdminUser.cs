﻿using Emplomania.Infrastucture.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Model
{
    public class AdminUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserAdminRole Role { get; set; }
        public string PasswordHash { get; set; }
    }
}
