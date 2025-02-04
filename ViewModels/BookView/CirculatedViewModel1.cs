using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.BookView
{
    public class CirculatedViewModel1
    {
        public int CirculatedID { get; set; }
        public int MemberNumber { get; set; }
        public int CopyNumber { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double? FineAmount { get; set; }
    }
}
