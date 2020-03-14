using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class EFDBContext : DbContext
    {
        public DbSet<Entityes.Directory> Directory { get; set; }
        public DbSet<Material> Material { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

        public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
        {
            public EFDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WorkBD;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

                return new EFDBContext(optionsBuilder.Options);
            }
        }
    }
}