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
    }
}
