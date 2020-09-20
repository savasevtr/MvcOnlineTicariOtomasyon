using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var faturalar = context.Faturas.ToList();

            return View(faturalar);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Fatura fatura)
        {
            if (!ModelState.IsValid)
            {
                return View(fatura);
            }

            context.Faturas.Add(fatura);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}