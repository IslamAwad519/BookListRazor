using BookStore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }
        [Required]
        [StringLength(50,MinimumLength =5)]
        public string Title { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public List<Author> Authors { get; set; }
        //public IFormFile File { get; set; }
    }
}
