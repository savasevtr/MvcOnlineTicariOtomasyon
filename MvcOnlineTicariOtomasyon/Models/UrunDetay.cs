using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class UrunDetay
    {
        [Key]
        [DisplayName("Ürün Detay")]
        public int UrunDetayID { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Ürün Adı")]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        [DisplayName("Ürün Bilgisi")]
        public string UrunBilgi { get; set; }

        [DisplayName("Ürün")]
        public int UrunID { get; set; }

        public virtual Urun Urun { get; set; }
    }
}