using System;
using System.ComponentModel.DataAnnotations;
namespace NetworkInventory.WebApp.Models
{
    public class Device
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }   // e.g., Cisco Switch, Router

        [Required]
        public string type { get; set; }   // e.g., Switch, Router, Access Point


        public string location { get; set; }   // e.g., Data Center, Office 1

        [Display(Name ="Installation Date")]
        [DataType(DataType.Date)]
        public DateTime InstallationDate { get; set; }


    }
}
