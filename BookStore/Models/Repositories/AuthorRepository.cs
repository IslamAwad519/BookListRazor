using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {
          IList<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
            {

               new Author { Id = 1, FullName = "Khaled Ali" },
               new Author { Id = 2, FullName = "Hamzem Hamzem " },
               new Author { Id = 3, FullName = "Ahmed Islam" }
            };
            
        }
        public void add(Author entity)
        {
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(b => b.Id == id);
            return author;
        }

        public IList<Author> list()
        {
            return authors;
        }

        public List<Author> Search(string term)
        {
            return authors.Where(a => a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);
            author.FullName = newAuthor.FullName;
            
        }
    }
}
