using Microsoft.EntityFrameworkCore;
using ShagunMarriage.Models;
using ShagunMarriage.Models.DBModels;

namespace ShagunMarriage.Repository
{
    public class ShagunMarriageDbContext : DbContext
    {
        public ShagunMarriageDbContext(DbContextOptions<ShagunMarriageDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
