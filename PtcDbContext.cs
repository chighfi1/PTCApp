using Microsoft.EntityFrameworkCore;
using PTCApp.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PTCApp.Models
{
    public partial class PtcDbContext : DbContext
    {
        public PtcDbContext(DbContextOptions<PtcDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public DbSet<UserBase> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
