using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public interface IMentalHealthService
    {
        Task<QuestionResponse> GetQuestion(QuestionRequest request);
        Task<AnswerResponse> SaveAnswer(AnswerRequest request);
        Task<ResultResponse> GetResult(ResultRequest request);
    }
}
