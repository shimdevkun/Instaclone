using Instaclone.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Instaclone.Controllers
{
    public class FollowsController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Follow(string followeeId)
        {
            var userId = User.Identity.GetUserId();


            if (_context.Follows.Any(f => f.FollowerId == userId && f.FolloweeId == followeeId))
            {
                TempData["Message"] = "You are already following this person";
                return RedirectToAction("Explore", "Posts");
            }

            if (followeeId == userId)
            {
                TempData["Message"] = "You cannot follow yourself";
                return RedirectToAction("Explore", "Posts");
            }

            var follow = new Follow
            {
                FolloweeId = followeeId,
                FollowerId = userId
            };

            _context.Follows.Add(follow);
            _context.SaveChanges();


            TempData["Message"] = "You are now following " + _context.Users.Single(u => u.Id == followeeId).Name;
            return RedirectToAction("Explore", "Posts");
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
    }
}