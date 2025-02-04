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
    public class ReservationRepository : IReservationRipository
    {
        private library_management_systemDB db;

        public ReservationRepository(library_management_systemDB db)
        {
            this.db = db;
        }

        public IEnumerable<Reservation> GetAllReservation()
        {
            return db.T_Reservation;
        }

        public Reservation GetReservationById(int reservationid)
        {
            return db.T_Reservation.Find(reservationid);
        }

        public bool DeleteReservation(Reservation reservation)
        {
            try
            {
                db.Entry(reservation).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteReservation(int reservationid)
        {
            try
            {
                var copy = GetReservationById(reservationid);
                DeleteReservation(copy);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool InsertReservation(Reservation reservation)
        {
            try
            {
                db.T_Reservation.Add(reservation);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateReservation(Reservation reservation)
        {
            db.Entry(reservation).State = EntityState.Modified;
            return true;

        }

        public IEnumerable<ReservationViewModel1> GetReservationModel1()
        {
            return db.T_Reservation.Select(x => new ReservationViewModel1 { ReservationID = x.ReservationID , MemberNumber = x.MemberNumber 
                , CopyNumber = x.CopyNumber, Date = x.Date , Status = (StatusN)x.Status} );
        }

        public IEnumerable<ReservationViewModel1> GetReservationWithMemberNumber(int membernumber)
        {
            return db.T_Reservation.Where(x => x.MemberNumber == membernumber).Select(x => new ReservationViewModel1
            {
                ReservationID = x.ReservationID,
                MemberNumber = x.MemberNumber,
                CopyNumber = x.CopyNumber,
                Date = x.Date,
                Status = (StatusN)x.Status
            });
        }
    }
}
