using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Hash_Generator.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Hash_Generator.Controllers
{
    [Produces("application/json"), Route("api/home"), ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] InputPasswordViewModel inputPasswordViewModel)
        {
            var passwordHasher = new PasswordHasher<string>();
            return Ok(new { hashedPassword  = passwordHasher.HashPassword("", inputPasswordViewModel.Password) });
        }
    }
}