
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Проект.Models
{
    public class Auth: BaseEntity
    {
        public string login { get; set; }
        public string passwordHash { get; set; }
        public string role { get; set; }


        //Регистрация
       // public static void RegisterNew()
       // {
            //Vozvrat:
            //Console.WriteLine("\nРЕГИСТРАЦИЯ:");
            //Console.Write("Придумайте Login - ");
            //string login = Console.ReadLine();

            //Console.Write("Придумайте пароль - ");
            //string passwordHash = Console.ReadLine().GetHashCode().ToString();

            //Console.Write("Повторите пароль - ");
            //string passwordHash_Copy = Console.ReadLine().GetHashCode().ToString();


            //if (passwordHash == passwordHash_Copy)
            //{
            //    var newUser = new Auth() { login = login, passwordHash = passwordHash };
            //    DBImitation.Authes.Add(newUser);

            //    string json = JsonConvert.SerializeObject(DBImitation.Authes, Formatting.Indented);


            //    using (StreamWriter sw = new StreamWriter("JSON/Auth.json", false, System.Text.Encoding.Default))
            //    {
            //        sw.WriteLine(json);  
            //    }

            //    Vozvrat1:
            //    Console.WriteLine("\nВыберите тип пользователя:");
            //    Console.WriteLine("1 - создать Менеджера;");
            //    Console.WriteLine("2 - создать Клиента.");
            //    Console.Write("Действие - ");
                
                
            //    string n = Console.ReadLine();
            //    switch (n)
            //    {
            //        case "1":
            //            Manager.GetNewManage(newUser.Id);
            //            break;
                    

            //        case "2":
            //            Client.GetNewClient(newUser.Id);
            //            break;


            //        default:
            //            goto Vozvrat1;   
            //    }

            //    DBImitation.GetUpdate_Auth_FromJSON();
                


            //    Console.WriteLine("Пользователь успешно создан!");
            //}
            //else
            //{
            //    Console.WriteLine("Пароли не совпадают! Повтарите попытку регистрации!");
            //    goto Vozvrat;
            //}
       // }



        //Авторизация
       // public static void Authorization()
       // {

        //Vozrat:
        //    Console.WriteLine("\nАВТОРИЗАЦИЯ:");
        //    Console.Write("Введите Login - ");
        //    string login = Console.ReadLine();

        //    Console.Write("Введите пароль - ");
        //    string passwordHash = Console.ReadLine().GetHashCode().ToString();

        //    var user = DBImitation.Authes.Find(m => m.login == login && m.passwordHash == passwordHash);
          
            
        //    if (user != null)
        //    {
        //        var client = DBImitation.Clients.Find(m => m.authId == user.Id);

        //        if (client != null)
        //        {
        //            CurrentUser.Id = client.Id;
        //            CurrentUser.fio = client.fio;
        //            CurrentUser.acessLevel = "Сlient";
        //            Console.WriteLine("Авторизация прошла успешно! Доступ: Client");
        //        }
        //        else
        //        {
        //            var manager = DBImitation.Managers.Find(m => m.authId == user.Id);

        //            if (manager != null)
        //            {
        //                CurrentUser.Id = manager.Id;
        //                CurrentUser.fio = manager.fio;
        //                CurrentUser.acessLevel = "Manager";
        //                Console.WriteLine("Авторизация прошла успешно! Доступ: Client");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Пользователя не существует! Повторите вход!");
        //                goto Vozrat;
        //            }
        //        }
        //    }
        //    else
        //    {



        //        Console.WriteLine("Проверьте правильность введенных данных!");
        //        goto Vozrat;
        //    }
        //}
    }
}
