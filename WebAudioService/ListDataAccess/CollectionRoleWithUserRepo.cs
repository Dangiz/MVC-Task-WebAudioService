using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAudioService.ListDataAccess
{
    public class CollectionRoleWithUserRepo
    {
        private static List<KeyValuePair<int, int>> rolesToUser = new List<KeyValuePair<int, int>>();

        static CollectionRoleWithUserRepo()
        {
            rolesToUser.Add(new KeyValuePair<int, int>(0, 0));
            rolesToUser.Add(new KeyValuePair<int, int>(0, 1));
        }

        public void Insert(int userId,int roleId)
        {
            rolesToUser.Add(new KeyValuePair<int,int>(userId,roleId));
        }

        public void Delete(int userId,int roleId)
        {
            rolesToUser.Remove(new KeyValuePair<int, int>(userId, roleId));
        }

        public void DeleteUserRoles(int userId)
        {
            rolesToUser.RemoveAll(pair => pair.Key == userId);
        }

        public IEnumerable<int> GetRolesIdByUserId(int userId)
        {
            return rolesToUser.Where(pair => pair.Key == userId).Select(pair => pair.Value);
        }
    }
}