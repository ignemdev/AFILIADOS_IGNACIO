using AFILIADOSAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AFILIADOSAPP.Controllers
{
    public class PlanesController : Controller
    {
        private AFILIADOS_IGNACIOEntities _db;

        public PlanesController() => _db = new AFILIADOS_IGNACIOEntities();

        [HttpGet]
        public ActionResult Index() => View(_db.PLANES.ToList());

        [HttpGet]
        public ActionResult Create() {
            var plan = new PLANES();
            plan.EstatusList = new SelectList(_db.ESTATUS.ToList(), "Id", "Estatus1");
            return View(plan);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PLANES plan)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            _db.PLANES.Add(plan);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var plan = _db.PLANES.FirstOrDefault(p => p.Id == id);

            if (plan is null)
                return RedirectToAction(nameof(Index));

            plan.EstatusList = new SelectList(_db.ESTATUS.ToList(), "Id", "Estatus1");
            return View(plan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PLANES plan)
        {
            if(!ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            _db.Entry(plan).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult Disable(int id)
        {
            var plan = _db.PLANES.FirstOrDefault(p => p.Id == id);

            if(plan is null)
                return RedirectToAction(nameof(Index));

            plan.EstatusId = 2;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Able(int id)
        {
            var plan = _db.PLANES.FirstOrDefault(p => p.Id == id);

            if (plan is null)
                return RedirectToAction(nameof(Index));

            plan.EstatusId = 1;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}