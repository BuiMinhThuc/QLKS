using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Quản_Lý_Khách_Sạn.Entities
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillFood> BillFoods { get; set; }
        public virtual DbSet<BillRoom> BillRooms { get; set; }
        public virtual DbSet<BillService> BillServices { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<ComfirmEmail> ComfirmEmails { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<LichLamViec> LichLamViecs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(e => e.TotalMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Food>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<RoomType>()
                .Property(e => e.HourlyPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Service>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
