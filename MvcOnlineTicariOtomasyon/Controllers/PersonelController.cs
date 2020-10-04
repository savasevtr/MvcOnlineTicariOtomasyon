using System;
using System.Collections.Generic;
using System.IO;
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
            if (Request.Files.Count > 0)
            {
                string dosya_adi = string.Format(@"{0}", DateTime.Now.Ticks);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosya_adi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel = "/Images/" + dosya_adi + uzanti;
            }

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

            if (Request.Files.Count > 0)
            {
                string mevcut_resim = _personel.PersonelGorsel;

                if (mevcut_resim != null)
                {
                    string mevcut_resim_yolu = Server.MapPath("~" + mevcut_resim);

                    if (System.IO.File.Exists(mevcut_resim_yolu))
                    {
                        System.IO.File.Delete(mevcut_resim_yolu);
                    }
                }

                string dosya_adi = string.Format(@"{0}", DateTime.Now.Ticks);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosya_adi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel = "/Images/" + dosya_adi + uzanti;
            }

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

            string mevcut_resim = personel.PersonelGorsel;

            if (mevcut_resim != null)
            {
                string mevcut_resim_yolu = Server.MapPath("~" + mevcut_resim);

                if (System.IO.File.Exists(mevcut_resim_yolu))
                {
                    System.IO.File.Delete(mevcut_resim_yolu);
                }
            }

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