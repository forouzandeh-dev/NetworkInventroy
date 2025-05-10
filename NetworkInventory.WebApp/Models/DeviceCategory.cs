using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace NetworkInventory.WebApp.Models
{
    public class DeviceCategory
    { 
        public int Id { get; set; }

        [Required]
        [Display(Name ="Category Name")]
        public string Name { get; set; }

        // Navigation property to access devices under this category
        public ICollection<Device> Devices { get; set; }
    }
}
