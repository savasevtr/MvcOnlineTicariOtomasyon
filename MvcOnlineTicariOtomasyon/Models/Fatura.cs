using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Fatura
    {
        [Key]
        [DisplayName("Fatura")]
        public int FaturaID { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        [DisplayName("Fatura Seri No")]
        public string FaturaSeriNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        [DisplayName("Fatura Sıra No")]
        public string FaturaSiraNo { get; set; }

        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        [DisplayName("Vergi Dairesi")]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Teslim Eden")]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Teslim Alan")]
        public string TeslimAlan { get; set; }

        public decimal Toplam { get; set; }

        public virtual ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}