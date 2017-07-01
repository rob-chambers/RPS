using Microsoft.EntityFrameworkCore;

namespace RPS.Web.Models
{
    public interface IRpsContext
    {
        DbSet<Country> Countries { get; set; }
        DbSet<Industry> Industries { get; set; }
        DbSet<Sector> Sectors { get; set; }
        DbSet<Report> Reports { get; set; }
    }
}
