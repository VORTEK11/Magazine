﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект.BLL.VMs.Auth
{
    public class CreateUpdateAuthVM
    {
        public string login { get; set; }
        public string passwordHash { get; set; }
        public string role { get; set; }
    }
}
