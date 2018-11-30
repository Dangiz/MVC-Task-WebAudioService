using System;
using System.Collections.Generic;
using System.Linq;
using WebAudioService.DataAccessContracts;
using WebAudioService.Entities;

namespace WebAudioService.ListDataAccess
{
    public class CollectionUserRoleRepo : IUserRoleDao
    {
        private static Dictionary<int,UserRole> roles=new Dictionary<int, UserRole>();

        static CollectionUserRoleRepo()
        {
            roles.Add(0,new UserRole(0, "User"));
            roles.Add(1,new UserRole(1, "Admin"));
        }

        public void Insert(UserRole role)
        {
            roles.Add(roles.Count,new UserRole(roles.Count,role.Name));
        }

        public IEnumerable<UserRole> SelectAll()
        {
            return roles.Values;
        }

        public UserRole GetRoleById(int id)
        {
            return roles[id];
        }

        public bool IsNameUnique(string name)
        {
            return SelectAll().Any(role => role.Name.Equals(name));
        }

        public UserRole GetUserRoleByName(string name)
        {
            return SelectAll().First(role => role.Name.Equals(name));
        }

        public IEnumerable<UserRole> GetRolesByUserId(int userId)
        {
            return new CollectionRoleWithUserRepo().GetRolesIdByUserId(userId).Select(id => GetRoleById(id));
        }
    }
}