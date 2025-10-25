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
            this.qselect = quiz;
            this._logger = logger;
        }
        //***********************************************************************************
        public IActionResult Index()
        {
            return View(this.qselect.GetAll());
        }
        //***********************************************************************************
        public IActionResult Details(int? quiz_id,int? question_id=0)
        {
            QuestionDetails item = this.qselect.GetQuestion(quiz_id, question_id);

            if (item == null)
            {
                return NotFound("element found");
            }
            else
            {
                return View(item);
            }
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
