using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект.BLL.VMs.Order
{
    public class CreateOrderVM
    {
        public DateTime orederTime { get; set; }
        public Guid clienId { get; set; }
    }
}
