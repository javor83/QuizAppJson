namespace QUIZ_APP.Models
{
    public class OptionsInQuestion
    {

        public bool MatchAnswerLetter()
        {
            bool result = false;
            if (this.Answer)
            {
                //трябва да е изпратен отговор
                result = this.Letter == this.AnswerLetter && this.Correct == false;
            }
            return result;
        }
        //************************************************************************************
        public void ResetAnswer()
        {
            this.Answer = false;
            this.AnswerLetter = enum_LetterOption.None;
        }
        //************************************************************************************
        public bool CountAsCorrect()
        {
            bool result = false;

            if (this.Answer)
            {
                //трябва да е изпратен отговор
                result = this.Correct && this.AnswerLetter == this.Letter;

            }

            return result;
        }
        //************************************************************************************

        public bool Answer { get; set; } = false;
        //************************************************************************************
        public enum_LetterOption AnswerLetter { get; set; } = enum_LetterOption.None;
        //************************************************************************************
        //под каква буква се показва
        public enum_LetterOption Letter { get; set; }
        //************************************************************************************
        //текста на въпроса
        public string QuestionText { get; set; }
        //************************************************************************************
        //дали е верен
        public bool Correct { get; set; }
       
        //************************************************************************************

        public override string ToString()
        {
            string answer_as = $"Answered {this.Answer} | Asnwer letter {this.AnswerLetter}";
            

            if (this.Correct)
            {
                return $"{this.Letter.ToString()}. {this.QuestionText} (X) | {answer_as}";
            }
            else
            {
                return $"{this.Letter.ToString()}. {this.QuestionText} (-) | {answer_as}";
            }


        }
        //************************************************************************************

    }
}
