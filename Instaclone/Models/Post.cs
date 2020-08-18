using System;

namespace Instaclone.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ImageSrc { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }


        public ApplicationUser User { get; set; }
    }
}