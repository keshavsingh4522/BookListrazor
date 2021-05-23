using BookListrazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListrazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data= await _db.Book.ToListAsync()});
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var temp = await _db.Book.FirstOrDefaultAsync(u=>u.Id==id);
            if(temp==null)
            {
                return Json(new { success=false , message="Error while Deleting" });
            }
            _db.Book.Remove(temp);
            await _db.SaveChangesAsync();
            return Json(new { success=true , message="Delete Successfull"});
        }
    }
}
