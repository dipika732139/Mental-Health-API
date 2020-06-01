using System;
using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public class QuestionsManager : IQuestionsManager
    {
        private static List<Question> _anxietyQuestions;
        private static List<Question> _depressionQuestions;
        private static List<Question> _stressQuestions;
        public QuestionsManager()
        {
            _anxietyQuestions = GetQuestionsFromFile(KeyStore.FilePaths.Questions.Anxiety);
            _depressionQuestions = GetQuestionsFromFile(KeyStore.FilePaths.Questions.Depression);
            _stressQuestions = GetQuestionsFromFile(KeyStore.FilePaths.Questions.Stress);
        }

        private List<Question> GetQuestionsFromFile(string path)
        {
            try
            {
                return JsonFileHandler.ReadFile<Question>(path);
            }
            catch
            {
                return new List<Question>();
            }
        }

        public bool AddQuestion(Test test, QuestionModel question)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteQuestion(Test test, QuestionModel question)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteQuestionByNumber(Test test, int number)
        {
            throw new System.NotImplementedException();
        }

        public List<QuestionModel> GetAllQuestions(Test test)
        {
            throw new System.NotImplementedException();
        }

        public QuestionModel GetQuestionByNumber(Test test, int number)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateQuestion(Test test, QuestionModel question)
        {
            throw new System.NotImplementedException();
        }
    }
}
