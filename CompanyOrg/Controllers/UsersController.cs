using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CompanyOrg.Models;
using CompanyOrg.DAL;

namespace CompanyOrg.Controllers
{
    public class UsersController : Controller
    {
        private DAL.IUsersRepository usersRepo;
        private Models.CompanyContext context;

        public UsersController()
        {
            context = new CompanyContext();
            usersRepo = new DAL.UsersRepository(context);
        }

        public UsersController(Models.CompanyContext cont)
        {
            context = cont;
            usersRepo = new DAL.UsersRepository(context);
        }

        //
        // GET: /Uzytkownik/

        public ActionResult Index()
        {
            return View(usersRepo.GetUsers());
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Uzytkownik u)
        {
            usersRepo.InsertUser(u);
            usersRepo.Save();

            return View(u);
        }


        public ActionResult Details(int id)
        {
            return View(usersRepo.GetUserByID(id));
        }

        public ActionResult Edit(int id)
        {
            Uzytkownik user = usersRepo.GetUserByID(id);
            //ViewBag.Possiblelokalizacjas = context.Lokalizacje;
            return View(user);
        }


        [HttpPost]
        public ActionResult Edit(Uzytkownik user)
        {
            if (ModelState.IsValid)
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(user);
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
