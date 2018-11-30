

namespace WebAudioService.Entities
{
    public class Audio
    {
        public Audio(byte[] data, string name, string contentType)
        {
            Data = data;
            Name = name;
            ContentType = contentType;
        }

        public Audio(int userId, byte[] data, string name, string contentType)
        {
            UserId = userId;
            Data = data;
            Name = name;
            ContentType = contentType;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
    }
}