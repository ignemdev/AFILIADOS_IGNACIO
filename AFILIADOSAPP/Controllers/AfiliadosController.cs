using AFILIADOSAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AFILIADOSAPP.Controllers
{
    public class AfiliadosController : Controller
    {
        private AFILIADOS_IGNACIOEntities _db;

        public AfiliadosController() => _db = new AFILIADOS_IGNACIOEntities();

        //[HttpGet]
        //public ActionResult Index() => View(_db.AFILIADOS.ToList());

        [HttpGet]
        public ActionResult Index(string criterio)
        {
            return View(_db.AFILIADOS.Where(
                  a => criterio == null||
                a.Nombre.StartsWith(criterio) ||
                a.Apellido.StartsWith(criterio) ||
                a.Cedula.StartsWith(criterio)).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var afiliado = new AFILIADOS();
            afiliado.EstatusList = new SelectList(_db.ESTATUS.ToList(), "Id", "Estatus1");
            afiliado.PlanesList = new SelectList(_db.PLANES.ToList(), "Id", "PlanDescripcion");
            return View(afiliado);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var afiliado = _db.AFILIADOS.FirstOrDefault(p => p.Id == id);

            if (afiliado is null)
                return RedirectToAction(nameof(Index));

            afiliado.EstatusList = new SelectList(_db.ESTATUS.ToList(), "Id", "Estatus1");
            afiliado.PlanesList = new SelectList(_db.PLANES.ToList(), "Id", "PlanDescripcion");
            return View(afiliado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AFILIADOS afiliado)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            _db.Entry(afiliado).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AFILIADOS afiliado)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            _db.AFILIADOS.Add(afiliado);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Disable(int id)
        {
            var afiliado = _db.AFILIADOS.FirstOrDefault(p => p.Id == id);

            if (afiliado is null)
                return RedirectToAction(nameof(Index));

            afiliado.EstatusId = 2;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Able(int id)
        {
            var afiliado = _db.AFILIADOS.FirstOrDefault(p => p.Id == id);

            if (afiliado is null)
                return RedirectToAction(nameof(Index));

            afiliado.EstatusId = 1;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult AddAmount(int id)
        {
            var afiliado = _db.AFILIADOS.FirstOrDefault(p => p.Id == id);

            if (afiliado is null)
                return RedirectToAction(nameof(Index));

            afiliado.MontoConsumido = 0;

            return View(afiliado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAmount(AFILIADOS afiliado)
        {
            var dbAfiliado = _db.AFILIADOS.FirstOrDefault(p => p.Id == afiliado.Id);

            if (dbAfiliado is null)
                return RedirectToAction(nameof(Index));

            dbAfiliado.MontoConsumido += afiliado.MontoConsumido;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}