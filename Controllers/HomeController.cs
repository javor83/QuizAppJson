using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Components.RenderTree;
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
            /*
            QuizSelect dq = new QuizSelect();
            QuizMVC mvc = new QuizMVC();
            mvc.QuizIndex = dq.list.Count + 1;
            mvc.AddMVC();
            QuizMVC js = new QuizMVC();
            js.QuizIndex = dq.list.Count + 1;
            js.AddJS();

            dq.Add(mvc);dq.Add(js);

            dq.Serialize();

            var x = dq.Deserialize();

            return Json(x);
            */

            return View(this.qselect.GetAll());
        }
        //***********************************************************************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendAnswer(QuestionDetails sender)
        {
            this.qselect.SendAnswer(sender);
            if (sender.IsFinished())
            {
                return RedirectToAction("Print", "Home",new { quiz_id = sender.QuizID });
            }else

                return RedirectToAction("Details", "Home",
                    new
                    {
                        quiz_id = sender.QuizID,
                        question_id = sender.NextQuestionID
                    }
                    );

        }
        //***********************************************************************************
        public IActionResult Print(int? quiz_id)
        {
            if (quiz_id.HasValue)
            {
                QuizMVC find = this.qselect.Find(quiz_id);
                if (find != null)
                {
                    return View(find);
                }
                else
                {
                    return NotFound("not found");
                }
            }
            else
            {
                return NotFound("not found");
            }

                
        }
        //***********************************************************************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reset()
        {
            this.qselect.ResetAnswer();
            return RedirectToAction("Index", "Home");
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
