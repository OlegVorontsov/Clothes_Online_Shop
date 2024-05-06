using Clothes_Online_Shop.Areas.Admin.Models;
using Clothes_Online_Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Clothes_Online_Shop.Data
{
    public class UsersManager : IUsersManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();
        public List<UserAccount> GetAll()
        {
            return users;
        }
        public void AddUser(UserAccount user)
        {
            users.Add(user);
        }
        public UserAccount TryGetByName(string userName)
        {
            return users.FirstOrDefault(u => u.Name == userName);
        }
        public void ChangePassword(string userName, string newPassword)
        {
            var account = TryGetByName(userName);
            account.Password = newPassword;
        }
        public void ChangeRole(string userName, Role newRole)
        {
            var account = TryGetByName(userName);
            account.Role = newRole;
        }
        public void Remove(string userName)
        {
            users.RemoveAll(u => u.Name == userName);
        }
    }
}
