using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.VMs.Auth;

namespace Проект.BLL.Interfaces
{
    interface IAuthService
    {
        bool CreateAuth(CreateUpdateAuthVM newAuth); //Создание
        OpenAuthVM GetAuth(Guid AuthId); // Получаем по ID 
        List<OpenAuthVM> GetAllAuthes(); // Получаем весь список
        bool UpdateAuth(Guid AuthId, OpenAuthVM editedAuth); //Обновляем данные выбранного
        bool DeleteAuth(Guid AuthId);   //Удаляем

        Guid GetFindId(string login);   //Ищем ID через логин
        bool FindLogin(string login);   //Провеяем занят ли логин

        OpenAuthVM Authorization(string login, string passwordHash);           //Авторизация
    }
}
