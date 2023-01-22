using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект.PureF
{
    static class CurrentUser
    {
        public static Guid Id { get; set; }
        public static string fio { get; set; }
        public static string role { get; set; }
        public static bool status { get; set; }
 
    }
}
