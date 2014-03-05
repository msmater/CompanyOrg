using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

using CompanyOrg.Models;

namespace CompanyOrg.DAL
{
    public class UsersRepository : IUsersRepository, IDisposable
    {
        private CompanyContext context;

        public UsersRepository(CompanyContext ctx)
        {
            this.context = ctx;
        }

        public System.Collections.Generic.IEnumerable<Uzytkownik> GetUsers()
        {
            return context.Uzytkownicy;//.ToList();
        }

        public Uzytkownik GetUserByID(int UserID)
        {
            return context.Uzytkownicy.Find(UserID);
        }

        public void InsertUser(Uzytkownik user)
        {
            context.Uzytkownicy.Add(user);
        }

        public void DeleteUser(int UserID)
        {
            Uzytkownik user = context.Uzytkownicy.Find(UserID);
            context.Uzytkownicy.Remove(user);
        }

        public void DeleteUser(Uzytkownik user)
        {
            context.Uzytkownicy.Remove(user);
        }

        public void UpdateUser(Uzytkownik user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}