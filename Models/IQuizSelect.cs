namespace QUIZ_APP.Models
{
    public interface IQuizSelect
    {
        QuizMVC GetIndex(int? id);

        List<QuizMVC> GetAll();
    }
}
