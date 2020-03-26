using aspnetcore_serilog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace aspnetcore_serilog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("o codigo está funcionando corretamente. Melhor codigo ever");
            return View();
        }

        public IActionResult Privacy()
        {
            try
            {
                throw new ArgumentException("argumento errado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError("o codigo esta bugado. pior codigo ever", e);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
