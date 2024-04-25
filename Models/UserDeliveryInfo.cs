

using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите e-mail")]
        [EmailAddress(ErrorMessage = "Введите корректный e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите телефон")]
        public string Phone { get; set; }
    }
}
