namespace QUIZ_APP.Models
{
    public interface IQuizSelect
    {
        

        List<QuizMVC> GetAll();


        void ResetAnswer();
        QuestionDetails GetQuestion(int? quiz_id, int? question_id);
    }
}
