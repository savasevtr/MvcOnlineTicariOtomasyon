using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context context = new Context();
        
        public ActionResult Index()
        {
            var departmanlar = context.Departmans.Where(x => x.Durum == true).ToList();

            return View(departmanlar);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Departman departman)
        {
            context.Departmans.Add(departman);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var departman = context.Departmans.Find(id);

            return View(departman);
        }

        [HttpPost]
        public ActionResult Edit(Departman departman)
        {
            var _departman = context.Departmans.Find(departman.DepartmanID);

            _departman.DepartmanAd = departman.DepartmanAd;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var departman = context.Departmans.Find(id);

            departman.Durum = false;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            //var departman = context.Departmans.Find(id);

            var personeller = context.Personels.Where(x => x.DepartmanID == id).ToList();
            var DepartmentName = context.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.DepartmentName = DepartmentName;

            return View(personeller);
        }

        public ActionResult PersonelSales(int id)
        {
            var satislar = context.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var personel = context.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.personel = personel;

            return View(satislar);
        }
    }
}