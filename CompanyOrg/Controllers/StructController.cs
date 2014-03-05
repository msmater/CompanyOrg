using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CompanyOrg.Models;
using CompanyOrg.DAL;

namespace CompanyOrg.Controllers
{
    public class StructController : Controller
    {
        //private DAL.ILokalizacjeRepository loksRepo;
        private DAL.IJednostkaOrgRepository jednostkiOrgRepo;
        private Models.CompanyContext context;

        public StructController()
        {
            context = new CompanyContext();
            jednostkiOrgRepo = new DAL.JednostkaOrgRepository(context);
        }

        public StructController(Models.CompanyContext cont)
        {
            context = cont;
            jednostkiOrgRepo = new DAL.JednostkaOrgRepository(context);
        }

        //
        // GET: /Uzytkownik/



        public ActionResult Index()
        {
            //var all = from row in jednostkiOrgRepo.GetJednostkiOrg() select row;
            //int t = 0;

            //jednostkiOrgRepo.GetJednostkiOrg().ToList().ForEach(a => a.Uzytkownicy.ToList)
            
            /*
            foreach (var jednostka in obj)
            {
                if ( jednostka.id_manager != 0 )
                {
                    Uzytkownik manager = (from row in context.Uzytkownicy where row.Id == jednostka.id_manager select row).FirstOrDefault();

                    int no_of_users = context.Uzytkownicy.Count();
                    int no_of_lok = context.Lokalizacje.Count();
                    int no_of_komps = context.Komputery.Count();
                    int no_of_jo = context.JednostkiOrg.Count();
                    
                    var im = manager.imie;
                    //int t = 0;
                }
            }*/

            //List<Uzytkownik> users_lists = new List<Uzytkownik>();



            return View(jednostkiOrgRepo.GetJednostkiOrg().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(JednostkaOrg j)
        {
            jednostkiOrgRepo.InsertJednostkaOrg(j);
            jednostkiOrgRepo.Save();
            
            //to mial byc komentarz utworzenia obiektu.
            ViewBag.message = "Obiect "+j.nazwa+" stworzono!";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(jednostkiOrgRepo.GetJednostkaOrgByID(id));
        }

        public ActionResult Edit(int id)
        {
            JednostkaOrg j = jednostkiOrgRepo.GetJednostkaOrgByID(id);
            //ViewBag.Possiblelokalizacjas = context.Lokalizacje;
            return View(j);
        }


        [HttpPost]
        public ActionResult Edit(JednostkaOrg j)
        {
            if (ModelState.IsValid)
            {
                context.Entry(j).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(j);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
