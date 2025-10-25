using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using QUIZ_APP.Models;

namespace QUIZ_APP.Controllers
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

            QuizMVC quiz_MVC = new QuizMVC();quiz_MVC.AddMVC();
            var quiz_js = new QuizMVC();quiz_js.AddJS();
            //*********************************************************************
           

            AllQuiz t = new AllQuiz();
            quiz_MVC.QuizIndex = t.list.Count + 1;
            t.Add(quiz_MVC);
            quiz_js.QuizIndex = t.list.Count + 1;
            t.Add(quiz_js);


            t.Serialize();

            var list = t.Deserialize();

            return Json(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
