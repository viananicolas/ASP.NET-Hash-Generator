using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Hash_Generator.ViewModel
{
    public class InputPasswordViewModel
    {
        [Required]
        public string Password { get; set; }
    }
}