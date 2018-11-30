using System.Collections.Generic;
using WebAudioService.Entities;

namespace WebAudioService.DataAccessContracts
{
    interface IUserDao
    {
        void Insert(User user);
        IEnumerable<User> SelectAll(); 
        User GetUserById(int id);
        User GetUserByName(string name);
        bool IsNameUnique(string name);
        bool UserHasRole(int userId, int roleId);
        bool HasUser(int id);
        void DeleteById(int id);
    }
}
