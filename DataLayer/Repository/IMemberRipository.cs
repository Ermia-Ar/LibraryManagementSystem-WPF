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
    public interface IMemberRipository
    {
        IEnumerable<Member> GetAllMember();

        IEnumerable<MemberViewModel1> GetMemberModel1();

        MemberViewModel2 GetMemberModel2ById(int memberId , out bool ex);

        Member GetMemberById(int membernumber);

        bool InsertMember(Member member);

        bool UpdateMember(Member member);

        bool DeleteMember(Member member);

        bool DeleteMember(int membernumber);
    }
}
