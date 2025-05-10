using System;
using System.ComponentModel.DataAnnotations;
namespace NetworkInventory.WebApp.Models
{
    public class Device
    {
        public int Id { get; set; }

        [Display(Name ="Device Category")]
        public int DeviceCategoryId { get; set; }

        public DeviceCategory DeviceCategory { get; set; }

        public string location { get; set; }   // e.g., Data Center, Office 1

        [Display(Name ="Installation Date")]
        [DataType(DataType.Date)]
        public DateTime InstallationDate { get; set; }


    }
}
