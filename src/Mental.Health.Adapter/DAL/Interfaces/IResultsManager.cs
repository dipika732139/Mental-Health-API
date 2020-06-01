using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public interface IResultsManager
    {
        List<Result> GetAllResults(Test test);
        Result GetResultByScore(Test test, int score);
        bool AddResult(Test test, Result result);
        bool DeleteResult(Test test, Result result);
        bool DeleteResultByScore(Test test, int score);
        bool UpdateResult(Test test, Result result);
    }
}
