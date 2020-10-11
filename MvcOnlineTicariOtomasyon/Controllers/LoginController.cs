using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult CariKayitPartial()
        {
            return PartialView();
        }
        
        [HttpPost]
        public PartialViewResult CariKayitPartial(Cari cari)
        {
            context.Caris.Add(cari);
            context.SaveChanges();

            return PartialView();
        }

        [HttpGet]
        public PartialViewResult CariGirisPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult CariGirisPartial(Cari cari)
        {
            var _cari = context.Caris.FirstOrDefault(x => x.CariMail == cari.CariMail && x.CariSifre == cari.CariSifre);

            if (_cari != null)
            {
                FormsAuthentication.SetAuthCookie(_cari.CariMail, false);
                Session["CariMail"] = _cari.CariMail.ToString();

                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public PartialViewResult PersonelGirisPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PersonelGirisPartial(Personel p)
        {
            return PartialView();
        }
    }
}