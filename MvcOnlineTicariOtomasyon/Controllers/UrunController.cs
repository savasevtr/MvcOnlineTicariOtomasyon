﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var urunler = context.Uruns.Where(x => x.Durum == true).ToList();

            return View(urunler);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> kategoriler = (from x in context.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();

            ViewBag.kategoriler = kategoriler;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Urun urun)
        {
            context.Uruns.Add(urun);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var urun = context.Uruns.Find(id);

            List<SelectListItem> kategoriler = (from x in context.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();

            ViewBag.kategoriler = kategoriler;

            return View(urun);
        }

        [HttpPost]
        public ActionResult Edit(Urun urun)
        {
            var _urun = context.Uruns.Find(urun.UrunID);

            _urun.UrunAd = urun.UrunAd;
            _urun.Marka = urun.Marka;
            _urun.KategoriID = urun.KategoriID;
            _urun.AlisFiyat = urun.AlisFiyat;
            _urun.SatisFiyat = urun.SatisFiyat;
            _urun.Stok = urun.Stok;
            _urun.Durum = urun.Durum;
            _urun.UrunGorsel = urun.UrunGorsel;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var urun = context.Uruns.Find(id);
            urun.Durum = false;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}