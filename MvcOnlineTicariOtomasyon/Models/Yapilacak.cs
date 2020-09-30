using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Yapilacak
    {
        [Key]
        [DisplayName("Yapılacak")]
        public int YapilacakID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [DisplayName("Başlık")]
        public string Baslik { get; set; }

        public bool Durum { get; set; }

    }
}