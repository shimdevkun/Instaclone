using Instaclone.Models;
using System.Collections.Generic;
using System.Linq;

namespace Instaclone.ViewModels
{
    public class ExploreViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public ILookup<string, ApplicationUser> Followees { get; set; }
    }
}