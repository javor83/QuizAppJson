namespace QUIZ_APP.Models
{
    public class QuestionDetails
    {
        public QuestionOptionList CurrentQuestion { get; set; }
        public int TotalCount { get; set; }

        public int IndexOnScreen { get; set; }
    }
}
