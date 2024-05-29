using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "название*")]
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            var role = (RoleViewModel)obj;
            return Name == role.Name;
        }
    }
}
