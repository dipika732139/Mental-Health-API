namespace Mental.Health.Service
{
    public static class ResultRequestTranslator
    {
        public static Result ToResult(this ResultRequest request, string testId)
        {
            return request == null
                ? null
                : new Result()
                {
                    UserId = request.UserId,
                    TestType = request.TestType
                };
        }
    }
}
