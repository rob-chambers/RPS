using Microsoft.AspNetCore.Mvc;

namespace RPS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReportRepository _reportRepository;

        public HomeController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public IActionResult Index()
        {
            var reports = _reportRepository.GetAll();

            return View(reports);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
