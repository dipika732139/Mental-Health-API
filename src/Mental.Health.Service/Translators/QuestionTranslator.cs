namespace Mental.Health.Service
{
    public static class QuestionTranslator
    {
        public static QuestionResponse ToQuestionResponse(this Question question)
        {
            return question == null
                ? null
                : new QuestionResponse()
                {
                    Question = question.QuestionData,
                    Options = question.Options.ToOptionsContract()
                };
        }
    }
}
