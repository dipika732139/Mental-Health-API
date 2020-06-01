namespace Mental.Health.Service
{
    public static class AnswerRequestTranslator
    {
        public static Answer ToAnswer(this AnswerRequest request, string testId)
        {
            return request == null
                ? null
                : new Answer()
                {
                    MentalHealthTestId = request.MentalHealthTestId,
                    UserId = request.UserId,
                    TestId=testId,
                    QuestionNumber = request.QuestionNumber,
                    ChosenOption = request.OptionNumber
                };
        }
    }
}
