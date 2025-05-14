using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetworkInventory.WebApp.Models
{
    public class Device
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Display(Name = "Device Category")]
        [Required]
        public int DeviceCategoryId { get; set; }

        [ForeignKey("DeviceCategoryId")]
        public DeviceCategory? DeviceCategory { get; set; }
        [Required]
        public required string location { get; set; }   // e.g., Data Center, Office 1

        [Display(Name = "Installation Date")]
        [DataType(DataType.Date)]
        public DateTime InstallationDate { get; set; }
    }
}
