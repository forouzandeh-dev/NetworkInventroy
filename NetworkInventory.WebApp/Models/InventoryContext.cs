using Microsoft.EntityFrameworkCore;


namespace NetworkInventory.WebApp.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }
        

        public DbSet<Device> Devices { get; set; }
        public DbSet<Cable> Cables { get; set; }
        
        
    }
}
