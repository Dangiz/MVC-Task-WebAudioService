
using WebAudioService.DataAccessContracts;
using WebAudioService.ListDataAccess;

namespace WebAudioService.Services
{
    public class UserRoleService
    {
        private static IUserDao users = new CollectionUserRepo();
        private static IUserRoleDao roles = new CollectionUserRoleRepo();

        public static bool UserHasRole(string userName,string roleName)
        {
            var user = users.GetUserByName(userName);
            var adminRole = roles.GetUserRoleByName("Admin");
            return users.UserHasRole(user.Id, adminRole.Id);
        }
        public static bool UserHasRole(int userId, string roleName)
        {
            var adminRole = roles.GetUserRoleByName("Admin");
            return users.UserHasRole(userId, adminRole.Id);
        }
    }
}