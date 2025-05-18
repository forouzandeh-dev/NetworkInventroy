using System;
using System.ComponentModel.DataAnnotations;

namespace NetworkInventory.WebApp.Models
{
    public class ConnectivityItem
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        [Required]
        //Common field
        public string? ItemType { get; set; }  //e.g, "Cable, "KeyStone", "Faceplate"
        [Required]

        //Cable-specific
        public double? Length { get; set; }

        public string? CableType {  get; set; }

        //Keystone-specific

        public string? KeystoneCategory {  get; set; } // e.g., Cat6, Cat7

        // Faceplate-specific
        public int? PortCount { get; set; }

        public string? Location { get; set; }
        [Display(Name = "Instalation Date")]
        [DataType(DataType.Date)]
        public DateTime InstallationDate { get; set; }

        
    }
}
