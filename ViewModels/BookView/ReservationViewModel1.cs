using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.BookView
{
    public class ReservationViewModel1
    {
        public int ReservationID { get; set; }

        public int MemberNumber { get; set; }

        public int CopyNumber { get; set; }

        public DateTime Date { get; set; }

        public StatusN Status { get; set; }
    }
    public enum StatusN
    {
        Available,
        Reserved
    }
}
