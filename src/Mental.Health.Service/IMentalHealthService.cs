namespace Mental.Health.Service
{
    public interface IMentalHealthService
    {
        QuestionResponse GetQuestion(QuestionRequest request);
        AnswerResponse SaveAnswer(AnswerRequest request);
        ResultResponse GetResult(ResultRequest request);
    }
}
