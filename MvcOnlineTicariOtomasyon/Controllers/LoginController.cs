using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}