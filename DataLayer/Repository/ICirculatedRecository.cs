using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.BookView;
using ViewModels.MemberView;

namespace DataLayer.Repository
{
    public interface ICirculatedRecository
    {
        IEnumerable<Circulated> GetAllCirculated();

        IEnumerable<CirculatedViewModel1> GetAllCirculatedWithMemberNumber(int membernumber);

        Circulated GetCirculatedById(int circulatedid);

        bool InsertCirculated(Circulated circulated);

        bool UpdateCirculated(Circulated circulated);

        bool DeleteCirculated(Circulated circulated);

        bool DeleteCirculated(int circulatedid);
    }
}
