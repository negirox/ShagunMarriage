using Microsoft.EntityFrameworkCore;
using ShagunMarriage.Models;
using ShagunMarriage.Models.DBModels;

namespace ShagunMarriage.Repository
{
    public class ShagunMarriageDbContext(DbContextOptions<ShagunMarriageDbContext> options) : DbContext(options)
    {
        public DbSet<UserModel> Users { get; set; }

        public DbSet<MatrimonialUserModel> MatrimonialUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureRelationShipsofTable(modelBuilder);

            // Configure auto-incrementing primary keys
            ConfigureAutoIncrement(modelBuilder);

            // Configure decimal properties
            ConfigureDecimalProperties(modelBuilder);

            // Seed initial data
            SeedInitialDataToDefaultTables(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedInitialDataToDefaultTables(ModelBuilder modelBuilder)
        {

        }

        private static void ConfigureDecimalProperties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatrimonialUserModel>()
                      .Property(m => m.AnnualIncome)
                      .HasColumnType("decimal(18,2)");

        }

        private static void ConfigureAutoIncrement(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
               .Property(u => u.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<MatrimonialUserModel>()
                  .Property(u => u.Id)
                  .ValueGeneratedOnAdd();
        }

        private static void ConfigureRelationShipsofTable(ModelBuilder modelBuilder)
        {
            // Configure one-to-one relationship
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.MatrimonialProfile)
                .WithOne(m => m.User)
                .HasForeignKey<MatrimonialUserModel>(m => m.UserId);

        }
    }
}
