
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Проект.Models
{
    public class Manager: Person
    {
        public DateTime startWork { get; set; } = new DateTime();



        //public static void GetNewManage(Guid authId)
        //{
            //Console.WriteLine("\nЗАПОЛНИТЕ ОБЩУЮ ИНФОРМАЦИЮ:\n");

            //Console.Write("Введите ФИО - ");
            //string fio = Console.ReadLine();

            //Console.Write("Введите ваш возраст - ");
            //int age = Convert.ToInt16(Console.ReadLine());

            //Console.Write("Введите ваш номер телефона - ");
            //string phoneNumber = Console.ReadLine();
            
            //DateTime startWork = DateTime.Now;



            //var newUser = new Manager() { fio = fio, age = age, phoneNumber = phoneNumber, startWork = startWork, authId = authId };
            //DBImitation.Managers.Add(newUser);

            
            //string json = JsonConvert.SerializeObject(DBImitation.Managers, Formatting.Indented);


            //using (StreamWriter sw = new StreamWriter("JSON/Manager.json", false, System.Text.Encoding.Default))
            //{
            //    sw.WriteLine(json);
            //}

            //DBImitation.GetUpdate_Manager_FromJSON();
        //}
    }
}
