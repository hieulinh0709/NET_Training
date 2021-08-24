using FindBeeNumbers.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FindBeeNumbers.Core.Data
{
    public class PhoneContext : DbContext
    {
        private readonly IConfiguration _iconfiguration;

        public PhoneContext(
            IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;

        }

        public DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_iconfiguration.GetConnectionString("DefaultDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            this.SeedData(builder);
        }

        protected void SeedData(ModelBuilder builder)
        {
            builder.Entity<Phone>().HasData(
                 new Phone() { Id = 1, Number = "0861975619", Network = "Viettel" },
                 new Phone() { Id = 2, Number = "0975375619", Network = "Viettel" },
                 new Phone() { Id = 3, Number = "0894375619", Network = "Mobi" },
                 new Phone() { Id = 4, Number = "0917775619", Network = "VinaPhone" },
                 new Phone() { Id = 5, Number = "0337578949", Network = "Viettel" }
            );
        }
    }
}
