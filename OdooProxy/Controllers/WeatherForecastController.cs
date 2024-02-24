using Microsoft.AspNetCore.Mvc;

namespace OdooProxy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // Constructor and any other necessary properties or methods can remain or be adjusted according to your needs.

        // This method responds to GET requests made to the endpoint
        [HttpGet("lol")]
        public IActionResult GetLol()
        {
            return Ok("lol"); // Returns the string "poop"
        }

        // You can comment out or remove the previous LoginAsync method if it's no longer needed
        /*
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            // Login logic was here
        }
        */

        // Any other code related to the class (if necessary)
    }

    // LoginRequest class can also be commented out or removed if it's no longer necessary
    /*
    public class LoginRequest
    {
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    */
}
