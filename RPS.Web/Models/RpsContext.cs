using Microsoft.EntityFrameworkCore;

namespace RPS.Web.Models
{
    public sealed class RpsContext : DbContext, IRpsContext
    {
        private static bool _created;

        public RpsContext(DbContextOptions options) : base(options)
        {
            if (_created) return;

            Database.EnsureCreated();
            _created = true;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
