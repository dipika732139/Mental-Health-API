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
    [Route("[api]")]
    public class MentalHealthController : ControllerBase
    {
        private readonly IMentalHealthService _mentalHealthService;
        public MentalHealthController(IMentalHealthService mentalHealthService)
        {
            _mentalHealthService = mentalHealthService;
        }

    }
}
