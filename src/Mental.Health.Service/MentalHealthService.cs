using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public class MentalHealthService : IMentalHealthService
    {
        public Task<QuestionResponse> GetQuestion(QuestionRequest request, string testId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultResponse> GetResult(ResultRequest request, string testId)
        {
            throw new NotImplementedException();
        }

        public Task<AnswerResponse> SaveAnswer(AnswerRequest request, string testId)
        {
            throw new NotImplementedException();
        }
    }
}
