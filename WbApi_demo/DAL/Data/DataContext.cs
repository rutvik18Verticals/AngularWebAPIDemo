using Azure.Core;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string ConncectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=EMS_DB;Integrated Security=True;Application Intent=ReadWrite;";
                optionsBuilder.UseSqlServer(ConncectionString);
            }
                base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            using var hmac = new HMACSHA512();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = 1,
                Username = "admin",
                Role = "admin",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin")),
                PasswordSalt = hmac.Key
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppEmployee> Employees { get; set; }
        public DbSet<AppDepartment> Departments { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppTask> Tasks { get; set; }
    }
}
