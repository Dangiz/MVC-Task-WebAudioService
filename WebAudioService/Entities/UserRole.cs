

namespace WebAudioService.Entities
{
    public class UserRole
    {
        public UserRole(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id {get; set;}
        public string Name { get; set; }
    }
}