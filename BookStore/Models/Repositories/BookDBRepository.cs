using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class BookDBRepository : IBookstoreRepository<Book>
    {
        BookstoreDbContext db;
        public BookDBRepository(BookstoreDbContext _db)
        {
            db = _db;

        }
        public void add(Book entity)
        {
            db.Books.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public Book Find(int id)
        {
            var bbook = db.Books.SingleOrDefault(a => a.Id == id);
            return bbook;
        }

        public IList<Book> list()
        {
            return db.Books.Include(a => a.Author).ToList();
        }

        public List<Book> Search(string term)
        {
            var result= db.Books.Include(a => a.Author)
                   .Where(b => b.Title.Contains(term)
                   || b.Description.Contains(term)
                   || b.Author.FullName.Contains(term)).ToList();
            return result;


        }

        public void Update(int id, Book newBook)
        {
            db.Update(newBook);
            db.SaveChanges();

        }
    }
}
