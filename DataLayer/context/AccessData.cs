using DataLayer.Models;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.context
{
    public class AccessData :IDisposable
    {
        private library_management_systemDB _db  = new library_management_systemDB();


        private BookRepository _bookRipository;

        public BookRepository BookRipository
        {
            get
            {
                if (_bookRipository == null)
                {
                    _bookRipository = new BookRepository(_db);
                }
                return _bookRipository;
            }
        }

        private CopyRipository _copyRipository;

        public CopyRipository CopyRipository
        {
            get
            {
                if (_copyRipository == null)
                {
                    _copyRipository = new CopyRipository(_db);
                }
                return _copyRipository;
            }
        }

        private MemberRipository _memberRipository;

        public MemberRipository MemberRipository
        {
            get
            {
                if (_memberRipository == null)
                {
                    _memberRipository = new MemberRipository(_db);
                }
                return _memberRipository;
            }
        }

        private CirculatedRecository _circulatedRipository;

        public CirculatedRecository CirculatedRipository
        {
            get
            {
                if (_circulatedRipository == null)
                {
                    _circulatedRipository = new CirculatedRecository(_db);
                }
                return _circulatedRipository;
            }
        }

        private ReservationRepository _reservationrepository;

        public ReservationRepository ReservationRepository
        {
            get
            {
                if (_reservationrepository == null)
                {
                    _reservationrepository = new ReservationRepository(_db);
                }
                return _reservationrepository;
            }
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }



    }
}
