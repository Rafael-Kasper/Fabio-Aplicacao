using Fabio_Aplication.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Fabio_Aplication.Controllers
{
    public class FuncionariosController : Controller
    {
        private BancoEntities db = new BancoEntities();

        // GET: Funcionarios
        public ActionResult Index()
        {
            var funcionarios = db.FUNCIONARIOS.ToList();
            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FUNCIONARIOS funcionario)
        {
            if (ModelState.IsValid)
            {
                funcionario.DATACAD = DateTime.Now;
                funcionario.DATAALT = DateTime.Now;

                db.FUNCIONARIOS.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int id)
        {
            var funcionario = db.FUNCIONARIOS.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FUNCIONARIOS funcionario)
        {
            if (ModelState.IsValid)
            {
                funcionario.DATAALT = DateTime.Now;

                db.Entry(funcionario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int id)
        {
            var funcionario = db.FUNCIONARIOS.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var funcionario = db.FUNCIONARIOS.Find(id);
            db.FUNCIONARIOS.Remove(funcionario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}