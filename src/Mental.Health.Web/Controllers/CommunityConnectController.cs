using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mental.Health.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mental.Health.Web.Controllers
{
    [Route("api/connectpeople")]
    [ApiController]
    public class CommunityConnectController : ControllerBase
    {

        private readonly ICommunityConnectService _communityConnectService;
        public CommunityConnectController(ICommunityConnectService communityConnectService)
        {
            _communityConnectService = communityConnectService;
        }
        
        [HttpGet("ConnectIn5kmRange")]
        public async Task<ActionResult> GetUsersWithin5kmRange([FromBody] CommunityConnectRequest request)
        {
            var result = await _communityConnectService.ConnectPeoplewithin5Km(request);
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }
        [HttpGet("ConnectIn10kmRange")]
        public async Task<ActionResult> GetUsersWithin10kmRange([FromBody] CommunityConnectRequest request)
        {
            var result = await _communityConnectService.ConnectPeoplewithin10Km(request);
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }
        [HttpGet("ConnectIn20kmRange")]
        public async Task<ActionResult> GetUsersWithin20kmRange([FromBody] CommunityConnectRequest request)
        {
            var result = await _communityConnectService.ConnectPeoplewithin20Km(request);
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }
        [HttpGet("ConnectIn30kmRange")]
        public async Task<ActionResult> GetUsersWithin30kmRange([FromBody] CommunityConnectRequest request)
        {
            var result = await _communityConnectService.ConnectPeoplewithin30Km(request);
            return result == null ? (ActionResult)NotFound() : Ok(result);
        }
    }
}
