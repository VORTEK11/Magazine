using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.VMs.Order;

namespace Проект.BLL.VMs.Client
{
    public class OpenClientListVM
    {
        public Guid id { get; set; }
        public string fio { get; set; }

        public string phoneNumber { get; set; }

        public int age { get; set; }

        public string adres { get; set; }
        
    }
}
