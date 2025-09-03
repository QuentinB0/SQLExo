using Microsoft.AspNetCore.Mvc;
using SQL_Exo.Data;
using SQL_Exo.Models;
using System.Linq;

namespace SQL_Exo.Controllers
{
    public class CommentairesController : Controller
    {
        private readonly MonDbContext _context;

        public CommentairesController(MonDbContext context)
        {
            _context = context;
        }

        // Exemple : /Commentaires/ByPost/5
        public IActionResult ByPost(int postId)
        {
            var commentaires = _context.Commentaires
                .Where(c => c.PostId == postId)
                .OrderBy(c => c.DateCreation)
                .ToList();

            return View(commentaires);
        }
    }
}