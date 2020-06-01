﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health
{
    public interface IMentalHealthComponent
    {
        Task<Question> GetQuestion(Question question);
        Task<bool> SaveResponse(Answer answer);
        Task<Result> GetResult(Result result);
    }
}
