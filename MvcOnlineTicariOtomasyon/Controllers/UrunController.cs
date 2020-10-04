using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();

        public ActionResult Index(int sayfa = 1, string p = "")
        {
            var urunler = context.Uruns
                .Where(x => x.Durum == true)
                .Where(x => x.UrunAd.Contains(p))
                .ToList()
                .ToPagedList(sayfa, 3);

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
            if (Request.Files.Count > 0)
            {
                string dosya_adi = string.Format(@"{0}", DateTime.Now.Ticks);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + dosya_adi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                urun.UrunGorsel = "/Images/" + dosya_adi + uzanti;
            }

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

            if (Request.Files.Count > 0)
            {
                string mevcut_resim = _urun.UrunGorsel;

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
                _urun.UrunGorsel = "/Images/" + dosya_adi + uzanti;
            }

            _urun.UrunAd = urun.UrunAd;
            _urun.Marka = urun.Marka;
            _urun.KategoriID = urun.KategoriID;
            _urun.AlisFiyat = urun.AlisFiyat;
            _urun.SatisFiyat = urun.SatisFiyat;
            _urun.Stok = urun.Stok;
            _urun.Durum = urun.Durum;

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