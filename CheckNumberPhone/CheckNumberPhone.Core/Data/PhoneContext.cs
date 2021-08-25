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
                 new Phone() { Id = 5, Number = "0337578966", Network = "Viettel" },
                 new Phone() { Id = 6, Number = "0881775727", Network = "VietNamMobile" },
                 new Phone() { Id = 7, Number = "0894378337", Network = "Mobi" },
                 new Phone() { Id = 8, Number = "0894378904", Network = "" },
                 new Phone() { Id = 9, Number = "0894378904" },
                 new Phone() { Id = 10 },
                 new Phone() { Id = 11, Number = "abcdefgh", Network = "Mobi" }
            );
        }
    }
}
