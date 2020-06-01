using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public class MentalHealthService : IMentalHealthService
    {
        private readonly IMentalHealthController _mentalHealthController;
        public MentalHealthService(IMentalHealthController mentalHealthController)
        {
            _mentalHealthController = mentalHealthController;
        }
        public async Task<QuestionResponse> GetQuestion(QuestionRequest request)
        {
            //validate request
            var question = await _mentalHealthController.GetQuestion(request.ToQuestion());
            return question.ToQuestionResponse();
        }

        public async Task<ResultResponse> GetResult(ResultRequest request, string testId)
        {
            //validate request
            var result = await _mentalHealthController.GetResult(request.ToResult(testId));
            return result.ToResultResponse();
        }

        public async Task<AnswerResponse> SaveAnswer(AnswerRequest request, string testId)
        {
            //validate request
            if (await _mentalHealthController.SaveResponse(request.ToAnswer(testId)))
                return new AnswerResponse() { IsSubmissionSuccessful = true };
            return new AnswerResponse() { IsSubmissionSuccessful = false };
        }
    }
}
