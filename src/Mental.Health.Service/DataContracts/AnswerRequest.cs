namespace Mental.Health.Service
{
    public class AnswerRequest
	{
		public string UserId { get; set; }
		public string TestIdentifier { get; set; }
		public int QuestionNumber { get; set; }
		public int OptionNumber { get; set; }
	}
}
