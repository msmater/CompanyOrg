using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CompanyOrg.Models;

namespace CompanyOrg.DAL
{
    public interface IJednostkaOrgRepository
    {
        System.Collections.Generic.IEnumerable<JednostkaOrg> GetJednostkiOrg();
        JednostkaOrg GetJednostkaOrgByID(int ID);
        void InsertJednostkaOrg(JednostkaOrg comp);
        void DeleteJednostkaOrg(JednostkaOrg comp);
        void UpdateJednostkaOrg(JednostkaOrg comp);
        void Save();
    }
}