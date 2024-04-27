using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public class Role
    {
        [Required(ErrorMessage = "название*")]
        public string Name { get; set; }
    }
}
