using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        public int MemberNumber { get; set; }
        [ForeignKey("MemberNumber")]
        public Member member { get; set; }

        public int CopyNumber { get; set; }
        [ForeignKey("CopyNumber")]
        public Copy copy { get; set; }  

        public DateTime Date { get; set; }
        public int Status { get; set; }
    }
}
