using BookStore.Models;
using BookStore.Models.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookstoreRepository<Book> bookRepository;
        private readonly IBookstoreRepository<Author> authorRepository;
        //private readonly IHostingEnvironment hosting;

        public BookController(IBookstoreRepository<Book> bookRepository ,IBookstoreRepository<Author> authorRepository)
          
        {
           this.bookRepository = bookRepository;
               this.authorRepository = authorRepository;
        //    this.hosting = hosting;
        }
        // GET: BookController1
        public ActionResult Index()
        {
            var books = bookRepository.list();
            return View(books);
        }

        // GET: BookController1/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // GET: BookController1/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModel()
            {
                Authors = FillSelectList()
            };

            return View(model);
        }

        // POST: BookController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model)
        { 
            if(ModelState.IsValid)
            {
                try
                {
                    //if(model.File != null)
                    //{




                    //}
                    if(model.AuthorId == -1)
                    {
                        ViewBag.Message = "Plase Select An Auhtor from List";
                        var vmodel = new BookAuthorViewModel()
                        {
                            Authors = FillSelectList()
                        };

                        return View(vmodel);
                    }

                    var author = authorRepository.Find(model.AuthorId);
                    Book book = new Book
                    {
                        Id = model.BookId,
                        Title = model.Title,
                        Description = model.Description,
                        Author = author

                    };
                    bookRepository.add(book);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "Yuo Must Fill all Fieds");
            return View();
           
        }

        // GET: BookController1/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            //ViewBag.Authors = authorRepository.list();
            //var authorId = book.Author == null ? book.Author.Id = 0 : book.Author.Id;
            var viewModel = new BookAuthorViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Description = book.Description,
                Authors = authorRepository.list().ToList(),


        };
            return View(viewModel);
        }

        // POST: BookController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( BookAuthorViewModel viewModel)
        {
            try
            {
                var author = authorRepository.Find(viewModel.AuthorId);
                Book book = new Book
                {
                    Id = viewModel.BookId,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Author = author

                };
                bookRepository.Update(viewModel.BookId, book);

                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }

        // GET: BookController1/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // POST: BookController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Route("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                bookRepository.Delete(id);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Author> FillSelectList()
        {
            var authors = authorRepository.list().ToList();
            authors.Insert(0, new Author { Id = -1, FullName = "------Please Select an Author ------" });
            return authors;
        }
        public ActionResult Search(string term)
        {
            var result = bookRepository.Search(term);
            return View("Index", result);
        }
    }
}
