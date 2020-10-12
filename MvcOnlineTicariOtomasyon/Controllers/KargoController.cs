using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var kargolar = context.KargoDetays.ToList();

            return View(kargolar);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KargoDetay kargoDetay)
        {
            context.KargoDetays.Add(kargoDetay);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}