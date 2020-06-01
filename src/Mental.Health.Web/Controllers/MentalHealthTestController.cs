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
    public class MentalHealthTestController : ControllerBase
    {
        private readonly IMentalHealthTestService _mentalHealthService;
        public MentalHealthTestController(IMentalHealthTestService mentalHealthService)
        {
            _mentalHealthService = mentalHealthService;
        }
        [HttpGet("question")]
        public async Task<ActionResult> GetQuestion([FromBody] QuestionRequest request)
        {
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
