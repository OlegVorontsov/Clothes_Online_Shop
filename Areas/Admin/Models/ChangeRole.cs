using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public class ChangeRole
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите название прав")]
        public string RoleName { get; set; }
    }
}
