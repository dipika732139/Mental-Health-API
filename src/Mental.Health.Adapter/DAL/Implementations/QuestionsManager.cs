using System;
using System.Collections.Generic;
using System.Linq;

namespace Mental.Health.Adapter
{
    public class QuestionsManager : IQuestionsManager
    {
        private static object _lockObj;
        private static List<QuestionModel> _anxietyQuestions;
        private static List<QuestionModel> _depressionQuestions;
        private static List<QuestionModel> _stressQuestions;
        public QuestionsManager()
        {
            _anxietyQuestions = GetQuestionsFromFile(GetPath(Test.Anxiety));
            _depressionQuestions = GetQuestionsFromFile(GetPath(Test.Depression));
            _stressQuestions = GetQuestionsFromFile(GetPath(Test.Stress));
            _lockObj = new object();
        }

        private List<QuestionModel> GetQuestionsFromFile(string path)
        {
            try
            {
                return JsonFileHandler.ReadFile<QuestionModel>(path)?? new List<QuestionModel>();
            }
            catch
            {
                return new List<QuestionModel>();
            }
        }

        public bool AddQuestion(Test test, QuestionModel question)
        {
            var existingQuestion = GetQuestionByNumber(test, question?.Number ?? -1);
            if (existingQuestion != null || string.IsNullOrEmpty(question.Question))
                return false;
            var questions = GetAllQuestions(test);
            lock (_lockObj)
            {
                questions.Add(question);
            }
            return JsonFileHandler.WriteInFile(questions, GetPath(test));
        }

        public bool DeleteQuestion(Test test, QuestionModel question)
        {
            var existingQuestion = GetQuestionByNumber(test, question?.Number ?? -1);
            if (existingQuestion == null)
                return true;
            var questions = GetAllQuestions(test);
            lock (_lockObj)
            {
                try
                {
                    questions.Remove(existingQuestion);
                }
                catch { }
            }
            return JsonFileHandler.WriteInFile(questions, GetPath(test));
        }

        public bool DeleteQuestionByNumber(Test test, int number)
        {
            var existingQuestion = GetQuestionByNumber(test, number);
            if (existingQuestion == null)
                return true;
            var questions = GetAllQuestions(test);
            lock (_lockObj)
            {
                try
                {
                    questions.Remove(existingQuestion);
                }
                catch { }
            }
            return JsonFileHandler.WriteInFile(questions, GetPath(test));
        }

        public List<QuestionModel> GetAllQuestions(Test test)
        {
            var questions = new List<QuestionModel>();
            switch (test)
            {
                case Test.Anxiety:
                    questions = _anxietyQuestions;
                    break;
                case Test.Depression:
                    questions = _depressionQuestions;
                    break;
                case Test.Stress:
                    questions = _stressQuestions;
                    break;
            }
            return questions;
        }
        private string GetPath(Test test)
        {
            var path = default(string);
            switch (test)
            {
                case Test.Anxiety:
                    path = KeyStore.FilePaths.Questions.Anxiety;
                    break;
                case Test.Depression:
                    path = KeyStore.FilePaths.Questions.Depression;
                    break;
                case Test.Stress:
                    path = KeyStore.FilePaths.Questions.Stress;
                    break;
            }
            return path;
        }
        public QuestionModel GetQuestionByNumber(Test test, int number)
        {
            var questions = GetAllQuestions(test);
            return questions.Where(question => question.Number == number).FirstOrDefault();
        }

        public bool UpdateQuestion(Test test, QuestionModel question)
        {
            lock (_lockObj)
            {
                var existingQuestion = GetQuestionByNumber(test, question?.Number ?? -1);
                if (existingQuestion == null || string.IsNullOrEmpty(question.Question))
                    return false;
                existingQuestion.Question = question.Question;
                existingQuestion.Options = question.Options;
                return JsonFileHandler.WriteInFile(GetAllQuestions(test), GetPath(test));
            }
        }
    }
}
