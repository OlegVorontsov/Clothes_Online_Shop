using System.Collections.Generic;

namespace Clothes_Online_Shop.Areas.Admin.Models
{
    public class ChangeRoleViewModel
    {
        public string UserName { get; set; }
        public List<RoleViewModel> Roles { get; set; }
        public List<RoleViewModel> AllRoles { get; set; }
    }
}
