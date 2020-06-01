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
}
