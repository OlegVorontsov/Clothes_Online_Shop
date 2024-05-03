
using Clothes_Online_Shop.Areas.Admin.Models;
using System.Collections.Generic;


namespace Clothes_Online_Shop.Data
{
    public interface IRolesRepository
    {
        void AddRole(Role role);
        List<Role> GetAll();
        Role TryGetByName(string name);
        void Remove(string name);
    }
}
