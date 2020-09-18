using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var cariler = context.Caris.ToList();

            return View(cariler);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cari cari)
        {
            context.Caris.Add(cari);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cari = context.Caris.Find(id);

            return View(cari);
        }

        [HttpPost]
        public ActionResult Edit(Cari cari)
        {
            var _cari = context.Caris.Find(cari.CariID);

            _cari.CariAd = cari.CariAd;
            _cari.CariSoyad = cari.CariSoyad;
            _cari.CariMail = cari.CariMail;
            _cari.CariSehir = cari.CariSehir;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var cari = context.Caris.Find(id);

            context.Caris.Remove(cari);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}