using System;
using System.Collections.Generic;
using BusinessObject.Objects;

namespace DataAccess.Repository.Members
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetList();
        Member GetMemberById(int id);
        void InsertMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int id);
        bool Login(string email, string pwd);
        bool CheckEmail(string email);
        Member GetMemberByEmail(string email);
    }
}