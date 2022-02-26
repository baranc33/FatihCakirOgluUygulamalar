using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetContentAsync()
        {
            // verilen linkteki bilgileri getirir
            var myTask = new HttpClient().GetStringAsync("https://www.google.com");


            var data = await myTask;

            return Ok(data);
        }
    }
}
