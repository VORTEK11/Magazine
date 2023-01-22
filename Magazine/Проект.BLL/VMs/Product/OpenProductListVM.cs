using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект.BLL.VMs.Product
{
    public class OpenProductListVM
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string category { get; set; }
        public int number { get; set; }

    }
}
