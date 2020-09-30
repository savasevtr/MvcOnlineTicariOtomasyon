using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Kategori
    {
        [Key]
        [DisplayName("Kategori")]
        public int KategoriID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Kategori Adı")]
        public string KategoriAd { get; set; }

        public virtual ICollection<Urun> Uruns { get; set; }
    }
}