using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CreateModel(ApplicationDbContext applicationDb)
        {
            _applicationDbContext = applicationDb;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            // To be valid Name must be given because in Book class it is declared 'Required'
            // So if in the create page the name is not given it won't create the book
            if (ModelState.IsValid)
            {
                await _applicationDbContext.Book.AddAsync(Book);
                await _applicationDbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
