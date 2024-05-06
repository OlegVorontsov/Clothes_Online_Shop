using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public class ChangePassword
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
