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
    [Table("Komputer")]
    public class Komputer
    {
        //[ScaffoldColumn(true)]
        [Key]
        public int Id { get; set; }
        [DisplayName("Nazwa DNS")]
        public string nazwa_dns { get; set; }
        [DisplayName("Nazwa")]
        public string nazwa { get; set; }
        [DisplayName("Numer seryjny")]
        public string numer_seryjny { get; set; }
        [DisplayName("Host Name")]
        public string host_name { get; set; }
        [DisplayName("MPK")]
        public string MPK { get; set; }
        [DisplayName("Szczegóły lokalizacji")]
        public string szczegoly_lokalizacji { get; set; }
        [DisplayName("Nr Inwentarzowy")]
        public string nr_inwentarzowy { get; set; }
        [DisplayName("Wartość Początkowa")]
        public string wartosc_poczatkowa { get; set; }
        [DisplayName("Wartość Netto")]
        public string wartosc_netto { get; set; }
        [DisplayName("Numer OT")]
        public string numer_ot { get; set; }
        [DisplayName("Numer id systemu zewnętrznego")]
        public string nr_id_system_zew { get; set; }
        [DisplayName("CD/DVD")]
        public bool cd_dvd { get; set; }
        [DisplayName("Karta sieciowa")]
        public bool karta_sieciowa { get; set; }
        [DisplayName("Adres IPv4")]
        public string adres_ip { get; set; }
        [DisplayName("Zegar CPU (GHz)")]
        public string zegar_cpu { get; set; }
        [DisplayName("Ilość procesorów")]
        public int ilosc_proc { get; set; }
        [DisplayName("Ilość RAM (GB)")]
        public int ilosc_ram { get; set; }
        [DisplayName("Rozmiar HDD (GB)")]
        public string rozmiar_hdd { get; set; }
        [DisplayName("Nazwa monitora")]
        public string nazwa_monitora { get; set; }
        [DisplayName("Rozmiar monitora (cale)")]
        public string rozmiar_monitora { get; set; }
        [DisplayName("Model procesora")]
        public int model_procesora { get; set; }
        [DisplayName("Model komputera")]
        public int model_komputera { get; set; }


        [DisplayName("Typ komputera")]
        public int typ_komputera { get; set; }

        [DisplayName("ID Właściciela")]
        public int wlascicielId { get; set; }
        [ForeignKey("wlascicielId")]
        public virtual Uzytkownik Uzytkownik { get; set; }//jeden user

        [DisplayName("ID Lokalizacji")]
        public int lokalizacjaId { get; set; }
        [ForeignKey("lokalizacjaId")]
        public virtual Lokalizacja Lokaliacja { get; set; }//jedna lokalizacja
    }
}