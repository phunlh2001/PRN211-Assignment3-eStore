using System;
using System.Collections.Generic;
using BusinessObject.Objects;
using DataAccess.DaoAccess;

namespace DataAccess.Repository.Members
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> GetList() => MemberDAO.GetInstance.GetAll();
        public Member GetMemberById(int id) => MemberDAO.GetInstance.GetOne(id);
        public void InsertMember(Member member) => MemberDAO.GetInstance.Insert(member);
        public void UpdateMember(Member member) => MemberDAO.GetInstance.Update(member);
        public void DeleteMember(int id) => MemberDAO.GetInstance.Delete(id);
        public bool Login(string email, string pwd) => MemberDAO.GetInstance.Login(email, pwd);
        public bool CheckEmail(string email) => MemberDAO.GetInstance.GetEmail(email);

        public Member GetMemberByEmail(string email) => MemberDAO.GetInstance.GetMemberByEmail(email);
    }
}