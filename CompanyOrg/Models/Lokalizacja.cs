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
    [Table("Lokalizacja")]
    public class Lokalizacja
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[ScaffoldColumn(true)]
        [Key]
        public int ID_lokalizacja { set; get; }
        [DisplayName("Ulica")]
        public string ulica { get; set; }
        [DisplayName("Miasto")]
        public string miasto { get; set; }
        [DisplayName("Kod Pocztowy")]
        public string kod_pocztowy { get; set; }
        [DisplayName("Pokój lub opis lokalizacji")]
        public string pokoj { get; set; }

        //wiele komputerow
        public virtual ICollection<Komputer> Komputery { get; set; }
        //wieele userow per lokalizacje 
        public virtual ICollection<Uzytkownik> Uzytkownicy { get; set; }
    }
}