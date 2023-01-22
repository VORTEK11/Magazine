using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.VMs.OrderItems;

namespace Проект.BLL.VMs.Order
{
    public class OpenOrderVM
    {
        public Guid id { get; set; }
        public DateTime orederTime { get; set; }
        public Guid clienId { get; set; }
        public string statusOrder { get; set; }

        public virtual List<CreateOrderItemsVM> orderItems { get; set; }
    }
}
