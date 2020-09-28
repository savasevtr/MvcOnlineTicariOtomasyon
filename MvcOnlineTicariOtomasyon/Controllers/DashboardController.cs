using MvcOnlineTicariOtomasyon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DashboardController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CategoryProducts()
        {
            var sorgu = from x in context.Uruns
                        group x by x.Kategori.KategoriAd into g
                        select new KategoriUrunGrup
                        {
                            Kategori = g.Key,
                            Sayi = g.Count()
                        };

            return PartialView(sorgu.ToList());
        }

        public PartialViewResult PersonnelDepartment()
        {
            var sorgu = from x in context.Personels
                        group x by x.Departman.DepartmanAd into g
                        select new PersonelDepartmanGrup
                        {
                            Departman = g.Key,
                            Sayi = g.Count()
                        };

            return PartialView(sorgu.ToList());
        }

        public PartialViewResult CustomerCity()
        {
            var sorgu = from x in context.Caris
                        group x by x.CariSehir into g
                        select new SehirMusteriGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };

            return PartialView(sorgu.ToList());
        }

        public PartialViewResult Customers()
        {
            var cariler = context.Caris.ToList();

            return PartialView(cariler);
        }

        public PartialViewResult Products()
        {
            var urunler = context.Uruns.ToList();

            return PartialView(urunler);
        }

        public PartialViewResult BrandProducts()
        {
            var sorgu = from x in context.Uruns
                        group x by x.Marka into g
                        select new MarkaUrunGrup
                        {
                            Marka = g.Key,
                            Sayi = g.Count()
                        };

            return PartialView(sorgu.ToList());
        }
    }
}