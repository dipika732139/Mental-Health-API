using System;
using System.Collections.Generic;
using System.Linq;

namespace Mental.Health.Adapter
{
    public class ResultsManager : IResultsManager
    {
        private static object _lockObj;
        private static List<Result> _anxietyResults;
        private static List<Result> _depressionResults;
        private static List<Result> _stressResults;
        public ResultsManager()
        {
            _anxietyResults = GetResultsFromFile(GetPath(TestType.Anxiety));
            _depressionResults = GetResultsFromFile(GetPath(TestType.Depression));
            _stressResults = GetResultsFromFile(GetPath(TestType.Stress));
            _lockObj = new object();
        }

        public bool AddResult(TestType test, Result result)
        {
            if (result?.Score == null || result?.Summary == null)
                return false;
            var results = GetAllResults(test);
            var filePath = GetPath(test);
            var existingResult = results.Where(r => r.Score == result.Score).FirstOrDefault();
            if (existingResult != null)
                return false;
            lock (_lockObj)
            {
                results.Add(result);
            }
            return JsonFileHandler.WriteInFile(results, filePath);
        }

        private string GetPath(TestType test)
        {
            var path = default(string);
            switch (test)
            {
                case TestType.Anxiety:
                    path = KeyStore.FilePaths.Results.Anxiety;
                    break;
                case TestType.Depression:
                    path = KeyStore.FilePaths.Results.Depression;
                    break;
                case TestType.Stress:
                    path = KeyStore.FilePaths.Results.Stress;
                    break;
            }
            return path;
        }

        public bool DeleteResult(TestType test, Result result)
        {
            if (result?.Score == null || result?.Summary == null)
                return false;
            var results = GetAllResults(test);
            var filePath = GetPath(test);
            var existingResult = results.Where(r => r.Score == result.Score).FirstOrDefault();
            if (existingResult == null)
                return true;
            lock (_lockObj)
            {
                try
                {
                    results.Remove(existingResult);
                }
                catch { }
            }
            return JsonFileHandler.WriteInFile(results, filePath);
        }

        public bool DeleteResultByScore(TestType test, int score)
        {
            var results = GetAllResults(test);
            var filePath = GetPath(test);
            var existingResult = results.Where(r => r.Score == score).FirstOrDefault();
            if (existingResult == null)
                return true;
            lock (_lockObj)
            {
                try
                {
                    results.Remove(existingResult);
                }
                catch { }
            }
            return JsonFileHandler.WriteInFile(results, filePath);
        }

        public List<Result> GetAllResults(TestType test)
        {
            var results = new List<Result>();
            switch (test)
            {
                case TestType.Anxiety:
                    results = _anxietyResults;
                    break;
                case TestType.Depression:
                    results = _depressionResults;
                    break;
                case TestType.Stress:
                    results = _stressResults;
                    break;
            }
            return results;
        }

        public Result GetResultByScore(TestType test, int score)
        {
            var results = GetAllResults(test);
            var filePath = GetPath(test);
            var existingResult = results.Where(r => r.Score == score).FirstOrDefault();
            return existingResult;
        }

        public bool UpdateResult(TestType test, Result result)
        {
            if (result?.Score == null || result?.Summary == null)
                return false;
            var results = GetAllResults(test);
            var filePath = GetPath(test);
            lock (_lockObj)
            {
                var existingResult = results.Where(r => r.Score == result.Score).FirstOrDefault();
                if (existingResult == null)
                    return AddResult(test, result);
                else
                {
                    existingResult.ImageUrl = result.ImageUrl;
                    existingResult.Description = result.Description;
                    existingResult.Summary = result.Summary;
                    return JsonFileHandler.WriteInFile(results, filePath);
                }
            }
        }

        private List<Result> GetResultsFromFile(string path)
        {
            try
            {
                return JsonFileHandler.ReadFile<Result>(path) ?? new List<Result>();
            }
            catch
            {
                return new List<Result>();
            }
        }

       
    }
}
