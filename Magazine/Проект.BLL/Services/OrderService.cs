using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.Interfaces;
using Проект.BLL.VMs.Order;
using Проект.DAL;
using Проект.Models;

namespace Проект.BLL.Services
{
    public class OrderService : IOrderService
    {
        readonly AppDbContext db;
        public OrderService()
        {
            db = new AppDbContext();
        }
        public OrderService(AppDbContext _db)
        {
            db = _db;
        }




        //Создание
        public bool CreateOrder(CreateOrderVM newOrder)
        {
            try
            {
                db.Orders.Add(new Order() { clienId = newOrder.clienId, orederTime = newOrder.orederTime, statusOrder = "В ожидание"});
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteOrder(Guid OrderId)
        {
            throw new NotImplementedException();
        }


        public List<OpenOrderVM> GetAllOrders()
        {
            List<OpenOrderVM> result = new List<OpenOrderVM>();

            var dbOrders = db.Orders.ToList();

            foreach (var dbOrder in dbOrders)
            {
                result.Add(new OpenOrderVM() { clienId = dbOrder.clienId, id = dbOrder.id, orederTime = dbOrder.orederTime, statusOrder = dbOrder.statusOrder});


            }
            return result;
        }

        public List<Order> GetAllOrdersByClientId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid GetFindId(DateTime data)
        {
            var dbOrders = db.Orders.ToList();

            foreach (var dbOrder in dbOrders)
            {
                if (dbOrder.orederTime == data)
                {
                    return dbOrder.id;
                }
            }
            return new Guid("0");
        }

        public OpenOrderVM GetOrder(Guid OrderId)
        {
            OpenOrderVM result = new OpenOrderVM();

            var dbOrders = db.Orders.ToList();

            foreach (var dbProduct in dbOrders)
            {
                if (dbProduct.id == OrderId)
                {
                    result.id = dbProduct.id;
                    result.orederTime = dbProduct.orederTime;
                    result.clienId = dbProduct.clienId;
                    
                }
            }
            return result;
        }
    }
}
