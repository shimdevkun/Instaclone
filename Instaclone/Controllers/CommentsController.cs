using Instaclone.Models;
using Instaclone.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Instaclone.Controllers
{
    public class CommentsController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public CommentsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            CardBodyViewModel vm = new CardBodyViewModel
            {
                Post = _context.Posts
                    .Include(p => p.User)
                    .Single(p => p.Id == comment.PostId),
                Comment = comment
            };

            if (!ModelState.IsValid)
                return View("Comment", vm);

            comment.DateTime = DateTime.Now;

            _context.Comments.Add(comment);
            _context.SaveChanges();

            TempData["Message"] = "Comment was posted successfully";

            return RedirectToAction("Explore", "Posts");
        }

        public ActionResult Comment(CardBodyViewModel cardBodyVM)
        {
            return View(cardBodyVM);
        }
    }
}