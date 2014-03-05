using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CompanyOrg.DAL;
using CompanyOrg.Models;

namespace CompanyOrg.Controllers
{   
    public class ComputersController : Controller
    {
        private CompanyContext context = new CompanyContext();
        private DAL.ICompRepository compRepo;

        public ComputersController()
        {
            context = new CompanyContext();
            compRepo = new DAL.CompRepository(context);
        }

        public ComputersController(CompanyContext cont)
        {
            context = cont;
            compRepo = new DAL.CompRepository(context);
        }

        //
        // GET: /Komputer/

        public ViewResult Index()
        {
            return View(compRepo.GetComps());
        }

        //
        // GET: /Komputer/Details/5

        public ViewResult Details(int id)
        {
            return View(compRepo.GetCompByID(id));
        }

        //
        // GET: /Komputer/Create

        public ActionResult Create()
        {
            ViewBag.Possiblelokalizacjas = context.Lokalizacje;
            return View();
        } 

        //
        // POST: /Komputer/Create

        [HttpPost]
        public ActionResult Create(Komputer komputer)
        {
            if (ModelState.IsValid)
            {
                context.Komputery.Add(komputer);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.Possiblelokalizacjas = context.Lokalizacje;
            return View(komputer);
        }
        
        //
        // GET: /Komputer/Edit/5
 
        public ActionResult Edit(int id)
        {
            Komputer komputer = context.Komputery.Single(x => x.Id == id);
            //ViewBag.Possiblelokalizacjas = context.Lokalizacje;//? a to po co generowal
            return View(komputer);
        }

        //
        // POST: /Komputer/Edit/5

        [HttpPost]
        public ActionResult Edit(Komputer komputer)
        {
            if (ModelState.IsValid)
            {
                context.Entry(komputer).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Possiblelokalizacjas = context.Lokalizacje;
            return View(komputer);
        }

        //
        // GET: /Komputer/Delete/5
 
        public ActionResult Delete(int id)
        {
            Komputer komputer = context.Komputery.Single(x => x.Id == id);
            return View(komputer);
        }

        //
        // POST: /Komputer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Komputer komputer = context.Komputery.Single(x => x.Id == id);
            context.Komputery.Remove(komputer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}