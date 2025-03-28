using Fabio_Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fabio_Aplication.Controllers
{
    public class AquisicaoAnimaisController : Controller
    {

        private BancoEntities db = new BancoEntities();
        // GET: AquisicaoAnimais
 

        // GET: Funcionarios
        public ActionResult Index()
        {
            var animais = db.AQUISICAO_ANIMAIS.ToList();
            return View(animais);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AQUISICAO_ANIMAIS animais)
        {
            if (ModelState.IsValid)
            {
             
               

                db.AQUISICAO_ANIMAIS.Add(animais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animais);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int id)
        {
            var animais = db.AQUISICAO_ANIMAIS.Find(id);
            if (animais == null)
            {
                return HttpNotFound();
            }
            return View(animais);
        }

        // POST: Funcionarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AQUISICAO_ANIMAIS animais)
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(animais).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animais);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int id)
        {
            var animais = db.AQUISICAO_ANIMAIS.Find(id);
            if (animais == null)
            {
                return HttpNotFound();
            }
            return View(animais);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var animais = db.AQUISICAO_ANIMAIS.Find(id);
            db.AQUISICAO_ANIMAIS.Remove(animais);
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
