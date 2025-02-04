using DataLayer.context;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.BookView;

namespace DataLayer.Services
{
    public class CopyRipository : ICopyRepository
    {
        private library_management_systemDB db;

        public CopyRipository(library_management_systemDB db)
        {
            this.db = db;
        }

        public IEnumerable<Copy> GetAllCopy()
        {
            return db.T_Copy;
        }

        public Copy GetCopyById(int copynumber)
        {
            return db.T_Copy.Find(copynumber);
        }

        public bool DeleteCopy(Copy copy)
        {
            try
            {
                db.Entry(copy).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCopy(int copynumber)
        {
            try
            {
                var copy = GetCopyById(copynumber);
                DeleteCopy(copy);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool InsertCopy(Copy copy)
        {
            try
            {
                db.T_Copy.Add(copy);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCopy(Copy copy)
        {
            var local = db.Set<Copy>().Local.FirstOrDefault(x => x.CopyNumber == copy.CopyNumber);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(copy).State = EntityState.Modified;
            return true;

        }

        public IEnumerable<CopyViewModel1> GetCopyModel1()
        {
            return db.T_Copy.Select(x => new CopyViewModel1 { CopyNumber = x.CopyNumber  , BookNumber = x.BookNumber, SequenceNumber = x.SequenceNumber, Type = (TypeN)x.Type , Price = x.Price });
        }


    }
}
