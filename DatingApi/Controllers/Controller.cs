using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<Controller> _logger;

        public TestController(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [HttpGet("Test")]
        public string Get()
        {
            return "Test";
        }
    }
}
