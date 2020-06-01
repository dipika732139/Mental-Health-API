using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public interface IQuestionsManager
    {
        List<QuestionModel> GetAllQuestions(Test test);
        QuestionModel GetQuestionByNumber(Test test, int number);
        bool AddQuestion(Test test, QuestionModel question);
        bool DeleteQuestion(Test test, QuestionModel question);
        bool DeleteQuestionByNumber(Test test,int number);
        bool UpdateQuestion(Test test, QuestionModel question);
    }
}
