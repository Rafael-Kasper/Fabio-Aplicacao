using Fabio_Aplication.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace Fabio_Aplication.Controllers
{
    public class PagamentosController : Controller
    {
        private BancoEntities db = new BancoEntities();

        // GET: Pagamentos
        public ActionResult Index()
        {
            var pagamentos = db.PAGAMENTO_FUNCIONARIOS.Include(p => p.FUNCIONARIOS).ToList();
            return View(pagamentos);
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            var funcionarios = db.FUNCIONARIOS.OrderBy(f => f.NOME).ToList();
            ViewBag.FUNCIONARIO_ID = new SelectList(funcionarios, "ID", "NOME");
            return View(new PAGAMENTO_FUNCIONARIOS());
        }

        // POST: Pagamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PAGAMENTO_FUNCIONARIOS pagamento)
        {
            ModelState.Remove("SALARIO_LIQUIDO");
            if (ModelState.IsValid)
            {
                pagamento.SALARIO_LIQUIDO = pagamento.SALARIO + pagamento.ACRESCIMO - pagamento.DESCONTO;
                db.PAGAMENTO_FUNCIONARIOS.Add(pagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var funcionarios = db.FUNCIONARIOS.OrderBy(f => f.NOME).ToList();
            ViewBag.FUNCIONARIO_ID = new SelectList(funcionarios, "ID", "NOME", pagamento.FUNCIONARIO_ID);
            return View(pagamento);
        }

        // GET: Pagamentos/Details/5 (opcional)
        public ActionResult Details(int id)
        {
            var pagamento = db.PAGAMENTO_FUNCIONARIOS.Find(id);
            if (pagamento == null) return HttpNotFound();
            return View(pagamento);
        }

        public ActionResult Historico()
        {
            var pagamentos = db.PAGAMENTO_FUNCIONARIOS.Include(p => p.FUNCIONARIOS).ToList();
            return View(pagamentos);
        }

        // Dispose padrão
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