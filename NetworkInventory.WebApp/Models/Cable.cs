using System;

namespace NetworkInventory.WebApp.Models
{
    public class Cable
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
        public string Location { get; set; }
        public DateTime InstallationDate { get; set; }

        
    }
}
