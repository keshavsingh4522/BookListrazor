using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListrazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListrazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book book { get; set; }
        public async void OnGet(int id)
        {
            book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var temp = await _db.Book.FindAsync(book.Id);
                temp.Name = book.Name;
                temp.Author = book.Author;
                temp.ISBN = book.ISBN;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
