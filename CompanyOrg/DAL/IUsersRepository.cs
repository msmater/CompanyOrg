using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CompanyOrg.Models;

namespace CompanyOrg.DAL
{
    public interface IUsersRepository : IDisposable
    {
        System.Collections.Generic.IEnumerable<Uzytkownik> GetUsers();
        Uzytkownik GetUserByID(int UserID);
        void InsertUser(Uzytkownik user);
        void DeleteUser(Uzytkownik user);
        void UpdateUser(Uzytkownik user);
        void Save();
    }
}