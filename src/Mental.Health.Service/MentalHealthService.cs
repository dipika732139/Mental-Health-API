using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public class MentalHealthService : IMentalHealthService
    {
        public Task<QuestionResponse> GetQuestion(QuestionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ResultResponse> GetResult(ResultRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<AnswerResponse> SaveAnswer(AnswerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
