using System.Diagnostics.Contracts;

namespace QUIZ_APP.Models
{
    public class QuestionDetails
    {
        public QuestionOptionList CurrentQuestion { get; set; }
        public int TotalCount { get; set; }

        public int IndexOnScreen { get; set; }

        public string QuizTitle { get; set; }

        public int QuizID { get; set; }

        public int QuestionID { get; set; }


        public int NextQuestionID { get; set; }
        public int PreviousQuestionID { get; set; }
    }
}
