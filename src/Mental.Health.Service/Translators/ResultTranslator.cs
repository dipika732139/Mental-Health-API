namespace Mental.Health.Service
{
    public static class ResultTranslator
    {
        public static ResultResponse ToResultResponse(this Result result)
        {
            return result == null
                ? null
                : new ResultResponse()
                {
                    MoodImageUrl = result.MoodImageUrl,
                    Score = result.Score,
                    Description = result.Description,
                    Summary = result.Summary
                };
        }
    }
}
