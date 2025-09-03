using Microsoft.AspNetCore.Mvc;
using SQL_Exo.Data;
using SQL_Exo.Models;

namespace SQL_Exo.Controllers
{
    public class PostController : Controller
    {
        private readonly MonDbContext _context;

        public PostController(MonDbContext context)
        {
            _context = context;
        }

        // GET: /Post
        public IActionResult Index()
        {
            var posts = _context.Posts.OrderByDescending(p => p.DateCreation).ToList();
            return View(posts);
        }

        // GET: /Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.DateCreation = DateTime.Now;
                if (string.IsNullOrEmpty(post.Auteur))
                {
                    post.Auteur = "Anonyme";
                }
                
                _context.Posts.Add(post);
                _context.SaveChanges();
                
                TempData["SuccessMessage"] = "Post créé avec succès !";
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: /Post/Details/5
        public IActionResult Details(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // GET: /Post/Edit/5
        public IActionResult Edit(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: /Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Post modifié avec succès !";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Une erreur s'est produite lors de la modification.");
                }
            }
            return View(post);
        }

        // POST: /Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Post supprimé avec succès !";
            return RedirectToAction(nameof(Index));
        }
    }
}