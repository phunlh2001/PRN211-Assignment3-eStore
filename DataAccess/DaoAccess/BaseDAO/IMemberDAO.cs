using System;
using System.Collections.Generic;
using BusinessObject.Objects;

namespace DataAccess.DaoAccess.BaseDAO
{
    public interface IMemberDAO
    {
        IEnumerable<Member> GetAll();
        Member GetOne(int id);
        void Insert(Member member);
        void Update(Member member);
        void Delete(int id);
        bool Login(string email, string pwd);
        bool GetEmail(string email);
        Member GetMemberByEmail(string email);
    }
}