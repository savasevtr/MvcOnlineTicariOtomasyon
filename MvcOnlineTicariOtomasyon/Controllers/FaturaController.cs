﻿using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;

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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var fatura = context.Faturas.Find(id);

            return View(fatura);
        }

        [HttpPost]
        public ActionResult Edit(Fatura fatura)
        {
            if (!ModelState.IsValid)
            {
                return View(fatura);
            }

            var _fatura = context.Faturas.Find(fatura.FaturaID);

            _fatura.FaturaSeriNo = fatura.FaturaSeriNo;
            _fatura.FaturaSiraNo = fatura.FaturaSiraNo;
            _fatura.Tarih = fatura.Tarih;
            _fatura.Saat = fatura.Saat;
            _fatura.TeslimEden = fatura.TeslimEden;
            _fatura.TeslimAlan = fatura.TeslimAlan;
            _fatura.VergiDairesi = fatura.VergiDairesi;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var fatura_kalemler = context.FaturaKalems.Where(x => x.FaturaID == id).ToList();

            ViewBag.FaturaID = id;

            return View(fatura_kalemler);
        }

        public ActionResult CreateInvoiceItem(int id)
        {
            ViewBag.FaturaID = id;

            return View();
        }

        [HttpPost]
        public ActionResult CreateInvoiceItem(FaturaKalem faturaKalem)
        {
            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();

            return RedirectToAction("Details", new { id = faturaKalem.FaturaID });
        }
    }
}