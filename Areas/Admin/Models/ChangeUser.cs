using Clothes_Online_Shop.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public class ChangeUser
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите e-mail")]
        [EmailAddress(ErrorMessage = "Введите корректный e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите телефон")]
        [Phone(ErrorMessage = "Введите корректный телефон")]
        public string Phone { get; set; }
    }
}
