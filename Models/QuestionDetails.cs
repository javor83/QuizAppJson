using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text;

namespace QUIZ_APP.Models
{
    public class QuestionDetails
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"TotalCount {this.TotalCount}").AppendLine();
            sb.Append($"IndexOnScreen {this.IndexOnScreen}").AppendLine();
            sb.Append($"QuizTitle {this.QuizTitle}").AppendLine();
            sb.Append($"QuizID {this.QuizID}").AppendLine();
            sb.Append($"QuestionID {this.QuestionID}").AppendLine();
            sb.Append($"NextQuestionID {this.NextQuestionID}").AppendLine();
            sb.Append($"PreviousQuestionID {this.PreviousQuestionID}").AppendLine();
            sb.Append($"CurrentQuestion {this.CurrentQuestion.ToString()}").AppendLine();
            return sb.ToString();
        }

     

        public QuestionOptionList CurrentQuestion { get; set; }
        public int TotalCount { get; set; }

        public int IndexOnScreen { get; set; }

        public string QuizTitle { get; set; }

        public int QuizID { get; set; }

        public int QuestionID { get; set; }


        public int NextQuestionID { get; set; }
        public int PreviousQuestionID { get; set; }

        public enum_LetterOption SelectedLetter { get; set; }
    }
}
