using System;
using System.ComponentModel.DataAnnotations;

namespace NetworkInventory.WebApp.Models
{
    public class ConnectivityItem
    {
        public int Id { get; set; }

        [Required]
        public string? Type { get; set; }
        [Required]
        public string?   Length { get; set; }
        public string? Location { get; set; }
        [Display(Name ="Instalation Name")]
        [DataType(DataType.Date)]
        public DateTime InstallationDate { get; set; }

        
    }
}
