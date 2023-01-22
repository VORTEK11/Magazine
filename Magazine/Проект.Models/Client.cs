
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект.Models
{
    public class Client: Person
    {
        public string adres { get; set; }
        public virtual List<Order> Orders { get; set; }


        //Создание
       // public static void GetNewClient(Guid authId)
        //{
            //Console.WriteLine("\nЗАПОЛНИТЕ ОБЩУЮ ИНФОРМАЦИЮ:\n");

            





            //var newUser = new Client() { fio = fio, age = age, phoneNumber = phoneNumber, adres = adres, authId = authId};
            //DBImitation.Clients.Add(newUser);

            //string json = JsonConvert.SerializeObject(DBImitation.Clients, Formatting.Indented);


            //using (StreamWriter sw = new StreamWriter("JSON/Client.json", false, System.Text.Encoding.Default))
            //{
            //    sw.WriteLine(json);
            //}

            //DBImitation.GetUpdate_Client_FromJSON();
       // }




        


    } 
}
