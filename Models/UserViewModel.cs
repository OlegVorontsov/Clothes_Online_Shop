using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IList<IdentityRole> Roles { get; set; }
    }
}
