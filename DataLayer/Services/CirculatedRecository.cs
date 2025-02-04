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
    public class CirculatedRecository : ICirculatedRecository
    {
        private library_management_systemDB db;

        public CirculatedRecository(library_management_systemDB db)
        {
            this.db = db;
        }

        public IEnumerable<Circulated> GetAllCirculated()
        {
            return db.T_Circulated;
        }

        public IEnumerable<CirculatedViewModel1> GetAllCirculatedWithMemberNumber(int membernumber)
        {
            return db.T_Circulated.Where(x => x.MemberNumber == membernumber).Select(x => new CirculatedViewModel1
            {
                CirculatedID = x.CirculatedID,
                BorrowDate = x.BorrowDate,
                CopyNumber = x.CopyNumber,
                DueDate = x.DueDate,
                MemberNumber = x.MemberNumber,
                ReturnDate = x.ReturnDate,
                 FineAmount = x.FineAmount,
            });
          
        }

        public Circulated GetCirculatedById(int circulatedid)
        {
            return db.T_Circulated.Find(circulatedid);
        }

        public bool DeleteCirculated(Circulated circulated)
        {
            try
            {
                db.Entry(circulated).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCirculated(int circulatedid)
        {
            try
            {
                var circulated = GetCirculatedById(circulatedid);
                DeleteCirculated(circulated);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool InsertCirculated(Circulated circulated)
        {
            try
            {
                db.T_Circulated.Add(circulated);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCirculated(Circulated circulated)
        {
            db.Entry(circulated).State = EntityState.Modified;
            return true;

        }

    }
}
