using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.InteropServices;
using System.Diagnostics;
using Проект.DAL;
using Проект.PureF;
using Проект.BLL.Services;
using Проект.BLL.VMs.Product;

namespace Проект
{
    class Program 
    {
       

        static void Main(string[] args)
        {
            using (AppDbContext db = new AppDbContext())
            {
                ConsoleHelper.db = db;
            }
            ConsoleHelper.Page_0_Start();
        }
    }
}
