using System;
namespace NetworkInventory.WebApp.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }   // e.g., Cisco Switch, Router
        public string type { get; set; }   // e.g., Switch, Router, Access Point
        public string location { get; set; }   // e.g., Data Center, Office 1

        public DateTime InstallationDate { get; set; }


    }
}
