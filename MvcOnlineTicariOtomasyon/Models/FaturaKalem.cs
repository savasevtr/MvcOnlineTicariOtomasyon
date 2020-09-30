using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class FaturaKalem
    {
        [Key]
        [DisplayName("Fatura Kalem")]
        public int FaturaKalemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }

        public int Miktar { get; set; }

        [DisplayName("Birim Fiyat")]
        public decimal BirimFiyat { get; set; }

        public decimal Tutar { get; set; }

        [DisplayName("Fatura")]
        public int FaturaID { get; set; }

        public virtual Fatura Fatura { get; set; }
    }
}