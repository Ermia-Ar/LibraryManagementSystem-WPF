using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.BookView
{
    public class CopyViewModel1
    {
        public int CopyNumber { get; set; }
        public int BookNumber { get; set; }
        public int SequenceNumber { get; set; }
        public TypeN Type { get; set; }
        public double Price { get; set; }
    }
    public enum TypeN : int
    {
        Available,
        Borrowed,
        Reserved
    }
}
