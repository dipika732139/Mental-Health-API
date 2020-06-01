using System.Collections.Generic;
using System.Linq;

namespace Mental.Health.Adapter
{
    public class UserReportsManager : IUserReportsManager
    {
        private static List<UserReport> _userReports;
        public UserReportsManager()
        {
            try
            {
                _userReports = JsonFileHandler.ReadFile<UserReport>(KeyStore.FilePaths.UserReports);
            }
            catch
            {
                _userReports = new List<UserReport>();
            }
        }
        public bool AddUserTestResultToReport(string userId, Test test, TestResult result)
        {
            if (string.IsNullOrEmpty(userId))
                return false;
            var userReport = GetUserReportByUserId(userId);
            switch (test)
            {
                case Test.Anxiety:
                    userReport.AnxietyReport.Add(result);
                    break;
                case Test.Depression:
                    userReport.DepressionReport.Add(result);
                    break;
                case Test.Stress:
                    userReport.StressReport.Add(result);
                    break;
            }
            return JsonFileHandler.WriteInFile(_userReports, KeyStore.FilePaths.UserReports);
        }

        public bool CleanAllTestResultsByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return false;
            var userReport = GetUserReportByUserId(userId);
            userReport.AnxietyReport = new List<TestResult>();
            userReport.DepressionReport = new List<TestResult>();
            userReport.StressReport = new List<TestResult>();
            return JsonFileHandler.WriteInFile(_userReports, KeyStore.FilePaths.UserReports);
        }

        public bool CleanTestResults(string userId, Test test)
        {
            if (string.IsNullOrEmpty(userId))
                return false;
            var userReport = GetUserReportByUserId(userId);
            switch (test)
            {
                case Test.Anxiety:
                    userReport.AnxietyReport = new List<TestResult>();
                    break;
                case Test.Depression:
                    userReport.DepressionReport = new List<TestResult>();
                    break;
                case Test.Stress:
                    userReport.StressReport = new List<TestResult>();
                    break;
            }
            return JsonFileHandler.WriteInFile(_userReports, KeyStore.FilePaths.UserReports);
        }

        public bool CreateNewUserReportByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId) || GetUserReportByUserId(userId) != null)
                return false;
            _userReports.Add(new UserReport()
                                    {
                                        UserId = userId,
                                        AnxietyReport = new List<TestResult>(),
                                        DepressionReport = new List<TestResult>(),
                                        StressReport = new List<TestResult>()
                                    });
            return JsonFileHandler.WriteInFile(_userReports, KeyStore.FilePaths.UserReports);
        }

        public bool DeleteUserReportByUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return false;
            var userReport = GetUserReportByUserId(userId);
            if (userReport == null)
                return true;
            _userReports.Remove(userReport);
            return JsonFileHandler.WriteInFile(_userReports, KeyStore.FilePaths.UserReports);
        }

        public UserReport GetUserReportByUserId(string userId) => string.IsNullOrEmpty(userId) ?
                                                                    null
                                                                    : _userReports.Where(userReport => string.Equals(userId, userReport.UserId)).FirstOrDefault();

    }
}
