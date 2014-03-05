using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CompanyOrg.Models;

namespace CompanyOrg.DAL
{
    public interface ILokalizacjeRepository : IDisposable
    {
        System.Collections.Generic.IEnumerable<Lokalizacja> GetLoks();
        Lokalizacja GetLokByID(int ID);
        void InsertLok(Lokalizacja lok);
        void DeleteLok(Lokalizacja lok);
        void UpdateLok(Lokalizacja lok);
        void Save();
    }
}