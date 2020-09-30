using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models
{
    public class Departman
    {
        [Key]
        [DisplayName("Departman")]
        public int DepartmanID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [DisplayName("Departman Adı")]
        public string DepartmanAd { get; set; }

        public bool Durum { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}