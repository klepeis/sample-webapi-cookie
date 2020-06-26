using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieController : ControllerBase
    {
        [HttpPost]
        [HttpGet("add")]
        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions();
            options.HttpOnly = true;
            options.Secure = true;
            options.Expires = DateTimeOffset.Now.AddDays(60);

            Response.Cookies.Append("uniqueId", "cookieValue", options);

            return Ok("Cookie Value Set");
        }

        [HttpGet]
        public IActionResult GetCookie()
        {
            string value = Request.Cookies["uniqueId"];
            return Ok($"The value is {value}.");
        }

        [HttpDelete]
        [HttpGet("delete")]
        public IActionResult DeleteCookie()
        {
            Response.Cookies.Delete("uniqueId");
            return Ok("Cookie Deleted");
        }
    }
}
