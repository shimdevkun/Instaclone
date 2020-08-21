using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instaclone.Models
{
    public class Follow
    {
        [Key]
        [Column(Order = 1)]
        public string FolloweeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FollowerId { get; set; }

        public ApplicationUser Followee { get; set; }
        public ApplicationUser Follower { get; set; }
    }
}