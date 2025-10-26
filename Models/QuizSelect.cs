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
            
            
            List<QuizMVC> json = this.Deserialize();
           


            this.list = new List<QuizMVC>();
            this.list.AddRange(json);
            
            
        }
        #region privates
       
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
        #endregion
        

        //**************************************************************************************
        QuizMVC IQuizSelect.Find(int? id)
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
        void IQuizSelect.SendAnswer(QuestionDetails sender)
        {
            

            QuizMVC mvc = this.list.ElementAt(sender.QuizID);
            QuestionOptionList item = mvc.quiz_questions.ElementAt(sender.QuestionID);
            item.SetLetter(sender.SelectedLetter);

           
        }

        //**************************************************************************************
        void IQuizSelect.ResetAnswer()
        {
            for(int i = 0;i<this.list.Count;i++)
            {
                this.list.ElementAt(i).ResetAnswer();
                this.list.ElementAt(i).Shuffle();
            }
           
        }

        //**************************************************************************************
        QuestionDetails IQuizSelect.GetQuestion(int? quiz_id, int? question_id)
        {
            QuestionDetails result = null;
            QuizMVC quiz = (this as IQuizSelect).Find(quiz_id);
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
                        IndexOnScreen = question_id.Value + 1,
                        //------------------
                        QuestionID = question_id.Value,
                        //------------------
                        QuizID = quiz_id.Value,
                        QuizTitle = quiz.QuizTitle,
                        SelectedLetter = question.data_questions.Last().Letter
                    };
                    if (result.QuestionID == total-1)
                    {
                        result.NextQuestionID = total - 1;//адресираме последния елемент
                        
                    }
                    else
                    {
                        result.NextQuestionID = result.QuestionID + 1;
                        
                    }
                    if (result.QuestionID == 0)
                    {
                        result.PreviousQuestionID = 0;
                    }
                    else
                    {
                        result.PreviousQuestionID = result.QuestionID - 1;
                    }
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
