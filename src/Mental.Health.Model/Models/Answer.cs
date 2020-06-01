namespace Mental.Health
{
    public class Answer
    {
        public string UserId { get; set; }
        public string MentalHealthTestId { get; set; }
        public string TestId { get; set; }
        public int QuestionNumber { get; set; }
        public int ChosenOption { get; set; }
    }
}
