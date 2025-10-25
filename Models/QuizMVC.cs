using System.Text;

namespace QUIZ_APP.Models
{
    public class QuizMVC
    {
        public int QuizIndex { get; set; }
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
