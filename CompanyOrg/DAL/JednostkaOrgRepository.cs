using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CompanyOrg.Models;
using CompanyOrg.DAL;

namespace CompanyOrg.DAL
{
    public class JednostkaOrgRepository : IJednostkaOrgRepository, IDisposable
    {
        private CompanyContext context;

        public JednostkaOrgRepository(CompanyContext ctx)
        {
            this.context = ctx;
        }

        public JednostkaOrgRepository()
        {
            context = new CompanyContext();
        }

        /**
         Obiektu typu 'CompanyOrg.DAL.UsersContext' 
         * nie można przekonwertować na typ 
         * 'System.Data.Entity.IDatabaseInitializer`1[CompanyOrg.DAL.UsersContext]'.
         */
        public System.Collections.Generic.IEnumerable<JednostkaOrg> GetJednostkiOrg()
        {
            return context.JednostkiOrg.AsEnumerable();//.ToList();
        }

        public CompanyOrg.Models.JednostkaOrg GetJednostkaOrgByID(int ID)
        {
            return context.JednostkiOrg.Find(ID);
        }

        public void InsertJednostkaOrg(CompanyOrg.Models.JednostkaOrg a)
        {
            context.JednostkiOrg.Add(a);
        }

        public void DeleteJednostkaOrg(int ID)
        {
            CompanyOrg.Models.JednostkaOrg a = context.JednostkiOrg.Find(ID);
            context.JednostkiOrg.Remove(a);
        }

        public void DeleteJednostkaOrg(CompanyOrg.Models.JednostkaOrg a)
        {
            context.JednostkiOrg.Remove(a);
        }

        public void UpdateJednostkaOrg(CompanyOrg.Models.JednostkaOrg a)
        {
            context.Entry(a).State = System.Data.Entity.EntityState.Modified;
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