using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Проект.Models
{
    public class OrderItem: BaseEntity
    {
        public int count { get; set; }
        public string status { get; set; }
        public Guid productId { get; set; }
        public virtual Product product { get; set; }
        public Guid orderId { get; set; }
        public virtual Order order { get; set; }
    }
}
