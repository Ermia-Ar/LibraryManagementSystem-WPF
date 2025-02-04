using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.MemberView
{
    public class MemberViewModel1
    {
        public int MemberNumber { get; set; }
        public string Name { get; set; }
        public Gender Sex { get; set; }
        public string? Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
