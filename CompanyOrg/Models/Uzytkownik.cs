using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyOrg.Models;
using CompanyOrg.DAL;

namespace CompanyOrg.Models
{

    [Table("Uzytkownik")]
    public class Uzytkownik
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //[ScaffoldColumn(true)]
        [Key]
        public int Id { get; set; }
        [DisplayName("Imię")]
        public string imie { get; set; }
        [DisplayName("Nazwisko")]
        public string nazwisko { get; set; }
        [DisplayName("Drugie imię")]
        public string drugie_imie { get; set; }
        [DisplayName("Status")]
        public bool status { get; set; }
        [DisplayName("Login")]
        public string login_AD { get; set; }
        [DisplayName("Akceptujący Wnioski i Zmiany")]
        public bool AwiZ { get; set; }
        [DisplayName("Telefon komórkowy")]
        public string tel_kom { get; set; }
        [DisplayName("Telefon stacjonarny")]
        public string tel_stac { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("MPK")]
        public string MPK { get; set; }
        
        [DisplayName("Typ kontaktu")]
        public Int16 typ_kontaktu { get; set; }
        [DisplayName("Typ dostępu")]
        public int typ_dostepu { get; set; }
        [DisplayName("Stanowisko")]
        public int stanowisko { get; set; }
        [DisplayName("Oddelegowanie akceptacji")]
        public int delegacja_akceptacji { get; set; }
        public string NRE { get; set; }

        [DisplayName("Id lokalizacji")]
        public int lokalizacjaId { get; set; }
        [ForeignKey("lokalizacjaId")]
        public virtual Lokalizacja Lokalizacja { get; set; }//jedna lokalizacja per user

        [DisplayName("Jednostka organizacyjna")]
        public int jednostka_organizacyjnaID_JO { get; set; } //id
        [ForeignKey("jednostka_organizacyjnaID_JO")]
        public virtual JednostkaOrg jednostka_organizacyjna { get; set; }//jedna jednostka per user

        public virtual ICollection<Komputer> Komputery { get; set; }//wiele komputerow per user

    }
}