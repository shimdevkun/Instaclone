using Instaclone.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Instaclone.Controllers
{
    [Authorize]
    public class FollowsController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Follow(string followeeId, string actionName, int postId)
        {
            var userId = User.Identity.GetUserId();


            if (_context.Follows.Any(f => f.FollowerId == userId && f.FolloweeId == followeeId))
            {
                TempData["Message"] = "You are already following this person";
                return RedirectToAction(actionName, "Posts");
            }

            if (followeeId == userId)
            {
                TempData["Message"] = "You cannot follow yourself";
                return RedirectToAction(actionName, "Posts");
            }

            var follow = new Follow
            {
                FolloweeId = followeeId,
                FollowerId = userId
            };

            _context.Follows.Add(follow);
            _context.SaveChanges();


            TempData["Message"] = "You are now following " + _context.Users.Single(u => u.Id == followeeId).Name;
            return RedirectToAction(actionName, "Posts", new { postId = postId });
        }

        public ActionResult MyFollowees()
        {
            var userId = User.Identity.GetUserId();
            var followees = _context.Follows
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            return View(followees);
        }

        public ActionResult MyFollowers()
        {
            var userId = User.Identity.GetUserId();
            var followers = _context.Follows
                .Where(f => f.FolloweeId == userId)
                .Select(f => f.Follower)
                .ToList();

            return View(followers);
        }

        public ActionResult Unfollow(string followeeId)
        {
            var followee = _context.Users.SingleOrDefault(u => u.Id == followeeId);
            if (followee == null)
                return HttpNotFound();

            var userId = User.Identity.GetUserId();
            var followees = _context.Follows.Where(f => f.FollowerId == userId).ToList();

            var follow = followees.SingleOrDefault(f => f.FolloweeId == followeeId);
            if (follow == null)
                return HttpNotFound();

            _context.Follows.Remove(follow);
            _context.SaveChanges();

            TempData["Message"] = "You successfully unfollowed " + followee.Name;
            return RedirectToAction("MyFollowees", "Follows");
        }
    }
}