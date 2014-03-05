using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyOrg.Models;
using CompanyOrg.DAL;

namespace CompanyOrg.Models
{
    [Table("Jednostka_Organizacyjna")]
    public class JednostkaOrg
    {
        //[ScaffoldColumn(true)]
        [Key]
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string nazwa { get; set; }
        [DisplayName("Kod")]
        public string kod { get; set; }
        [DisplayName("Status")]
        public bool status { get; set; }
        [DisplayName("ID Jednostki nadrzędnej")]
        public int id_nadrzedna { get; set; }
        //[ForeignKey("Uzytkownik")]
        [DisplayName("ID Managera")]
        public int id_manager { get; set; }
        [DisplayName("MPK")]
        public string MPK { get; set; }

        //jednostka organizacyjna - wielu userów
        public virtual ICollection<Uzytkownik> Uzytkownicy { get; set; }
    }
}