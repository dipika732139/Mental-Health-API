﻿namespace Mental.Health
{
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