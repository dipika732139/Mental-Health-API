using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public interface IResultsManager
    {
        List<Result> GetAllResults(TestType test);
        Result GetResultByScore(TestType test, int score);
        bool AddResult(TestType test, Result result);
        bool DeleteResult(TestType test, Result result);
        bool DeleteResultByScore(TestType test, int score);
        bool UpdateResult(TestType test, Result result);
    }
}
