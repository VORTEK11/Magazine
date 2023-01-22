using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект.BLL.VMs.Manager
{
    public class OpenManagerListVM
    {
        public Guid id { get; set; }
        public string fio { get; set; }
        public string phoneNumber { get; set; }

        public DateTime startWork { get; set; }
    }
}
