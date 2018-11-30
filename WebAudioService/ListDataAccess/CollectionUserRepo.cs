using System;
using System.Collections.Generic;
using System.Linq;
using WebAudioService.DataAccessContracts;
using WebAudioService.Entities;

namespace WebAudioService.ListDataAccess
{
    public class CollectionUserRepo:IUserDao
    {
        private static Dictionary<int,User> users= new Dictionary<int,User>();

        static CollectionUserRepo()
        {
            users.Add(0,new User(0, "User1", "Password"));
            users.Add(1, new User(1, "User2", "Password"));
        }

        public User GetUserById(int id)
        {
            return users[id];
        }

        public void Insert(User user)
        {
            user.Id = users.Count;
            users.Add(users.Count,user);
            new CollectionRoleWithUserRepo().Insert(user.Id, 0);
        }

        public IEnumerable<User> SelectAll()
        {
            return users.Values;
        }

        public User GetUserByName(string name)
        {
            return users.Values.First(user => user.Name.Equals(name));
        }

        public bool IsNameUnique(string name)
        {
            return !users.Values.Any(user => user.Name.Equals(name));
        }

        public bool UserHasRole(int userId,int roleId)
        {
            return new CollectionRoleWithUserRepo().GetRolesIdByUserId(userId).Contains(roleId);
        }

        public bool HasUser(int id)
        {
            return users.ContainsKey(id);
        }

        public void DeleteById(int id)
        {
            IAudioDao audios = new CollectionAudioRepo();
            audios.DeleteAudiosByUserId(id);
            var roles = new CollectionRoleWithUserRepo();
            roles.DeleteUserRoles(id);
            users.Remove(id);
        }
    }
}