using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.Interfaces;
using Проект.BLL.VMs.Client;
using Проект.DAL;
using Проект.Models;

namespace Проект.BLL.Services
{
    public class ClientService : IClientService
    {
        readonly AppDbContext db;


        public ClientService()
        {
            db = new AppDbContext();
        }
        public ClientService(AppDbContext _db)
        {
            db = _db;
        }

        
        
        //Авторизация
        public OpenClientVM Authorization(Guid authId)
        {
            OpenClientVM result = new OpenClientVM();

            var dbClients = db.Clients.ToList();

            foreach (var dbClient in dbClients)
            {
                if (dbClient.authId == authId)
                {
                    var a = dbClient.Orders;
                    result.fio = dbClient.fio;
                    result.authId = dbClient.authId;
                    result.id = dbClient.id;

                    return result;
                }
            }
            return result;
        }




        public bool CreateClient(CreateUpdateClientVM newClient)
        {
            try
            {
                db.Clients.Add(new Client() { fio = newClient.fio, adres = newClient.adres, age = newClient.age, authId = newClient.authId, phoneNumber = newClient.phoneNumber });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteClient(Guid ClientId)
        {
            throw new NotImplementedException();
        }

        public List<OpenClientListVM> GetAllClients()
        {
            List<OpenClientListVM> result = new List<OpenClientListVM>();

            var dbClients = db.Clients.ToList();

            foreach (var dbClient in dbClients)
            {
                result.Add(new OpenClientListVM() { fio = dbClient.fio, id = dbClient.id, adres = dbClient.adres, phoneNumber = dbClient.phoneNumber, age = dbClient.age});
            }
            return result;
        }

        public OpenClientVM GetClient(Guid ClientId)
        {
            OpenClientVM result = new OpenClientVM();

            var dbClients = db.Clients.ToList();

            foreach (var dbClient in dbClients)
            {
                if (dbClient.id == ClientId)
                {
                    result.adres = dbClient.adres;
                    result.age = dbClient.age;
                    result.authId = dbClient.authId;
                    result.id = dbClient.id;
                    result.phoneNumber = dbClient.phoneNumber;
                    result.fio = dbClient.fio;


                }
            }
            return result;
        }

        public bool UpdateClient(Guid ClientId, OpenClientVM editedClient)
        {
            try
            {
                var dbClients = db.Clients.ToList();

                foreach (var client in dbClients)
                {
                   if (client.id == ClientId)
                    {
                        client.adres = editedClient.adres;
                        client.age = editedClient.age;
                        client.fio = editedClient.fio;
                        client.phoneNumber = editedClient.phoneNumber; 
                    }    
                }



                foreach (var client in dbClients)
                {
                    db.Entry(client).State = EntityState.Modified;
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
