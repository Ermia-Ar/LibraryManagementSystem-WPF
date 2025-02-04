using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.context
{
    public class library_management_systemDB : DbContext
    {
        public DbSet<Book> T_Book { get; set; }
        public DbSet<Copy> T_Copy {  get; set; }    
        public DbSet<Member> T_Member { get; set; }
        public DbSet<Circulated> T_Circulated { get; set; }
        public DbSet<Reservation> T_Reservation { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=library-management-systemDB;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
