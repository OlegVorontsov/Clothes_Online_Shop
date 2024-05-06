
using Clothes_Online_Shop.Areas.Admin.Models;

namespace Clothes_Online_Shop.Models
{
    public class UserAccount
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
