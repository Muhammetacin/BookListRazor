using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IndexModel(ApplicationDbContext dbContext)
        {
            _applicationDbContext = dbContext;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _applicationDbContext.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _applicationDbContext.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _applicationDbContext.Book.Remove(book);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
