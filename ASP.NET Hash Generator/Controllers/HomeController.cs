using System;
using ASP.NET_Hash_Generator.Enums;
using ASP.NET_Hash_Generator.Methods;
using ASP.NET_Hash_Generator.ViewModel;
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
            if (!ModelState.IsValid) return BadRequest();
            switch (inputPasswordViewModel.HashType)
            {
                case HashType.ASPNETCORE:
                    return Ok(new
                    {
                        hashedPassword =
                            new PasswordHasher<string>().HashPassword(string.Empty, inputPasswordViewModel.Password)
                    });
                case HashType.ASPNETMVC:
                    return Ok(new {hashedPassword = PasswordHasher.HashPassword(inputPasswordViewModel.Password)});
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}