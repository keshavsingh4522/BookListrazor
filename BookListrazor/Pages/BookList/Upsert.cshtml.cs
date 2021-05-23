using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListrazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListrazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            book = new Book();

            // create
            if (id == null)
                return Page();
            
            //update
            //book = await _db.Book.FindAsync(id);
            book = await _db.Book.FirstOrDefaultAsync(u=>u.Id==id);
            if (book == null)
                return NotFound();
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (book.Id == 0)
                {
                    await _db.Book.AddAsync(book);
                }
                else
                {
                    _db.Book.Update(book);
                }
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
