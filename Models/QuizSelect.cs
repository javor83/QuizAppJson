using System.Text.Json;

namespace QUIZ_APP.Models
{
    public class QuizSelect: IQuizSelect
    {
        public string save_as = "quiz.json";
        //**************************************************************************************
        public List<QuizMVC> list { get; set; } = new List<QuizMVC>();
        //**************************************************************************************
        public QuizSelect()
        {
            this.list = new List<QuizMVC>();
            var json = this.Deserialize();
            this.list.AddRange(json);
            
        }

        //**************************************************************************************
        private void Add(QuizMVC sender)
        {
            this.list.Add(sender);
        }
        //**************************************************************************************
        private void Serialize()
        {
            string x = JsonSerializer.Serialize<List<QuizMVC>>(this.list);
            File.WriteAllText($"./{save_as}", x);
        }
        //**************************************************************************************
        private List<QuizMVC> Deserialize()
        {
            string read_all = File.ReadAllText($"./{save_as}");
            List<QuizMVC>? result = JsonSerializer.Deserialize<List<QuizMVC>>(read_all);
            return result;
        }
        //**************************************************************************************

        List<QuizMVC> IQuizSelect.GetAll()
        {
            return this.list;
        }

        //**************************************************************************************
        QuizMVC IQuizSelect.GetIndex(int? id)
        {
            QuizMVC result = null;

            if (id.HasValue)
            {
                if (id >= 0 && id <= this.list.Count - 1)
                {
                    result = this.list.ElementAt(id.Value);
                }else
                {
                    result = null;
                }
            }
            else
            {
                result = null;
            }

            return result;
        }

        //**************************************************************************************

    }
}
