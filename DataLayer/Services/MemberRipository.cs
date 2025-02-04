using DataLayer.context;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.BookView;
using ViewModels.MemberView;

namespace DataLayer.Services
{
    public class MemberRipository : IMemberRipository
    {
        private library_management_systemDB db;

        public MemberRipository(library_management_systemDB db)
        {
            this.db = db;
        }

        public IEnumerable<Member> GetAllMember()
        {
           
            return db.T_Member;
        }

        public Member GetMemberById(int membernumber)
        {
            return db.T_Member.Find(membernumber);
        }

        public bool DeleteMember(Member member)
        {
            try
            {
                db.Entry(member).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteMember(int membernumber)
        {
            try
            {
                var member = GetMemberById(membernumber);
                DeleteMember(member);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool InsertMember(Member member)
        {
            try
            {
                db.T_Member.Add(member);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateMember(Member member)
        {
            db.Entry(member).State = EntityState.Modified;
            return true;

        }

        public IEnumerable<MemberViewModel1> GetMemberModel1()
        {
            return db.T_Member.Select(x => new MemberViewModel1 { MemberNumber =x.MemberNumber , Address = x.Addess , Email = x.Email 
                , Name = x.Name , Telephone = x.Telephone , Sex = x.Sex? Gender.Female : Gender.Male});
        }

        public MemberViewModel2 GetMemberModel2ById(int membernumber , out bool ex)
        {
            MemberViewModel2 member;
            var item = GetMemberById(membernumber);
            if(item == null) 
            {
                member = new MemberViewModel2();
                ex = true;
            }
            else
            {
                member = new MemberViewModel2 { MemberNumber = item.MemberNumber, Telephone = item.Telephone, Name = item.Name, };
                ex = false;
            }
            return member;
        }

    }
}
