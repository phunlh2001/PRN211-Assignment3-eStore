using BusinessObject.Objects;
using System.Collections.Generic;

namespace DataAccess.DaoAccess
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