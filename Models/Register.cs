using Clothes_Online_Shop.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public class Register
    {
        [Required(ErrorMessage = "e-mail*")]
        [EmailAddress(ErrorMessage = "Введите корректный e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "телефон*")]
        [Phone(ErrorMessage = "Введите корректный телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "пароль*")]
        public string Password { get; set; }

        [Required(ErrorMessage = "подтвердите пароль*")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public Role Role { get; set; }
    }
}
