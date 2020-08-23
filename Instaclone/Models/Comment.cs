using System;
using System.ComponentModel.DataAnnotations;

namespace Instaclone.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public ApplicationUser User { get; set; }
        public Post Post { get; set; }
    }
}