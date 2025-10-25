namespace QUIZ_APP.Models
{
    public interface IQuizSelect
    {
        

        List<QuizMVC> GetAll();



        QuestionDetails GetQuestion(int? quiz_id, int? question_id);
    }
}
