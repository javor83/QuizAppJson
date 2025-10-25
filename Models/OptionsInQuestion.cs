namespace QUIZ_APP.Models
{
    public class OptionsInQuestion
    {
        public void ResetAnswer()
        {
            this.Answer = false;
            this.AnswerLetter = enum_LetterOption.A;
        }
        
        public bool Answer { get; set; } = false;
        //************************************************************************************
        public enum_LetterOption AnswerLetter { get; set; } = enum_LetterOption.A;
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
            if (this.Correct)
            {
                return $"{this.Letter.ToString()}. {this.QuestionText} (X)";
            }
            else
            {
                return $"{this.Letter.ToString()}. {this.QuestionText} (-)";
            }


        }
        //************************************************************************************

    }
}
