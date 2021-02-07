using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class BookRepository :IBookstoreRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                {
                    Id=1,Title="C#",Description="Programming Language",
                    Author = new Author{Id =2} 
                },

                new Book
                {
                    Id=2,Title="Sql",Description="Database Language ",Author =new Author()
                },
                new Book
                {
                    Id=3,Title="HTML",Description="Markup Language",Author =new Author()
                }
            };
        }
        public void add(Book entity)
        {
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(a => a.Id == id);
            return book;
        }

        public IList<Book> list()
        {
            return books;
        }

        public List<Book> Search(string term)
        {
            return books.Where(a => a.Title.Contains(term)).ToList();
        }

        public void Update(int id, Book newBook)
        {
            var book = Find(id);
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
            
        }
    }
}
