using System;
using System.Collections.Generic;
using System.Text;

namespace Mental.Health
{
    public class Question
    {
        public string MentalHealthTestId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionData { get; set; }
        public List<Option> Options { get; set; }
    }
    public class Answer
    {
        public string UserId { get; set; }
        public string MentalHealthTestId { get; set; }
        public string TestId { get; set; }
        public int QuestionNumber { get; set; }
        public int ChosenOption { get; set; }
    }
    public class Result
    {
        public string UserId { get; set; }
        public string MentalHealthTestId { get; set; }
        public string TestId { get; set; }
        public string MoodImageUrl { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
    }
}
