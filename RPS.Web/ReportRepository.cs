using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RPS.Web.Models;

namespace RPS.Web
{
    public class ReportRepository : EfRepository<Report>, IReportRepository
    {
        public ReportRepository(IRpsContext context) : base(context)
        {            
        }

        public IList<Report> GetAll()
        {
            return Context.Reports
                .Include(r => r.Country)
                .Include(r => r.Industry)
                .Include(r => r.Sector)
                .OrderBy(r => r.Title)
                .ToList();
        }
    }

    public abstract class EfRepository<T> where T : class
    {
        protected EfRepository(IRpsContext context)
        {
            Context = context;
        }

        protected IRpsContext Context { get; }
    }

    public interface IReportRepository
    {
        IList<Report> GetAll();
    }
}
