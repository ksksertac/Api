using Microsoft.EntityFrameworkCore;
using Order.Api.Domain;

namespace Order.Api.Persistence
{
    public class OrderDb : DbContext
    {
        public DbSet<Order.Api.Domain.Order> Orders { get; set; }

        public OrderDb(DbContextOptions<OrderDb> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order.Api.Domain.Order>().HasData(new Order.Api.Domain.Order
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = "ksksertac@gmail.com",
                    IsActive  = true,
                    CreatedDate = DateTime.Now
                }
            );
            base.OnModelCreating(modelBuilder);
        }

    
    }
}