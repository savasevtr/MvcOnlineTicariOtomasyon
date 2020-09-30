using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Urun
    {
        [Key]
        [DisplayName("Ürün")]
        public int UrunID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Ürün Adı")]
        public string UrunAd { get; set; }

        public string Marka { get; set; }
        public short Stok { get; set; }

        [DisplayName("Alış Fiyatı")]
        public decimal AlisFiyat { get; set; }

        [DisplayName("Satış Fiyatı")]
        public decimal SatisFiyat { get; set; }

        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [DisplayName("Ürün Görsel")]
        public string UrunGorsel { get; set; }

        [DisplayName("Kategori")]
        public int KategoriID { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}