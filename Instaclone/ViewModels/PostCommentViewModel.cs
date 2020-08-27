using Instaclone.Models;
using System.Linq;

namespace Instaclone.ViewModels
{
    public class PostCommentViewModel
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        public ILookup<string, ApplicationUser> CurrentUserFollowees { get; set; }
    }
}