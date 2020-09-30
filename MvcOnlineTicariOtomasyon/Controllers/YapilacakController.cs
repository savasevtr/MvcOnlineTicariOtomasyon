using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            //var deger1 = context.Caris.Count().ToString();
            //var deger2 = context.Uruns.Count().ToString();
            //var deger3 = context.Kategoris.Count().ToString();
            //var deger4 = (from x in context.Caris select x.CariSehir).Distinct().Count().ToString();

            //ViewBag.deger1 = deger1;
            //ViewBag.deger2 = deger2;
            //ViewBag.deger3 = deger3;
            //ViewBag.deger4 = deger4;

            var yapilacaklar = context.Yapilacaks.ToList();

            return View(yapilacaklar);
        }
    }
}