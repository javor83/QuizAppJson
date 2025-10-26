using Microsoft.AspNetCore.Mvc;
using QUIZ_APP.Models;

namespace QUIZ_APP.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly IQuizSelect qselect = null;
        //***********************************************************************************
        public HomeController(IQuizSelect quiz)
        {
            this.qselect = quiz;
            
        }
        //***********************************************************************************
        #region get query
        //***********************************************************************************
        public IActionResult Index()
        {
            
            //този код служи за генериране на нов файс въпроси
            /*
            QuizSelect dq = new QuizSelect();
            QuizMVC mvc = new QuizMVC();
           
            mvc.AddMVC();
            QuizMVC js = new QuizMVC();
           
            js.AddJS();

            dq.Add(mvc);dq.Add(js);

            dq.Serialize();

            var x = dq.Deserialize();

            return Json(x);
            */

            return View(this.qselect.GetAll());
        }
        //***********************************************************************************
        public IActionResult Details(int? quiz_id, int? question_id = 0)
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
        #endregion
        //***********************************************************************************

        #region post query
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reset()
        {
            this.qselect.ResetAnswer();
          
            return RedirectToAction("Index", "Home");
        }
        #endregion
        //***********************************************************************************
    }
}
