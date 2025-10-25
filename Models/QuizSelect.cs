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
        #region privates
        //**************************************************************************************
        private QuizMVC Find(int? id)
        {
            QuizMVC result = null;

            if (id.HasValue)
            {
                if (id.Value >= 0 && id.Value <= this.list.Count() - 1)
                {
                    result = this.list.ElementAt(id.Value);
                }
                else
                    result = null;
            }
            else
            {
                result = null;
            }


            return result;
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
        #endregion
        //**************************************************************************************
        QuestionDetails IQuizSelect.GetQuestion(int? quiz_id, int? question_id)
        {
            QuestionDetails result = null;
            QuizMVC quiz = this.Find(quiz_id);
            if (quiz != null)
            {
                var question = quiz.Find(question_id);
                if (question != null)
                {
                    int total = quiz.quiz_questions.Count();
                    result = new QuestionDetails()
                    {
                        CurrentQuestion = question,
                        TotalCount = total,
                        IndexOnScreen = question_id.Value + 1
                    };
                }
                else
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

        List<QuizMVC> IQuizSelect.GetAll()
        {
            return this.list;
        }
        //**************************************************************************************

    }
}
