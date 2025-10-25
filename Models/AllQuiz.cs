using System.Text.Json;

namespace QUIZ_APP.Models
{
    public class AllQuiz
    {
        public string save_as = "quiz.json";
        //**************************************************************************************
        public List<QuizMVC> list { get; set; } = new List<QuizMVC>();
        //**************************************************************************************
        public void Add(QuizMVC sender)
        {
            this.list.Add(sender);
        }
        //**************************************************************************************
        public void Serialize()
        {
            string x = JsonSerializer.Serialize<List<QuizMVC>>(this.list);
            File.WriteAllText($"./{save_as}", x);
        }
        //**************************************************************************************
        public List<QuizMVC> Deserialize()
        {
            string read_all = File.ReadAllText($"./{save_as}");
            List<QuizMVC>? result = JsonSerializer.Deserialize<List<QuizMVC>>(read_all);
            return result;
        }
        //**************************************************************************************

    }
}
