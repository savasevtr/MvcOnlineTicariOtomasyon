using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context context = new Context();
        public ActionResult Index(string p)
        {
            var kargolar = from x in context.KargoDetays select x;

            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));
            }

            return View(kargolar.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H", "K" };
            int k1, k2, k3;
            k1 = random.Next(0, karakterler.Length);
            k2 = random.Next(0, karakterler.Length);
            k3 = random.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 100);
            s3 = random.Next(10, 100);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkodu = kod;

            return View();
        }

        [HttpPost]
        public ActionResult Create(KargoDetay kargoDetay)
        {
            context.KargoDetays.Add(kargoDetay);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            var detaylar = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();

            return View(detaylar);
        }
    }
}