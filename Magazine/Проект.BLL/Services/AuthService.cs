using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.Interfaces;
using Проект.BLL.VMs.Auth;
using Проект.DAL;
using Проект.Models;

namespace Проект.BLL.Services
{
    public class AuthService : IAuthService
    {
        readonly AppDbContext db;


        public AuthService()
        {
            db = new AppDbContext();
        }
        public AuthService(AppDbContext _db)
        {
            db = _db;
        }





        public bool CreateAuth(CreateUpdateAuthVM newAuth)
        {
            try
            {
                db.Authes.Add(new Auth() { login = newAuth.login, passwordHash = newAuth.passwordHash, role = newAuth.role });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAuth(Guid AuthId)
        {
            throw new NotImplementedException();
        }

        public List<OpenAuthVM> GetAllAuthes()
        {
            List<OpenAuthVM> result = new List<OpenAuthVM>();

            var dbAuthes = db.Authes.ToList();

            foreach (var dbAuth in dbAuthes)
            {
                result.Add(new OpenAuthVM() { login = dbAuth.login, passwordHash = dbAuth.passwordHash, role = dbAuth.role, id = dbAuth.id });
            }
            return result;
        }

        public OpenAuthVM GetAuth(Guid AuthId)
        {
            OpenAuthVM result = new OpenAuthVM();

            var dbauths = db.Authes.ToList();

            foreach (var dbAuth in dbauths)
            {
                if (dbAuth.id == AuthId)
                {
                    result.id = dbAuth.id;
                    result.login = dbAuth.login;
                    result.passwordHash = dbAuth.passwordHash;
                

                }
            }
            return result;
        }

        //Поиск ID по Login
        public Guid GetFindId(string login)
        { 

            var dbAuthes = db.Authes.ToList();

            foreach (var dbAuth in dbAuthes)
            {
                if (dbAuth.login == login)
                {
                    return dbAuth.id;
                }
            }
            return new Guid("0");
        }

        
        //Проверяем уникальность логина
        public bool FindLogin(string login)
        {
            var dbAuthes = db.Authes.ToList();

            foreach (var dbAuth in dbAuthes)
            {
                if (dbAuth.login == login)
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateAuth(Guid AuthId, OpenAuthVM editedAuth)
        {
            try
            {
                var dbAuths = db.Authes.ToList();

                foreach (var Auth in dbAuths)
                {
                    if (Auth.id == AuthId)
                    {
                        Auth.login = editedAuth.login;
                        Auth.passwordHash = editedAuth.passwordHash;

                    }
                }



                foreach (var Auth in dbAuths)
                {
                    db.Entry(Auth).State = EntityState.Modified;
                }

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //Авторизация 
        public OpenAuthVM Authorization(string login, string passwordHash)
        {
            OpenAuthVM result = new OpenAuthVM();
            var dbAuthes = db.Authes.ToList();

            foreach (var dbAuth in dbAuthes)
            {
                if (dbAuth.login == login)
                {

                    if (dbAuth.passwordHash == passwordHash)
                    {
                        result.login = dbAuth.login;
                        result.passwordHash = dbAuth.passwordHash;
                        result.role = dbAuth.role;
                        result.id = dbAuth.id ;

                        return result;
                    }
                }
            }
            return result;
        }

      
    }
}
