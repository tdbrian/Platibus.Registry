using Microsoft.AspNetCore.Mvc;

namespace Platibus.Registry.Web.Controllers
{
    [Route("api/v1")]
    public class HealthCheckController : ControllerBase
    {
        public HealthCheckController()
        {
            
        }

        [HttpGet("_health")]
        public string Get()
        {
            return "This app is up";
        }
    }
}
