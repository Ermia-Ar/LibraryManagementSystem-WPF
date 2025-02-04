using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.BookView;

namespace DataLayer.Repository
{
    public interface ICopyRepository
    {
        IEnumerable<Copy> GetAllCopy();

        IEnumerable<CopyViewModel1> GetCopyModel1();

        Copy GetCopyById(int copynumber);

        bool InsertCopy(Copy copy);

        bool UpdateCopy(Copy copy);

        bool DeleteCopy(Copy copy);

        bool DeleteCopy(int copynumber);
    }
}
