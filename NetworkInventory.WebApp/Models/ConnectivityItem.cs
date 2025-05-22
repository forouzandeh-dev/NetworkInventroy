using System;
using System.ComponentModel.DataAnnotations;

namespace NetworkInventory.WebApp.Models
{
    public class ConnectivityItem
    {
        public int Id { get; set; }

        public string? Name { get; set; }
       
        //Common field
        public string? ItemType { get; set; }  //e.g, "Cable, "KeyStone", "Faceplate"
       

        //Cable-specific
        public double? Length { get; set; }

        public string? CableType {  get; set; }

        //Keystone-specific

        public string? KeystoneCategory {  get; set; } // e.g., Cat6, Cat7

        // Faceplate-specific
        public int? PortCount { get; set; }

        public string? FiberMode {  get; set; } // e.g, single-mode, multi-mode
        public string? ConnectorType { get; set; } // e.g., LC, SC, ST


        public string? SfpType  { get; set; }// e.g., 1G-SX, 10G-LR
        public int? TransmissionDistance { get; set; }// in meters


        public string? Location { get; set; }
        [Display(Name = "Instalation Date")]
        [DataType(DataType.Date)]
        public DateTime InstallationDate { get; set; }

        
    }
}
