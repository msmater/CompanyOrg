using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyOrg.DAL;
using CompanyOrg.Models;

namespace CompanyOrg.DAL
{
    public class Db_input_initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CompanyContext>
    {
        //extern enum Grade;
        protected override void Seed(CompanyContext context)
        {
            ////USERS!!!
            var user = new List<Uzytkownik>
            {
                new Uzytkownik{ 
                    AwiZ=false, 
                    delegacja_akceptacji=0,
                    drugie_imie=null,
                    email="j.kowalski@firma.pl",
                    imie="Jan",
                    nazwisko="Kowalski",
                    jednostka_organizacyjnaID_JO=0,
                    login_AD="jan.kowalski",
                    lokalizacjaId=0,
                    MPK="MPK_001_01",
                    NRE="NRE_001_01",
                    stanowisko=1,
                    status=true,
                    tel_kom="11111",
                    tel_stac="22222",
                    typ_dostepu=1,
                    typ_kontaktu=1
                },
                new Uzytkownik{ 
                    AwiZ=false, 
                    delegacja_akceptacji=0,
                    drugie_imie=null,
                    email="t.pomocny@firma.pl",
                    imie="Tomasz",
                    nazwisko="Pomocny",
                    jednostka_organizacyjnaID_JO=0,
                    login_AD="tomasz.pomocny",
                    lokalizacjaId=0,
                    MPK="MPK_001_01",
                    NRE="NRE_001_01",
                    stanowisko=1,
                    status=true,
                    tel_kom="11111",
                    tel_stac="22222",
                    typ_dostepu=1,
                    typ_kontaktu=1
                    //,Komputery = new Models.Komputer(),
                    //jednostka_organizacyjna = new JednostkaOrganizacyjna,
                    //Lokalizacja = new Lokalizacja(),
                    
                }
            };

            user.ForEach(s => context.Uzytkownicy.Add(s));
            context.SaveChanges();

            ////@END USERS!!!


            ///COMPUTERS!!!
            List<Komputer> comps = new List<Komputer>
            {
                new Komputer{
                    adres_ip="10.10.10.1",
                    cd_dvd=true,
                    host_name="komp1",
                    ilosc_proc=2,
                    ilosc_ram=2,
                    karta_sieciowa=true,
                    //Lokaliacja = new Lokalizacja
                    lokalizacjaId = 0,
                    model_komputera=1,
                    model_procesora=1,
                    MPK="MPK_001_01",
                    nazwa="komp1_1",
                    nazwa_dns="komp1_1",
                    nazwa_monitora="dell monitor",
                    nr_id_system_zew="komp1",
                    nr_inwentarzowy="S22001111",
                    numer_ot="ot_21",
                    numer_seryjny="S222111",
                    rozmiar_hdd="500",
                    rozmiar_monitora="21\"",
                    szczegoly_lokalizacji="pokók 21",
                    typ_komputera=1,
                    //Uzytkownik=new Uzytkownik()
                    wartosc_netto="400",
                    wartosc_poczatkowa="300",
                    wlascicielId=1,
                    zegar_cpu="2"
                },
                new Komputer{
                    adres_ip="10.10.10.2",
                    cd_dvd=true,
                    host_name="komp2",
                    ilosc_proc=2,
                    ilosc_ram=2,
                    karta_sieciowa=true,
                    //Lokaliacja = new Lokalizacja
                    lokalizacjaId = 0,
                    model_komputera=1,
                    model_procesora=1,
                    MPK="MPK_002_02",
                    nazwa="komp2_2",
                    nazwa_dns="komp2_2",
                    nazwa_monitora="Dell monitor",
                    nr_id_system_zew="komp2",
                    nr_inwentarzowy="S220099",
                    numer_ot="ot_2",
                    numer_seryjny="9999",
                    rozmiar_hdd="500",
                    rozmiar_monitora="21\"",
                    szczegoly_lokalizacji="pokój 11 1 piętro",
                    typ_komputera=1,
                    //Uzytkownik=new Uzytkownik()
                    wartosc_netto="400",
                    wartosc_poczatkowa="300",
                    wlascicielId=1,
                    zegar_cpu="2"
                }
            };

            comps.ForEach(s => context.Komputery.Add(s));
            context.SaveChanges();

            ///@EDN komputery


            //lokalizacje!!!
            List<Lokalizacja> lok = new List<Lokalizacja>
            {
                new Lokalizacja{
                kod_pocztowy="21-322",
                //Komputery = new Komputer();
                miasto="Wrocław",
                pokoj="12",
                ulica="Inna"
                //Uzytkownicy=
                },
                new Lokalizacja{
                kod_pocztowy="21-022",
                //Komputery = new Komputer();
                miasto="Poznań",
                pokoj="pokoj 12 1 piętro",
                ulica="Mokra 21"
                //Uzytkownicy=
                },
                new Lokalizacja{
                kod_pocztowy="21-022",
                //Komputery = new Komputer();
                miasto="Poznań",
                pokoj="pokoj 21",
                ulica="Mokra 21"
                //Uzytkownicy=
                }
            };

            lok.ForEach(a => context.Lokalizacje.Add(a));
            context.SaveChanges();
            // @END lokalizacje !!!


            //jednostki org
            List<JednostkaOrg> j = new List<JednostkaOrg>
            {
                new JednostkaOrg
                {
                    id_manager= 1,
                    id_nadrzedna = 0,
                    kod="DZ",
                    MPK="200_001_01",
                    nazwa="Departament Zarządzania",
                    status=true
                    //Uzytkownicy
                },
                new JednostkaOrg
                {
                    id_manager= 2,
                    id_nadrzedna = 1,
                    kod="DZ",
                    MPK="200_002_01",
                    nazwa="Departament Sprzedaży i Marketingu",
                    status=true
                    //Uzytkownicy
                },
                new JednostkaOrg
                {
                    id_manager= 3,
                    id_nadrzedna = 1,
                    kod="DZ",
                    MPK="200_003_01",
                    nazwa="Departament Administracji",
                    status=true
                    //Uzytkownicy
                },
                new JednostkaOrg
                {
                    id_manager= 4,
                    id_nadrzedna = 1,
                    kod="DZ",
                    MPK="200_004_01",
                    nazwa="Departament IT i Sieci",
                    status=true
                    //Uzytkownicy
                },
                new JednostkaOrg
                {
                    id_manager= 5,
                    id_nadrzedna = 4,
                    kod="DZ",
                    MPK="200_004_02",
                    nazwa="Dział Utrzymania Środowiska Informatycznego",
                    status=true
                    //Uzytkownicy
                }
            };

            j.ForEach(a => context.JednostkiOrg.Add(a));
            context.SaveChanges();
        }
    }
}