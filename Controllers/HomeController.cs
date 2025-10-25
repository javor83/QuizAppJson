using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using QUIZ_APP.Models;

namespace QUIZ_APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQuizSelect qselect = null;
        //***********************************************************************************
        public HomeController(ILogger<HomeController> logger,IQuizSelect quiz)
        {
            this.qselect = qselect;
            this._logger = logger;
        }
        //***********************************************************************************
        public IActionResult Index()
        {
            return Json(new { id = 1,ok = true});
        }
        //***********************************************************************************
        public IActionResult Privacy()
        {
            return View();
        }
        //***********************************************************************************
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //***********************************************************************************
    }
}
