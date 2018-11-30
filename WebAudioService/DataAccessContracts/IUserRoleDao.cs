using System.Collections.Generic;
using WebAudioService.Entities;


namespace WebAudioService.DataAccessContracts
{
    interface IUserRoleDao
    {
        void Insert(UserRole role);
        IEnumerable<UserRole> SelectAll();
        UserRole GetRoleById(int id);
        IEnumerable<UserRole> GetRolesByUserId(int userId);
        bool IsNameUnique(string name);
        UserRole GetUserRoleByName(string name);
    }
}

