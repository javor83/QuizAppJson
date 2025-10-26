using System.Text;

namespace QUIZ_APP.Models
{
    public class QuestionOptionList
    {

        //************************************************************************************
        public void ResetAnswer()
        {
            for(int i = 0;i<this.data_questions.Count;i++)
            {
                this.data_questions.ElementAt(i).ResetAnswer();
            }
        }
        //************************************************************************************
        public int CountAsCorrect()
        {
            var query = from x in this.data_questions
                        where x.CountAsCorrect() == true
                        select x;

            int result = query.Count();
            return result;
        }
        //************************************************************************************
        public int CountAsIncorrect()
        {
            int result = 0;
            if (this.CountAsCorrect() > 0)
            {
                result = 0;
            }
            else
            {
                result = 1;
            }
            return result;
        }
        //************************************************************************************
        public void SetLetter(enum_LetterOption selected)
        {
            OptionsInQuestion query = this.data_questions.Where(x => x.Letter == selected).First();
            query.Answer = true;
            query.AnswerLetter = selected;



        }
      
        //************************************************************************************
        public bool AnswerExists()
        {
            var query = this.data_questions.Any(x=>x.Answer == true);
            return query;


        }

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
