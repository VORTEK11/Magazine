using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.VMs.OrderItems;

namespace Проект.BLL.Interfaces
{
    interface IOrderItemsService
    {
        bool CreateOrderItems(CreateOrderItemsVM newOrderItems); //Создание
        OpenOrderItemsVM GetOrderItems(Guid OrderItemsId); //Чтение одого
        List<OpenOrderItemsVM> GetAllOrderItems(); //Чтение всех
        
        bool UpdateOrderItem(Guid OrderItemId); //Изменение
        
        bool DeleteOrderItems(Guid OrderId);       //Удалеине
                                                   //List<Order> GetAllOrdersByClientId(Guid id); //Получам список заказов




    }
}
