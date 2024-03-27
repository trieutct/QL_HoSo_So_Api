using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_QLHoSo_So.Model.Entities
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Kho> Khos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("tbl_User");
                e.HasKey(p => p.Id);
                e.Property(p=>p.FullName).IsRequired().HasMaxLength(100);
                e.Property(p=>p.Password).IsRequired().HasMaxLength(500);
            });
            modelBuilder.Entity<Kho>(e =>
            {
                e.ToTable("tbl_Kho");
                e.HasKey(p => p.Id);
                e.Property(p => p.MaKho).IsRequired();
                e.HasIndex(p => p.MaKho).IsUnique();
            });
        }
    }
}
