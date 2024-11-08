using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_232410101074_utspbo.App.Models
{
    public class M_Admin
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nama { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int buku_baru { get; set; }
        [ForeignKey("M_BukuBaru")]
        public int id_buku { get; set; }

    }
}
