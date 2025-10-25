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

            QuizMVC quiz_MVC = new QuizMVC()
            {
                QuizTitle = "Quiz MVC"
            };
            quiz_MVC.Add
                (
                    "Which annotation is used to define a controller in Spring MVC?",
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.A,
                        QuestionText = "@Component",
                        Correct = true
                    },
                      new OptionsInQuestion()
                      {
                          Letter = enum_LetterOption.B,
                          QuestionText = "@Controller",
                          Correct = false
                      },
                        new OptionsInQuestion()
                        {
                            Letter = enum_LetterOption.C,
                            QuestionText = "@RestService",
                            Correct = false
                        },
                         new OptionsInQuestion()
                         {
                             Letter = enum_LetterOption.D,
                             QuestionText = "@MVCController",
                             Correct = false
                         }

                );
            quiz_MVC.Add
                (
                    "Which method in a controller returns a View in ASP.NET Core MVC?",
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.A,
                        Correct = true,
                        QuestionText = "Display",
                    },
                     new OptionsInQuestion()
                     {
                         Letter = enum_LetterOption.B,
                         Correct = false,
                         QuestionText = "Show",
                     },
                      new OptionsInQuestion()
                      {
                          Letter = enum_LetterOption.C,
                          Correct = false,
                          QuestionText = "View",
                      },
                       new OptionsInQuestion()
                       {
                           Letter = enum_LetterOption.D,
                           Correct = false,
                           QuestionText = "Render",
                       }
                );
            quiz_MVC.Add
                (
                    "Which method is used to define a GET route in Express?",
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.A,
                        Correct = true,
                        QuestionText = "app.route()"
                    },
                     new OptionsInQuestion()
                     {
                         Letter = enum_LetterOption.B,
                         Correct = false,
                         QuestionText = "app.get()"
                     },
                      new OptionsInQuestion()
                      {
                          Letter = enum_LetterOption.C,
                          Correct = false,
                          QuestionText = "express.get()"
                      },
                       new OptionsInQuestion()
                       {
                           Letter = enum_LetterOption.D,
                           Correct = false,
                           QuestionText = "router.create()"
                       }

                );

            quiz_MVC.Add
                (
                    "In MVC architecture, what does the 'C' stand for?",
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.A,
                        Correct = true,
                        QuestionText = "Code",
                    },
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.B,
                        Correct = false,
                        QuestionText = "Controller",
                    },
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.C,
                        Correct = false,
                        QuestionText = "Class",
                    },
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.D,
                        Correct = false,
                        QuestionText = "Content",
                    }

                );
            quiz_MVC.Add
                (
                    "Which part of MVC is responsible for handling user input?",
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.A,
                        Correct = true,
                        QuestionText = "Model",
                    },
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.B,
                        Correct = false,
                        QuestionText = "View",
                    },
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.C,
                        Correct = false,
                        QuestionText = "Controller",
                    },
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.D,
                        Correct = false,
                        QuestionText = "Template",
                    }

                );
            //*********************************************************************
            var quiz_js = new QuizMVC()
            {
                QuizTitle = "Quiz JS"
            };
            quiz_js.Add
                (
                    "Do you have any plans to add design Pattern , Context concept",
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.A,
                        QuestionText = "yes",
                        Correct = true
                    },
                      new OptionsInQuestion()
                      {
                          Letter = enum_LetterOption.B,
                          QuestionText = "No",
                          Correct = false
                      },
                        new OptionsInQuestion()
                        {
                            Letter = enum_LetterOption.C,
                            QuestionText = "maybe",
                            Correct = false
                        },
                         new OptionsInQuestion()
                         {
                             Letter = enum_LetterOption.D,
                             QuestionText = ":)",
                             Correct = false
                         }

                );
            quiz_js.Add
                (
                    "w3schools is...",
                    new OptionsInQuestion()
                    {
                        Letter = enum_LetterOption.A,
                        Correct = true,
                        QuestionText = "+++ learn by writing code",
                    },
                     new OptionsInQuestion()
                     {
                         Letter = enum_LetterOption.B,
                         Correct = false,
                         QuestionText = "- outdated",
                     },
                      new OptionsInQuestion()
                      {
                          Letter = enum_LetterOption.C,
                          Correct = false,
                          QuestionText = "- not comprehensive",
                      },
                       new OptionsInQuestion()
                       {
                           Letter = enum_LetterOption.D,
                           Correct = false,
                           QuestionText = "- not very good explaining async fundamentals",
                       }
                );

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
