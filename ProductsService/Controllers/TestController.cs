using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProductsOrdersService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("value")]
        [Authorize]
        public string GetValue()
        {
            var claimes = this.HttpContext.User.Claims;
            return $"Hello {claimes.First().Value}";
        }
    }
}
