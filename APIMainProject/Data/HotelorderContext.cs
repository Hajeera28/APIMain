using APIMainProject.Models;
using Microsoft.EntityFrameworkCore;
    namespace APIMainProject.Data
{
    public class HotelorderContext : DbContext
    {
        public HotelorderContext(DbContextOptions<HotelorderContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User → Orders (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Hotel → Orders (One-to-Many)
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Orders)
                .WithOne(o => o.Hotel)
                .HasForeignKey(o => o.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            // Order → OrderDetails (One-to-Many)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Enum mapping for OrderStatus
            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<string>(); // Store Enum as string (Readable in DB)

            
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderTime)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Alice", Email = "alice@example.com", Phone = "9876543210", Password = "pass123", Role = "Customer" },
                new User { UserId = 2, UserName = "Bob", Email = "bob@example.com", Phone = "8765432109", Password = "pass456", Role = "Customer" },
                new User { UserId = 3, UserName = "AdminUser", Email = "admin@example.com", Phone = "9999999999", Password = "admin123", Role = "Admin" }
            );


            // Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { HotelId = 1, HotelName = "Grand Palace", Location = "Chennai", Contact = "044-123456", Rating = 5 },
                new Hotel { HotelId = 2, HotelName = "Sea Breeze", Location = "Mumbai", Contact = "022-654321", Rating = 4 }
            );

            // Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, UserId = 1, HotelId = 1, Status = OrderStatus.Confirmed },
                new Order { OrderId = 2, UserId = 2, HotelId = 2, Status = OrderStatus.Pending }
            );

            // OrderDetails
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { OrderDetailId = 1, OrderId = 1, ItemName = "Chicken Biryani", Quantity = 2, Price = 250, PaymentMethod = "Card" },
                new OrderDetail { OrderDetailId = 2, OrderId = 1, ItemName = "Paneer Tikka", Quantity = 1, Price = 150, PaymentMethod = "Card" },
                new OrderDetail { OrderDetailId = 3, OrderId = 2, ItemName = "Fish Curry", Quantity = 1, Price = 300, PaymentMethod = "Cash" }
            );
        }
      
    }

    }

