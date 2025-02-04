using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using ViewModels.BookView;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.context;

namespace DataLayer.Services
{
    public class BookRepository : IBookRepository
    {
        private library_management_systemDB db;

        public BookRepository(library_management_systemDB db)
        {
            this.db = db;
        }

        public IEnumerable<Book> GetAllBook()
        {
            return db.T_Book.ToList();
        }

        public Book GetBookById(int booknumber)
        {
            return db.T_Book.Find(booknumber);
        }

        public bool DeleteBook(Book book)
        {
            try
            {
                db.Entry(book).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBook(int booknumber)
        {
            try
            {
                var book = GetBookById(booknumber);
                DeleteBook(book);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool InsertBook(Book book)
        {
            try
            {
                db.T_Book.Add(book);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            return true;

        }

        public IEnumerable<BookViewModel1> GetBookModel1()
        {
            return db.T_Book.Select(x => new BookViewModel1 { BookNumber = x.BookNumber , Title = x.Title , Author =x.Author , Publisher =x.Publisher});
        }

       
    }
}
