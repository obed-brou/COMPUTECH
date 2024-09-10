using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using COMPUTECH.Data;
using COMPUTECH.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COMPUTECH.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BlogPost> BlogPosts { get; set; }

        public async Task OnGetAsync()
        {
            BlogPosts = await _context.BlogPosts.ToListAsync();
        }
    }
}
