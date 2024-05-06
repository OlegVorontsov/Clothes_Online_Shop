using Clothes_Online_Shop.Areas.Admin.Models;
using Clothes_Online_Shop.Models;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Data
{
    public interface IUsersManager
    {
        void AddUser(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string userName);
        void ChangePassword(string userName, string newPassword);
        public void ChangeRole(string userName, Role newRole);
        public void Update(ChangeUser changeUser);
        void Remove(string userName);
    }
}
