using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListrazor.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="book name is required")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Author name is required")]
        public string Author { get; set; }
        //[Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }
    }
}
