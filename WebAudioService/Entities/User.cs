using System.ComponentModel.DataAnnotations;

namespace WebAudioService.Entities
{
    public class User
    {

        public User(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public User()
        {
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Password { get; set; }
    }
}