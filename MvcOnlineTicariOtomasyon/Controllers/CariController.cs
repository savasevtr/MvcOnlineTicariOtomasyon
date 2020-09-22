using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
            cari.Durum = true;
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

            if (!ModelState.IsValid)
            {
                return View(_cari);
            }

            _cari.CariAd = cari.CariAd;
            _cari.CariSoyad = cari.CariSoyad;
            _cari.CariMail = cari.CariMail;
            _cari.CariSehir = cari.CariSehir;
            // _cari.Durum = cari.Durum;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var cari = context.Caris.Find(id);
            cari.Durum = false;
            
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var satislar = context.SatisHarekets.Where(x => x.CariID == id).ToList();
            var cari = context.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();

            ViewBag.cari = cari;

            return View(satislar);
        }
    }
}