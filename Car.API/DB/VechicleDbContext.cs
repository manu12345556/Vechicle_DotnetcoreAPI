using Car.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Car.API.DB
{

    public class VechicleDbContext : DbContext
    {
        public VechicleDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cars>()
                .Property(c => c.CarModelId)
                .IsRequired();

            modelBuilder.Entity<Cars>()
                .HasOne(c => c.CarModel)
                .WithMany() // 
                .HasForeignKey(c => c.CarModelId)
                .OnDelete(DeleteBehavior.Restrict); 
            base.OnModelCreating(modelBuilder);
        }

    }

}