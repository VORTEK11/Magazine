using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.Interfaces;
using Проект.BLL.VMs.Manager;
using Проект.DAL;
using Проект.Models;

namespace Проект.BLL.Services
{
    public class ManagerService : IManagerService
    {

        readonly AppDbContext db;


        public ManagerService()
        {
            db = new AppDbContext();
        }
        public ManagerService(AppDbContext _db)
        {
            db = _db;
        }



        //Авторизация
        public OpenManagerVM Authorization(Guid authId)
        {
            OpenManagerVM result = new OpenManagerVM();

            var dbManagers = db.Managers.ToList();

            foreach (var dbManager in dbManagers)
            {
                if (dbManager.authId == authId)
                {
                    result.fio = dbManager.fio;
                    result.authId = dbManager.authId;
                    result.id = dbManager.id;

                    return result;
                }
            }
            return result;
        }




        //Создание нового
        public bool CreateManager(CreateUpdateManagerVM newManager)
        {
            try
            {
                db.Managers.Add(new Manager() { fio = newManager.fio, age = newManager.age, authId = newManager.authId, phoneNumber = newManager.phoneNumber, startWork = newManager.startWork });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteManager(Guid ManagerId)
        {
            throw new NotImplementedException();
        }

        public List<OpenManagerListVM> GetAllManagers()
        {

            List<OpenManagerListVM> result = new List<OpenManagerListVM>();

            var dbClients = db.Clients.ToList();

            foreach (var dbClient in dbClients)
            {
                result.Add(new OpenManagerListVM() { fio = dbClient.fio, id = dbClient.id, phoneNumber = dbClient.phoneNumber });
            }
            return result;
        }

        public OpenManagerVM GetManager(Guid ManagerId)
        {
            OpenManagerVM result = new OpenManagerVM();

            var dbManagers = db.Managers.ToList();

            foreach (var dbManager in dbManagers)
            {
                if (dbManager.id == ManagerId)
                {
                    result.startWork = dbManager.startWork;
                    result.age = dbManager.age;
                    result.authId = dbManager.authId;
                    result.id = dbManager.id;
                    result.phoneNumber = dbManager.phoneNumber;
                    result.fio = dbManager.fio;


                }
            }
            return result;
        }

        public bool UpdateManager(Guid ManagerId, OpenManagerVM editedManager)
        {
            try
            {
                var dbManagers = db.Managers.ToList();

                foreach (var manager in dbManagers)
                {
                    if (manager.id == ManagerId)
                    {

                        manager.age = editedManager.age;
                        manager.fio = editedManager.fio;
                        manager.phoneNumber = editedManager.phoneNumber;
                    }
                }



                foreach (var manager in dbManagers)
                {
                    db.Entry(manager).State = EntityState.Modified;
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
