using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Member
    {
        [Key]
        public int MemberNumber { get; set; }   
        public string Name { get; set; }
        public bool Sex { get; set; }
        public string? Addess { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public ICollection<Circulated> Circulated { get; set; } = new List<Circulated>();
        public ICollection<Reservation> Reservation { get; set; } = new List<Reservation>();

    }
}
