using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MvcOnlineTicariOtomasyon.Models;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();
        
        public ActionResult Index()
        {
            var personeller = context.Personels.ToList();

            return View(personeller);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> departmanlar = (from x in context.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanAd,
                                                     Value = x.DepartmanID.ToString()
                                                 }).ToList();

            ViewBag.departmanlar = departmanlar;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Personel personel)
        {
            context.Personels.Add(personel);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var personel = context.Personels.Find(id);

            List<SelectListItem> departmanlar = (from x in context.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanAd,
                                                     Value = x.DepartmanID.ToString()
                                                 }).ToList();

            ViewBag.departmanlar = departmanlar;

            return View(personel);
        }

        [HttpPost]
        public ActionResult Edit(Personel personel)
        {
            var _personel = context.Personels.Find(personel.PersonelID);

            _personel.PersonelAd = personel.PersonelAd;
            _personel.PersonelSoyad = personel.PersonelSoyad;
            _personel.PersonelGorsel = personel.PersonelGorsel;
            _personel.DepartmanID = personel.DepartmanID;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var personel = context.Personels.Find(id);

            context.Personels.Remove(personel);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var personel = context.Personels.Find(id);

            return View(personel);
        }

        public ActionResult PersonnelList()
        {
            var personeller = context.Personels.ToList();

            return View(personeller);
        }

        public ActionResult ShowProfile(int id)
        {
            var personel = context.Personels.Find(id);

            return View(personel);
        }
    }
}