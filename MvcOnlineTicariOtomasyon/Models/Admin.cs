using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Admin
    {
        [Key]
        [DisplayName("Admin")]
        public int AdminID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [DisplayName("Kullanıcı Adı")]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        [DisplayName("Şifre")]
        public string Sifre { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Yetki { get; set; }
    }
}