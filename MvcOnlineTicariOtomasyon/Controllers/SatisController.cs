using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            List<SelectListItem> urunler = (from x in context.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();

            List<SelectListItem> cariler = (from x in context.Caris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();

            List<SelectListItem> personeller = (from x in context.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                Value = x.PersonelID.ToString()
                                            }).ToList();

            ViewBag.urunler = urunler;
            ViewBag.cariler = cariler;
            ViewBag.personeller = personeller;

            return View();
        }

        [HttpPost]
        public ActionResult Create(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var satis = context.SatisHarekets.Find(id);

            List<SelectListItem> urunler = (from x in context.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();

            List<SelectListItem> cariler = (from x in context.Caris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariID.ToString()
                                            }).ToList();

            List<SelectListItem> personeller = (from x in context.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelID.ToString()
                                                }).ToList();

            ViewBag.urunler = urunler;
            ViewBag.cariler = cariler;
            ViewBag.personeller = personeller;

            return View(satis);
        }

        [HttpPost]
        public ActionResult Edit(SatisHareket satisHareket)
        {


            return RedirectToAction("Index");
        }
    }
}