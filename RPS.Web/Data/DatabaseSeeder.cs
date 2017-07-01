using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RPS.Web.Models;

namespace RPS.Web.Data
{
    public static class DatabaseSeeder
    {
        private static RpsContext _context;

        public static void SeedDatabase(this IApplicationBuilder app)
        {
            _context = app.ApplicationServices.GetService<RpsContext>();

            if (!_context.Countries.Any())
            {
                SeedCountries();
            }

            if (!_context.Industries.Any())
            {
                SeedIndustries();
            }

            if (!_context.Sectors.Any())
            {
                SeedSectors();
            }

            if (!_context.Reports.Any())
            {
                SeedReports();
            }
        }
     
        private static void SeedCountries()
        {
            var countries = new List<Country>
            {
                new Country { Name = "Australia" },
                new Country { Name = "Italy" },
                new Country { Name = "Spain" },
                new Country { Name = "France" },
                new Country { Name = "Germany" },
                new Country { Name = "U.S.A" }
            };

            _context.Countries.AddRange(countries);
            _context.SaveChanges();
        }

        private static void SeedIndustries()
        {
            var industries = new List<Industry>
            {
                new Industry { Code = "AD", Name = "Alcoholic Drinks" },
                new Industry { Code = "PFOOD", Name = "Packaged Food" },
                new Industry { Code = "ELEC", Name = "Consumer Electronics" },
                new Industry { Code = "BPC", Name = "Beauty & Personal Care" },
                new Industry { Code = "CF", Name = "Consumer Finance" },
                new Industry { Code = "TRV", Name = "Travel" }
            };

            _context.Industries.AddRange(industries);
            _context.SaveChanges();
        }

        private static void SeedSectors()
        {
            var industries = _context.Industries.ToList();
            var ad = industries.First(x => x.Code == "AD");
            var pf = industries.First(x => x.Code == "PFOOD");
            var elec = industries.First(x => x.Code == "ELEC");
            var bpc = industries.First(x => x.Code == "BPC");
            var cf = industries.First(x => x.Code == "CF");
            var trv = industries.First(x => x.Code == "TRV");

            var sectors = new List<Sector>
            {
                new Sector {Industry = ad, Code = "BEER", Name = "Beer"},
                new Sector {Industry = ad, Code = "WINE", Name = "Wine"},
                new Sector {Industry = ad, Code = "SPIRITS", Name = "Spirits"},
                new Sector {Industry = pf, Code = "BAKERY", Name = "Bakery"},
                new Sector {Industry = pf, Code = "CHEESE", Name = "Cheese"},
                new Sector {Industry = elec, Code = "MP", Name = "Mobile Phones"},
                new Sector {Industry = elec, Code = "COMP", Name = "Computers and Peripherals"},
                new Sector {Industry = bpc, Code = "DEOD", Name = "Deodorants"},
                new Sector {Industry = bpc, Code = "HAIR", Name = "Hair Care"},
                new Sector {Industry = bpc, Code = "SKIN", Name = "Skin Care"},
                new Sector {Industry = cf, Code = "LENDING", Name = "Consumer Lending"},
                new Sector {Industry = cf, Code = "CARDS", Name = "Financial Cards and Payments"},
                new Sector {Industry = trv, Code = "AIRLINES", Name = "Airlines"},
                new Sector {Industry = trv, Code = "CR", Name = "Car Rental"},
            };

            _context.Sectors.AddRange(sectors);
            _context.SaveChanges();
        }

        private static void SeedReports()
        {
            var countries = _context.Countries.ToList();
            var industries = _context.Industries.ToList();
            var sectors = _context.Sectors.ToList();

            foreach (var country in countries)
            {
                foreach (var sector in sectors)
                {
                    var title = string.Format("{0} in {1}", sector.Name, country.Name);
                    var industry = industries.Single(x => x.Code.Equals(sector.Industry.Code));

                    var report = new Report
                    {
                        Industry = industry,
                        Category = ReportCategory.Sector,
                        Country = country,
                        Sector = sector,
                        Title = title
                    };

                    _context.Reports.Add(report);
                }

                foreach (var industry in industries)
                {
                    var title = string.Format("{0} in {1}", industry.Name, country.Name);
                    var report = new Report
                    {
                        Industry = industry,
                        Category = ReportCategory.Industry,
                        Country = country,
                        Title = title
                    };

                    _context.Reports.Add(report);
                }
            }

            _context.SaveChanges();
        }
    }
}
