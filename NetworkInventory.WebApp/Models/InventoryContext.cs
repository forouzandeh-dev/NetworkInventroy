using Microsoft.EntityFrameworkCore;



namespace NetworkInventory.WebApp.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }
        

        public DbSet<Device> Devices { get; set; }
        public DbSet<ConnectivityItem> ConnectivityItems { get; set; }
        public DbSet<DeviceCategory> DeviceCategories { get; set; }
        
        
    }
}
