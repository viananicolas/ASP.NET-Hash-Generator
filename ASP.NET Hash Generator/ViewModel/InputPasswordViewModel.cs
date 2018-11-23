using System.ComponentModel.DataAnnotations;
using ASP.NET_Hash_Generator.Enums;

namespace ASP.NET_Hash_Generator.ViewModel
{
    public class InputPasswordViewModel
    {
        [Required]
        public HashType HashType { get; set; }
        [Required]
        public string Password { get; set; }
    }
}