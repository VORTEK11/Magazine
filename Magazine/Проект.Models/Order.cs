using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Проект.Models
{
    public class Order: BaseEntity
    {
        public DateTime orederTime { get; set; }
        public Guid clienId { get; set; }
        public string statusOrder { get; set; }
        public virtual Client clien { get; set; }
        public virtual List<OrderItem> orderItems { get; set; } 
    }
}
