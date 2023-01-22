﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.Models;

namespace Проект.BLL.VMs.Client
{
    public class OpenClientVM
    {
        public Guid id { get; set; }
        public string fio { get; set; }
        public string phoneNumber { get; set; }
        public int age { get; set; }
        public Guid authId { get; set; }
        public virtual Guid auth { get; set; }


        public string adres { get; set; }
        //public virtual List<Order> Orders { get; set; }
    }
}
