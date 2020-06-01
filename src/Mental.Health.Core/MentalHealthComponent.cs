using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Core
{
    public class MentalHealthComponent : IMentalHealthComponent
    {
        public Task<Question> GetQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetResult(Result result)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveResponse(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
