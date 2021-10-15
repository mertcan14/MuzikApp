using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MuzikMvcApp.Models
{
    public class Muzik
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SarkiIsmi { get; set; }
        public string? AlbumIsmi { get; set; }
        [Required]
        public string Artist { get; set; }
        public int? CikisYili { get; set; }
    }
}
