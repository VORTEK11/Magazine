using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.Interfaces;
using Проект.BLL.VMs.OrderItems;
using Проект.DAL;
using Проект.Models;

namespace Проект.BLL.Services
{
    public class OrderItemsService : IOrderItemsService
    {

        readonly AppDbContext db;
        public OrderItemsService()
        {
            db = new AppDbContext();
        }
        public OrderItemsService(AppDbContext _db)
        {
            db = _db;
        }

        public bool CreateOrderItems(CreateOrderItemsVM newOrderItems)
        {
            try
            {
                db.OrderItems.Add(new OrderItem() { count = newOrderItems.count, productId = newOrderItems.productId, orderId = newOrderItems.ordertId, status = "В ожидание"});
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrderItems(Guid OrderId)
        {
            throw new NotImplementedException();
        }

        public List<OpenOrderItemsVM> GetAllOrderItems()
        {
            List<OpenOrderItemsVM> result = new List<OpenOrderItemsVM>();

            var OrderItems = db.OrderItems.ToList();

            foreach (var dbOrderItem in OrderItems)
            {
                result.Add(new OpenOrderItemsVM() { id = dbOrderItem.id, count = dbOrderItem.count, productId = dbOrderItem.productId, ordertId = dbOrderItem.orderId, status = dbOrderItem.status});
            }
            return result;
        }

     

        public OpenOrderItemsVM GetOrderItems(Guid OrderItemsId)
        {
            OpenOrderItemsVM result = new OpenOrderItemsVM();

            var dbOrderItems = db.OrderItems.ToList();

            foreach (var OrderItem in dbOrderItems)
            {
                if (OrderItem.id == OrderItemsId)
                {
                    result.count = OrderItem.count;
                    result.id = OrderItem.id;
                    result.productId= OrderItem.productId;
                    result.ordertId = OrderItem.orderId;
                    result.status = OrderItem.status;


                }
            }
            return result;
        }

        public bool UpdateOrderItem(Guid OrderItemId)
        {
            try
            {
                var dbOrderItems = db.OrderItems.ToList();

                foreach (var orderItem in dbOrderItems)
                {
                    if (orderItem.id == OrderItemId)
                    {
                        orderItem.status = "Доставлен";
                    }
                }



                foreach (var orderItem in dbOrderItems)
                {
                    db.Entry(orderItem).State = EntityState.Modified;
                }

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
