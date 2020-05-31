using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mental.Health.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mental.Health.Web.Controllers
{
    [ApiController]
    [Route("api/mentalHealth")]
    public class MentalHealthController : ControllerBase
    {
        private readonly IMentalHealthService _mentalHealthService;
        public MentalHealthController(IMentalHealthService mentalHealthService)
        {
            _mentalHealthService = mentalHealthService;
        }
        [HttpGet("question")]
        public async Task<ActionResult> GetQuestion([FromBody] QuestionRequest request)
        {
            var result = await _mentalHealthService.GetQuestion(request);
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }
        [HttpPost("answer")]
        public async Task<ActionResult> SaveAnswer([FromBody] AnswerRequest request)
        {
            var result = await _mentalHealthService.SaveAnswer(request);
            return result == null ? (ActionResult)BadRequest() : Ok(result);
        }
        [HttpGet("result")]
        public async Task<ActionResult> GetResult([FromBody] ResultRequest request)
        {
            var result = await _mentalHealthService.GetResult(request);
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }
    }
}
