using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public interface IMentalHealthService
    {
        Task<QuestionResponse> GetQuestion(QuestionRequest request,string testId);
        Task<AnswerResponse> SaveAnswer(AnswerRequest request,string testid);
        Task<ResultResponse> GetResult(ResultRequest request,string testId);
    }
}
