using DataLayer.Models;
using ViewModels.BookView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IReservationRipository
    {
        IEnumerable<Reservation> GetAllReservation();

        IEnumerable<ReservationViewModel1> GetReservationModel1();

        IEnumerable<ReservationViewModel1> GetReservationWithMemberNumber(int membernumber);

        Reservation GetReservationById(int reservationid);

        bool InsertReservation(Reservation reservation);

        bool UpdateReservation(Reservation reservation);

        bool DeleteReservation(Reservation reservation);

        bool DeleteReservation(int reservationid);
    }
}
