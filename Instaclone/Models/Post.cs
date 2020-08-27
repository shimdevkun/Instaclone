using Instaclone.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Instaclone.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [DisplayName("Image link")]
        [Required]
        [IsValidUrl(ErrorMessage = "Enter a valid image url")]
        public string ImageSrc { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}