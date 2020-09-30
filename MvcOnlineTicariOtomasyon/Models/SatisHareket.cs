using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class SatisHareket
    {
        [Key]
        [DisplayName("Satış Hareket")]
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }

        [DisplayName("Toplam Tutar")]
        public decimal ToplamTutar { get; set; }

        [DisplayName("Ürün")]
        public int UrunID { get; set; }

        [DisplayName("Cari")]
        public int CariID { get; set; }

        [DisplayName("Personel")]
        public int PersonelID { get; set; }

        [DisplayName("Ürün")]
        public virtual Urun Urun { get; set; }

        [DisplayName("Cari")]
        public virtual Cari Cari { get; set; }

        [DisplayName("Personel")]
        public virtual Personel Personel { get; set; }
    }
}