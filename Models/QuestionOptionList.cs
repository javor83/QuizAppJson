using System.Text;

namespace QUIZ_APP.Models
{
    public class QuestionOptionList
    {
        //************************************************************************************
        //възможни отговори...
        public List<OptionsInQuestion> data_questions { get; set; } = new List<OptionsInQuestion>();
        //************************************************************************************
        public int HeaderIndex { get; set; } = 1;
        //************************************************************************************

        public string HeaderText { get; set; } = "your question...";
        //************************************************************************************
        public QuestionOptionList()
        {

        }
        //************************************************************************************

        public void AddOption(OptionsInQuestion sender)
        {
            this.data_questions.Add(sender);
        }
        //************************************************************************************

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.HeaderIndex}. {this.HeaderText}").AppendLine();
            foreach (OptionsInQuestion k in this.data_questions)
            {
                sb.Append(k.ToString()).AppendLine();
            }
            return sb.ToString();
        }
        //************************************************************************************


    }
}
