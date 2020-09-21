using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            var stok_sayisi = context.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.stok_sayisi = stok_sayisi;

            var marka_sayisi = (from x in context.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.marka_sayisi = marka_sayisi;

            var kritik_stok_seviye = context.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.kritik_stok_seviye = kritik_stok_seviye;

            //var max_fiyat_urun = (from x in context.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            //ViewBag.max_fiyat_urun = max_fiyat_urun;

            //var min_fiyat_urun = (from x in context.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            //ViewBag.min_fiyat_urun = min_fiyat_urun;

            //var buz_dolabi_sayisi = context.Uruns.Count(x => x.UrunAd.ToLower() == "buz dolabı").ToString();
            //ViewBag.buz_dolabi_sayisi = buz_dolabi_sayisi;

            //var laptop_sayisi = context.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            //ViewBag.laptop_sayisi = laptop_sayisi;

            var toplam_tutar = context.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.toplam_tutar = toplam_tutar;

            DateTime bugun = DateTime.Today;
            var bugun_satis_sayisi = context.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.bugun_satis_sayisi = bugun_satis_sayisi;

            var bugun_toplam_tutar = context.SatisHarekets.Where(x => x.Tarih == bugun).Sum(x => x.ToplamTutar).ToString();
            ViewBag.bugun_toplam_tutar = bugun_toplam_tutar;

            return View();
        }
    }
}