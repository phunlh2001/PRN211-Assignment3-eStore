using System;
using BusinessObject.Objects;
using DataAccess.Repository.Members;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace eStore.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepository _db;
        public MemberController(MemberRepository db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            var list = this._db.GetList();
            return View(list);
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(string cPwd, Member member)
        {
            if (ModelState.IsValid)
            {
                var emailExist = this._db.CheckEmail(member.Email);
                if (emailExist)
                {
                    ViewBag.error = "Email does exits";
                }
                else if (String.Equals(cPwd, member.Password))
                {
                    this._db.InsertMember(member);
                    return Redirect("/");
                }
                else
                {
                    ViewBag.error = "Confirm Password invalid";
                }
            }
            return View();
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string pwd)
        {
            var member = this._db.GetMemberByEmail(email);
            var check = this._db.Login(email, pwd);
            if (check)
            {
                HttpContext.Session.SetString("user", email);
                HttpContext.Session.SetString("userID", Convert.ToString(member.MemberId));
                return Redirect("/");
            }
            ViewBag.error = "Login Failed";
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("userID");
            return Redirect("/");
        }
    }
}