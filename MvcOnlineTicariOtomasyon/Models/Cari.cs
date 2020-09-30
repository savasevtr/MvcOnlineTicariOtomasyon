using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Cari
    {
        [Key]
        [DisplayName("Cari")]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [DisplayName("Cari Ad")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [DisplayName("Cari Soyad")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(14, ErrorMessage = "En fazla 14 karakter yazabilirsiniz")]
        [DisplayName("Cari Şehir")]
        public string CariSehir { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter yazabilirsiniz")]
        [DisplayName("Cari Mail")]
        public string CariMail { get; set; }

        [DisplayName("Cari Durum")]
        public bool Durum { get; set; }

        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}