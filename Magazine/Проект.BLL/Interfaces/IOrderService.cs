using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.VMs.Order;
using Проект.Models;

namespace Проект.BLL.Interfaces
{
    interface IOrderService
    {
        bool CreateOrder(CreateOrderVM newOrder); //Создание
        OpenOrderVM GetOrder(Guid OrderId); //Чтение одого
        List<OpenOrderVM> GetAllOrders(); //Чтение всех
        //bool UpdateOrder(Guid OrderId, CreateOrderVM editedProduct); //Изменение
        bool DeleteOrder(Guid OrderId);       //Удалеине
        List<Order> GetAllOrdersByClientId(Guid id); //Получам список заказов



        Guid GetFindId(DateTime data);   //Ищем ID через логин
    
    }
}
