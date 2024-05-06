using Clothes_Online_Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Clothes_Online_Shop.Data
{
    public interface IUsersManager
    {
        void AddUser(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string userName);
    }
}
