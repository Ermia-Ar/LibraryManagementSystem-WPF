using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Copy
    {
        [Key]
        public int CopyNumber { get; set; }

        public int BookNumber { get; set; }
        [ForeignKey("BookNumber")]
        public Book book { get; set; }


        public int SequenceNumber { get; set; }
        public int Type {  get; set; }
        public double Price { get; set; }

        public ICollection<Reservation> Reservation { get; set; } = new List<Reservation>();
        public ICollection<Circulated> Circulated { get; set; } = new List<Circulated>();
    }
}
