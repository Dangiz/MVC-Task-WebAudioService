using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAudioService.DataAccessContracts;
using WebAudioService.Entities;

namespace WebAudioService.ListDataAccess
{
    public class CollectionAudioRepo : IAudioDao
    {
        private static Dictionary<int,Audio> audios = new Dictionary<int, Audio>();

        public void Insert(Audio audio)
        {
            audio.Id = audios.Count;
            audios.Add(audios.Count,audio);
        }

        public IEnumerable<Audio> SelectAll()
        {
            return audios.Values;
        }

        public Audio GetAudioById(int audioId)
        {
            return audios[audioId];
        }

        public IEnumerable<Audio> GetAudiosByUserId(int userId)
        {
            return audios.Values.Where(audio => audio.UserId == userId);
        }
        
        public bool HasAudio(int id)
        {
            return audios.ContainsKey(id);
        }

        public void DeleteById(int id)
        {
            audios.Remove(id);
        }

        public void DeleteAudiosByUserId(int userId)
        {
            foreach (Audio audio in audios.Values)
                if (audio.UserId == userId)
                    audios.Remove(audio.Id);
        }
    }
}