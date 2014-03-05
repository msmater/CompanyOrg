using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CompanyOrg.Models;

namespace CompanyOrg.DAL
{
    public interface ICompRepository : IDisposable
    {
        System.Collections.Generic.IEnumerable<Komputer> GetComps();
        Komputer GetCompByID(int ID);
        void InsertComp(Komputer comp);
        void DeleteComp(Komputer comp);
        void UpdateComp(Komputer comp);
        void Save();
    }
}