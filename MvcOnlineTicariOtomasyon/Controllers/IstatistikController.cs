using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var cari_sayisi = context.Caris.Count().ToString();
            ViewBag.cari_sayisi = cari_sayisi;

            var urun_sayisi = context.Uruns.Count().ToString();
            ViewBag.urun_sayisi = urun_sayisi;

            var personel_sayisi = context.Personels.Count().ToString();
            ViewBag.personel_sayisi = personel_sayisi;

            var kategori_sayisi = context.Kategoris.Count().ToString();
            ViewBag.kategori_sayisi = kategori_sayisi;

            return View();
        }
    }
}