using Microsoft.EntityFrameworkCore;
using RabbitMQApp.WatermarkWebApp.Models;

namespace RabbitMQApp.WatermarkWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
