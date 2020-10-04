using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context context = new Context();

        public ActionResult Index(int sayfa = 1)
        {
            var kategoriler = context.Kategoris.ToList().ToPagedList(sayfa, 4);

            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kategori kategori)
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var kategori = context.Kategoris.Find(id);

            return View(kategori);
        }

        [HttpPost]
        public ActionResult Edit(Kategori kategori)
        {
            var _kategori = context.Kategoris.Find(kategori.KategoriID);
            _kategori.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var kategori = context.Kategoris.Find(id);
            context.Kategoris.Remove(kategori);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}