using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CariPanelController : Controller
    {

        Context context = new Context();
  
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var cari = context.Caris.FirstOrDefault(x => x.CariMail == mail);

            return View(cari);
        }

        [HttpPost]
        public ActionResult Index(Cari cari)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = context.Caris.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();

            var siparisler = context.SatisHarekets.Where(x => x.CariID == id).ToList();

            return View(siparisler);
        }

    }
}