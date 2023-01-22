using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Проект.Models
{
    public abstract class Person : BaseEntity
    {
        public string fio { get; set; }
        public string phoneNumber { get; set; }
        public int age { get; set; }
        public Guid authId { get; set; }
        public virtual Guid auth { get; set; }

    }
}
