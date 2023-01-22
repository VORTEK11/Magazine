using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.VMs.Client;

namespace Проект.BLL.Interfaces
{
    interface IClientService
    {
        bool CreateClient(CreateUpdateClientVM newClient); //Создание
        OpenClientVM GetClient(Guid ClientId); // Получаем по ID 
        List<OpenClientListVM> GetAllClients(); // Получаем весь список
        bool UpdateClient(Guid ClientId, OpenClientVM editedClient); //Обновляем данные выбранного
        bool DeleteClient(Guid ClientId); //Удаляем

        OpenClientVM Authorization(Guid authId); //Аваторизация клиента
    }
}
