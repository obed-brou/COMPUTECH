using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using COMPUTECH.Data;
using COMPUTECH.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace COMPUTECH.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public BlogPost BlogPost { get; set; }
        public IList<Comment> Comments { get; set; }

        [BindProperty]
        public Comment NewComment { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            BlogPost = await _context.BlogPosts.FindAsync(id);
            Comments = await _context.Comments.Where(c => c.BlogPostId == id).ToListAsync();

            if (BlogPost == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            BlogPost = await _context.BlogPosts.FindAsync(id);
            if (BlogPost == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            NewComment.BlogPostId = id;
            NewComment.DatePosted = DateTime.Now;

            _context.Comments.Add(NewComment);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { id });
        }
    }
}
