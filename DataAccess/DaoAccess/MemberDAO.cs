using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject.Objects;
using DataAccess.DaoAccess.BaseDAO;

namespace DataAccess.DaoAccess
{
    public class MemberDAO : IMemberDAO
    {
        //Singleton Design Pattern
        private static MemberDAO instance;
        private static readonly object instanceLock = new object();
        public static MemberDAO GetInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetAll()
        {
            var mems = new List<Member>();
            try
            {
                using var context = new eStoreContext();
                mems = context.Members.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return mems;
        }

        public Member GetOne(int id)
        {
            Member member = null;
            try
            {
                using var context = new eStoreContext();
                member = context.Members.FirstOrDefault(m => m.MemberId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return member;
        }

        public void Insert(Member member)
        {
            try
            {
                Member _mem = GetOne(member.MemberId);
                if (_mem == null)
                {
                    using var context = new eStoreContext();
                    context.Members.Add(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Member is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Member member)
        {
            try
            {
                Member _mem = GetOne(member.MemberId);
                if (_mem != null)
                {
                    using var context = new eStoreContext();
                    context.Members.Update(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Member does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                Member _mem = GetOne(id);
                if (_mem != null)
                {
                    using var context = new eStoreContext();
                    context.Members.Remove(_mem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Member is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Login(string email, string pwd)
        {
            Member member = null;
            try
            {
                using var context = new eStoreContext();
                member = context.Members.FirstOrDefault(m => m.Email == email);
                if (member == null || member.Password != pwd)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool GetEmail(string email)
        {
            Member member = null;
            using var context = new eStoreContext();
            member = context.Members.FirstOrDefault(m => String.Equals(m.Email, email));
            if (member != null)
            {
                return true;
            }
            return false;
        }

        public Member GetMemberByEmail(string email)
        {
            Member member = null;
            using var context = new eStoreContext();
            member = context.Members.FirstOrDefault(m => m.Email == email);
            return member;
        }
    }
}