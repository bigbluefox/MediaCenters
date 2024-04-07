using MediaCenters.Data;
using MediaCenters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCenters.Services
{

    public class BookService
    {
        private readonly MediaCenterContext _context;

        public BookService(MediaCenterContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books
                    .AsNoTracking()
                    .ToList();
        }

        public Book? GetById(int id)
        {
            return _context.Books
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public Book Create(Book newBook)
        {
            _context.Books.Add(newBook);
            _context.SaveChanges();

            return newBook;
        }

        public void UpdateSauce(int BookId, int sauceId)
        {
            var BookToUpdate = _context.Books.Find(BookId);
            //var sauceToUpdate = _context.Sauces.Find(sauceId);

            //if (BookToUpdate is null || sauceToUpdate is null)
            //{
            //    throw new InvalidOperationException("Book does not exist");
            //}

            //BookToUpdate.Sauce = sauceToUpdate;

            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var BookToDelete = _context.Books.Find(id);
            if (BookToDelete is not null)
            {
                _context.Books.Remove(BookToDelete);
                _context.SaveChanges();
            }
        }
    }
}
