using System.Collections.Generic;
using WebAudioService.Entities;
namespace WebAudioService.DataAccessContracts
{
    interface IAudioDao
    {
        void Insert(Audio audio);
        IEnumerable<Audio> SelectAll();
        Audio GetAudioById(int audioId);
        IEnumerable<Audio> GetAudiosByUserId(int userId);
        bool HasAudio(int id);
        void DeleteById(int id);
        void DeleteAudiosByUserId(int userId);
    }
}
