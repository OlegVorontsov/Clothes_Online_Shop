
using Clothes_Online_Shop.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace Clothes_Online_Shop.Data
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private readonly List<Role> roles = new List<Role>()
        {
            new Role() {Name = "User"}
        };
        public void AddRole(Role role)
        {
            roles.Add(role);
        }
        public List<Role> GetAll()
        {
            return roles;
        }
        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(r => r.Name == name);
        }
        public Role GetUserRole()
        {
            return roles[0];
        }
        public void Remove(string name)
        {
            roles.RemoveAll(r => r.Name == name);
        }
    }
}
