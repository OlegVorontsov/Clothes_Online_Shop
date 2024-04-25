using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Введите e-mail")]
        [EmailAddress(ErrorMessage = "Введите корректный e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
