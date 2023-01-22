using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.VMs.Manager;

namespace Проект.BLL.Interfaces
{
    interface IManagerService
    {
        bool CreateManager(CreateUpdateManagerVM newManager); //Создание
        OpenManagerVM GetManager(Guid ManagerId); // Получаем по ID 
        List<OpenManagerListVM> GetAllManagers(); // Получаем весь список
        bool UpdateManager(Guid ManagerId, OpenManagerVM editedManager); //Обновляем данные выбранного
        bool DeleteManager(Guid ManagerId); //Удаляем

        OpenManagerVM Authorization(Guid authId); //Аваторизация клиента
    }
}
