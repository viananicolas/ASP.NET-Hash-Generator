using System;
using System.IO;
using ASP.NET_Hash_Generator.Enums;
using ASP.NET_Hash_Generator.Methods;
using ASP.NET_Hash_Generator.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Hash_Generator.Controllers
{
    [Produces("application/json"), Route("api/home"), ApiController]
    public class HomeController : ControllerBase
    {
        private IHostingEnvironment HostingEnv { get; set; }

        public HomeController(IHostingEnvironment hostingEnv)
        {
            HostingEnv = hostingEnv;
        }
        [HttpPost]
        public IActionResult Post([FromBody] InputPasswordViewModel inputPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                switch (inputPasswordViewModel.HashType)
                {
                    case HashType.ASPNETCORE:
                        {
                            var passwordHasher = new PasswordHasher<string>();
                            return Ok(new { hashedPassword = passwordHasher.HashPassword("", inputPasswordViewModel.Password) });
                        }
                    case HashType.ASPNETMVC:
                        {
                            return Ok(new { hashedPassword = PasswordHasher.HashPassword(inputPasswordViewModel.Password) });
                        }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return BadRequest();
        }
    }
}