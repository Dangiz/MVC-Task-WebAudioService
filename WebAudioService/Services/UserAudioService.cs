using WebAudioService.DataAccessContracts;
using WebAudioService.ListDataAccess;

namespace WebAudioService.Services
{
    public class UserAudioService
    {
        private static IAudioDao audios=new CollectionAudioRepo();
        private static IUserDao users = new CollectionUserRepo();
        public static bool UserHasAudio(string username,int audioId)
        {
            return audios.GetAudioById(audioId).UserId == users.GetUserByName(username).Id;
        }
    }
}