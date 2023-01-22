using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект.BLL.VMs.OrderItems
{
    public class CreateOrderItemsVM
    {
        public int count { get; set; }
        public Guid productId { get; set; }

        public string status { get; set; }

        public Guid ordertId { get; set; }
    }
}
