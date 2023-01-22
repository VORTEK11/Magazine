using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект.Models
{
    public class BaseEntity
    {
        public Guid id { get; set; } = Guid.NewGuid();
    }
}
