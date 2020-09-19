using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var satislar = context.SatisHarekets.ToList();

            return View(satislar);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SatisHareket satisHareket)
        {
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var satis = context.SatisHarekets.Find(id);

            return View(satis);
        }

        [HttpPost]
        public ActionResult Edit(SatisHareket satisHareket)
        {


            return RedirectToAction("Index");
        }
    }
}