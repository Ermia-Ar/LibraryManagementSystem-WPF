using DataLayer.Models;
using ViewModels.BookView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBook();

        IEnumerable<BookViewModel1> GetBookModel1();

        Book GetBookById(int booknumber);

        bool InsertBook(Book book);

        bool UpdateBook(Book book);

        bool DeleteBook(Book book);

        bool DeleteBook(int booknumber);

    }
}
