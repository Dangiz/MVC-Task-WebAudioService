using System.Collections.Generic;
using WebAudioService.Entities;

namespace WebAudioService.Models
{
    public class UserWithAudios
    {
        public string Name { get; set; }
        public IEnumerable<AudioWithUsername> Audios { get; set; }
    }
}