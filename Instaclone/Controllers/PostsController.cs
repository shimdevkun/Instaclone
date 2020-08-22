using Instaclone.Models;
using Instaclone.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Instaclone.Controllers
{
    public class PostsController : Controller
    {
        public ApplicationDbContext _context { get; set; }
        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            var userId = User.Identity.GetUserId();
            var posts = _context.Posts
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToList();

            return View(posts);
        }

        
        [Authorize]
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
            post.UserId = User.Identity.GetUserId();


            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Explore()
        {
            var posts = _context.Posts
                .Include(p => p.User)
                .ToList()
                .OrderByDescending(p => p.DateTime);

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

        [Authorize]
        public ActionResult Feed()
        {
            var userId = User.Identity.GetUserId();
            var followeesIds = _context.Follows.Where(f => f.FollowerId == userId).Select(f => f.FolloweeId).ToList();


            var posts = _context.Posts
                .Where(p => followeesIds.Contains(p.UserId))
                .Include(p => p.User)
                .ToList()
                .OrderByDescending(p => p.DateTime);

            return View(posts);
        }
    }
}