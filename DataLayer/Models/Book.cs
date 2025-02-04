using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Book
    {
        [Key]
        public int BookNumber { get; set; } 

        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public ICollection<Copy> Copy { get; set; } = new List<Copy>();

    }
}
