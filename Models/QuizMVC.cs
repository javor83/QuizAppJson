using System.Text;

namespace QUIZ_APP.Models
{
    public class QuizMVC
    {

        //************************************************************************************
        public IEnumerable<OptionsInQuestion> CountCorrect()
        {
            var result = 
                this.quiz_questions.SelectMany(x => x.data_questions);
            return result;
        }
        //************************************************************************************
        public void AddMVC()
        {


            this.QuizTitle = "Quiz MVC";

            this.Add
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
            this.Add
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
            this.Add
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

            this.Add
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
            this.Add
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
        }
        //************************************************************************************
        public void AddJS()
        {


            this.QuizTitle = "Quiz JS";

            this.Add
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
            this.Add
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
        }


        //************************************************************************************
        public string QuizTitle { get; set; }
        //************************************************************************************
        public int QuizIndex { get; set; }
        //************************************************************************************
        public QuestionOptionList Find(int? id)
        {
            QuestionOptionList result = null;

            if (id.HasValue)
            {
                if (id.Value >= 0 && id.Value <= quiz_questions.Count() - 1)
                {
                    result = quiz_questions.ElementAt(id.Value);
                }
                else
                {
                    result = null;
                }
            }
            else
            {
                result = null;
            }

            return result;
        }
        //************************************************************************************
        public List<QuestionOptionList> quiz_questions { get; set; } = new List<QuestionOptionList>();
        //************************************************************************************
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (QuestionOptionList k in this.quiz_questions)
            {
                sb.Append(k.ToString()).AppendLine();
            }
            return sb.ToString();
        }
        //************************************************************************************
        public void ResetAnswer()
        {
            for (int i = 0; i < this.quiz_questions.Count; i++)
            {
                this.quiz_questions.ElementAt(i).ResetAnswer();
            }
        }
        //************************************************************************************

        public void Add
            (
                string caption,
                params OptionsInQuestion[] list
            )
        {
            var qlist = new QuestionOptionList()
            {
                HeaderText = caption,
                HeaderIndex = this.quiz_questions.Count + 1

            };
            foreach (var question in list)
            {
                qlist.AddOption(question);
            }
            quiz_questions.Add(qlist);
        }
        //************************************************************************************

    }
}
