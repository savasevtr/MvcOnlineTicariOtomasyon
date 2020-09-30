using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Personel
    {
        [Key]
        [DisplayName("Personel")]
        public int PersonelID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Personel Adı")]
        public string PersonelAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Personel Soyadı")]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [DisplayName("Personel Görsel")]
        public string PersonelGorsel { get; set; }

        [DisplayName("Departman")]
        public int DepartmanID { get; set; }

        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }
        public virtual Departman Departman { get; set; }
    }
}