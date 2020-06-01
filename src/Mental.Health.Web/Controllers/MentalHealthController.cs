using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mental.Health.Service;

namespace Mental.Health.Web.Controllers
{
    [Route("api/mentalHealth")]
    [ApiController]
    public class MentalHealthController : ControllerBase
    {
        private readonly IMentalHealthService _mentalHealthService;
        public MentalHealthController()
        {
            _mentalHealthService = null;
        }
        [HttpGet("question")]
        public async Task<ActionResult> GetQuestion([FromBody] QuestionRequest request)
        {
            throw new Exception();// { ErrorCode = 12, ErrorMessage = "ABC" };
            var result = await _mentalHealthService.GetQuestion(request);
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }
        [HttpPost("answer/{testId}")]
        public async Task<ActionResult> SaveAnswer([FromBody] AnswerRequest request, string testId)
        {
            var result = await _mentalHealthService.SaveAnswer(request, testId);
            return result == null ? (ActionResult)BadRequest() : Ok(result);
        }
        [HttpGet("result/{testId}")]
        public async Task<ActionResult> GetResult([FromBody] ResultRequest request, string testId)
        {
            var result = await _mentalHealthService.GetResult(request, testId);
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }
    }
}
