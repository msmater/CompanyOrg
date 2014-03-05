using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using CompanyOrg.Models;

namespace CompanyOrg.DAL
{
    public class LokalizacjeRepository : ILokalizacjeRepository, IDisposable
    {
        private CompanyContext context;

        public LokalizacjeRepository(CompanyContext context)
        {
            this.context = context;
        }

        public System.Collections.Generic.IEnumerable<Lokalizacja> GetLoks()
        {
            return context.Lokalizacje;
        }

        public Lokalizacja GetLokByID(int ID)
        {
            return context.Lokalizacje.Find(ID);
        }

        public void InsertLok(Lokalizacja lok)
        {
            context.Lokalizacje.Add(lok);
        }

        public void DeleteLok(int ID)
        {
            Lokalizacja lok = context.Lokalizacje.Find(ID);
            context.Lokalizacje.Remove(lok);
        }

        public void DeleteLok(Lokalizacja lok)
        {
            context.Lokalizacje.Remove(lok);
        }

        public void UpdateLok(Lokalizacja lok)
        {
            context.Entry(lok).State = EntityState.Modified;
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