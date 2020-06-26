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
        [HttpGet("add")]  // Just for demo purposes to run in browser.
        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions();
            options.HttpOnly = true; // Cookie will not be used by Client Side Script
            options.Secure = true; // Only transmit cookie over SSL
            options.Expires = DateTimeOffset.Now.AddDays(60);

            Response.Cookies.Append("uniqueId", "cookieValue", options);

            return Ok("Cookie created and should exist on your machine.");
        }

        [HttpGet]
        public IActionResult GetCookie()
        {
            // Retrieve value from cookie.
            string value = Request.Cookies["uniqueId"];
            return Ok($"The value is {value}.");
        }

        [HttpDelete]
        [HttpGet("delete")] // Just for demo purposes to run in browser.
        public IActionResult DeleteCookie()
        {
            Response.Cookies.Delete("uniqueId");
            return Ok("Cookie deleted from machine.");
        }
    }
}
