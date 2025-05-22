using Fabio_Aplication.Models;
using System;
using System.Data.Entity;
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
            var funcionarios = db.FUNCIONARIOS
                           .Include(f => f.PAGAMENTO_FUNCIONARIOS)
                           .ToList();

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
                return HttpNotFound();
            return View(funcionario);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FUNCIONARIOS funcionario)
        {
            if (ModelState.IsValid)
            {
                funcionario.DATAALT = DateTime.Now;
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        public ActionResult Delete(int id)
        {
            var funcionario = db.FUNCIONARIOS.Find(id);
            if (funcionario == null)
                return HttpNotFound();
            return View(funcionario);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var funcionario = db.FUNCIONARIOS.Find(id);
            if (funcionario == null)
                return HttpNotFound();

            
            var pagamentos = db.PAGAMENTO_FUNCIONARIOS.Where(p => p.FUNCIONARIO_ID == id).ToList();
            db.PAGAMENTO_FUNCIONARIOS.RemoveRange(pagamentos);

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