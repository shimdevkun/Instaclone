using Instaclone.Models;
using Instaclone.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Instaclone.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        public ApplicationDbContext _context { get; set; }
        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult MyProfile()
        {
            var userId = User.Identity.GetUserId();
            var posts = _context.Posts
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .OrderByDescending(p => p.DateTime)
                .ToList();

            return View(posts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View(post);

            post.DateTime = DateTime.Now;

            _context.Posts.Add(post);
            _context.SaveChanges();

            TempData["Message"] = "The post was successfully created";

            return RedirectToAction("MyProfile");
        }

        public ActionResult Explore()
        {
            var posts = _context.Posts
                .Include(p => p.User)
                .OrderByDescending(p => p.DateTime)
                .ToList();

            var userId = User.Identity.GetUserId();
            var followees = _context.Follows.Where(f => f.FollowerId == userId).Select(f => f.Followee)
                .ToLookup(u => u.Id);

            var viewModel = new ExploreViewModel
            {
                Posts = posts,
                Followees = followees
            };

            return View(viewModel);
        }

        public ActionResult Feed()
        {
            var userId = User.Identity.GetUserId();
            var followeesIds = _context.Follows.Where(f => f.FollowerId == userId).Select(f => f.FolloweeId).ToList();


            var posts = _context.Posts
                .Where(p => followeesIds.Contains(p.UserId))
                .Include(p => p.User)
                .OrderByDescending(p => p.DateTime)
                .ToList();

            return View(posts);
        }

        [HttpPost]
        public ActionResult Delete(int postId)
        {
            var userId = User.Identity.GetUserId();
            var post = _context.Posts
                .SingleOrDefault(p => p.UserId == userId && p.Id == postId);

            if (post == null)
                return HttpNotFound();

            _context.Posts.Remove(post);
            _context.SaveChanges();
            TempData["Message"] = "The post was successfully deleted";

            return RedirectToAction("MyProfile");
        }

        public ActionResult Details(int postId)
        {
            var post = _context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Single(p => p.Id == postId);

            return View(post);
        }
    }
}