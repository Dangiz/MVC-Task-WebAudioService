using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAudioService.Entities;

namespace WebAudioService.Models
{
    public class AudioWithUsername
    {
        public AudioWithUsername()
        {
            
        }

        public AudioWithUsername(string username,int userId, int id, string contentType)
        {
            Username = username;
            Id = id;
            ContentType = contentType;
            UserId = userId;
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }
        public string ContentType { get; set; }
    }
}