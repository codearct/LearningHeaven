using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookRepository
    {
        public List<Book> GetAll()
        {
            using (BookMarketDbContext context =new BookMarketDbContext())
            {
                var books =context.Books.ToList();
                return books;
            }
        }
        public Book GetById(int id)
        {
            using (BookMarketDbContext context = new BookMarketDbContext())
            {
                var book = context.Books.SingleOrDefault(b => b.Id == id);
                return book;
            }
        }
        public void Add(Book book)
        {
            using (BookMarketDbContext context = new BookMarketDbContext())
            {
                var addedBook = context.Books.Add(book);
                context.SaveChanges();
            }
        }
        public void Update(Book book)
        {
            using (BookMarketDbContext context = new BookMarketDbContext())
            {
                var updatedBook = context.Books.SingleOrDefault(b=>b.Id==book.Id);
                updatedBook.Title = book.Title;
                updatedBook.ModifiedTime = DateTime.Now;
            }
        }
    }
}
