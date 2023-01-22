using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Проект.Models
{
    public class Product: BaseEntity
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int number { get; set; }
        public string category { get; set; }
        public string description { get; set; }
    }
}
