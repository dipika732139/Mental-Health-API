using System;
using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public class ResultsManager : IResultsManager
    {
        private static List<Result> _anxietyResults;
        private static List<Result> _depressionResults;
        private static List<Result> _stressResults;
        public ResultsManager()
        {
            _anxietyResults = GetResultsFromFile(KeyStore.FilePaths.Results.Anxiety);
            _depressionResults = GetResultsFromFile(KeyStore.FilePaths.Results.Depression);
            _stressResults = GetResultsFromFile(KeyStore.FilePaths.Results.Stress);
        }

        private List<Result> GetResultsFromFile(string path)
        {
            try
            {
                return JsonFileHandler.ReadFile<Result>(path);
            }
            catch
            {
                return new List<Result>();
            }
        }

        public bool AddResult(Test test, Result question)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteResult(Test test, Result question)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteResultByScore(Test test, int score)
        {
            throw new System.NotImplementedException();
        }

        public List<Result> GetAllResults(Test test)
        {
            throw new System.NotImplementedException();
        }

        public Result GetResultByScore(Test test, int score)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateResult(Test test, Result question)
        {
            throw new System.NotImplementedException();
        }
    }
}
