using FindBeeNumbers.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace FindBeeNumbers.Core.Data
{
    public class PhoneContext : DbContext
    {
        private readonly IConfiguration _iconfiguration;

        //public BeeContext(DbContextOptions options) : base(options)
        //{
        //}

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
        }
    }
}
