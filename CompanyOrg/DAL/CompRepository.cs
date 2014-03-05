using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using CompanyOrg.Models;

namespace CompanyOrg.DAL
{
    public class CompRepository: ICompRepository, IDisposable
    {
        private CompanyContext context;

        public CompRepository(CompanyContext ctx)
        {
            this.context = ctx;
        }

        /**
         Obiektu typu 'CompanyOrg.DAL.UsersContext' 
         * nie można przekonwertować na typ 
         * 'System.Data.Entity.IDatabaseInitializer`1[CompanyOrg.DAL.UsersContext]'.
         */
        public System.Collections.Generic.IEnumerable<Komputer> GetComps()
        {
            return context.Komputery;//.ToList();
        }

        public Komputer GetCompByID(int ID)
        {
            return context.Komputery.Find(ID);
        }

        public void InsertComp(Komputer lok)
        {
            context.Komputery.Add(lok);
        }

        public void DeleteComp(int ID)
        {
            Komputer comp = context.Komputery.Find(ID);
            context.Komputery.Remove(comp);
        }

        public void DeleteComp(Komputer comp)
        {
            context.Komputery.Remove(comp);
        }

        public void UpdateComp(Komputer comp)
        {
            context.Entry(comp).State = EntityState.Modified;
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