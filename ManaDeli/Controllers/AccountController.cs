using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManaDeli.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace ManaDeli.Controllers
{  
    public class AccountController : Controller
    {
        private ManaDeliEntities _db = new ManaDeliEntities();
        ManaDeli_DB a = new ManaDeli_DB();
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public ActionResult Index()
        {
            var data = (from s in _db.TAIKHOANs select s).ToList();
            ViewBag.posts = data;
            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TAIKHOAN _user)
        {
            if (ModelState.IsValid == true)
            {
                var check = _db.TAIKHOANs.FirstOrDefault(s => s.username == _user.username);
                if (check == null)
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.TAIKHOANs.Add(_user);
                    _db.SaveChanges();
                    TempData["msg"] = "<script>alert('Đăng ký thành công vui lòng liên hệ admin để kích hoạt tài khoản!');</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
                
            }
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string pass)
        {
            if (ModelState.IsValid)
            {
                var data = _db.TAIKHOANs.Where(s => s.username.Equals(username) && s.pass.Equals(pass)).ToList();
                if (data.Count() > 0)
                {
                    Session["id"] = data.FirstOrDefault().id;
                    Session["hoten"] = data.FirstOrDefault().hoten;
                    Session["email"] = data.FirstOrDefault().email;
                    Session["username"] = data.FirstOrDefault().username;
                    Session["pass"] = data.FirstOrDefault().pass;
                    Session["phone"] = data.FirstOrDefault().phone;
                    Session["diachi"] = data.FirstOrDefault().diachi;
                    Session["quyen"] = data.FirstOrDefault().quyen;
                    TempData["msg"] = "<script>alert('Đăng nhập thành công!');</script>";
                    return RedirectToAction("../Dashboard/Index");

                }
                else
                {
                    TempData["msg"] = "<script>alert('Tên Đăng Nhập và/hoặc Mật Khẩu của bạn không chính xác. Vui lòng kiểm tra và thử lại.');</script>";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            TempData["msg"] = "<script>alert('Đăng xuất thành công!');</script>";
            return RedirectToAction("Login");
        }
        public JsonResult List()
        {
            return Json(a.ListAllTaiKhoan(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = a.ListAllTaiKhoan().Find(x => x.id.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(TAIKHOAN emp)
        {
            return Json(a.UpdateProfile(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(a.DeleteTaiKhoan(ID), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UpDateUser()
        {
            Account up = new Account();
            int iad = Convert.ToInt32(Session["id"]);
            var us = _db.TAIKHOANs.Where(n => n.id == iad).FirstOrDefault();
            if (us != null)
            {
                up.id = us.id;
                up.hoten = us.hoten;
                up.email = us.email;
                up.pass = us.pass;
                up.phone = us.phone;
                up.diachi = us.diachi;
                return View(up);
            }
            return Redirect("../Dashboard/Index");
        }
        [HttpPost]
        public ActionResult UpDateUser(Account us, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                var up = _db.TAIKHOANs.Where(n => n.id == us.id).FirstOrDefault();
                up.id = us.id;
                up.hoten = us.hoten;
                up.email = us.email;
                up.pass = us.pass;
                up.phone = us.phone;
                up.diachi = us.diachi;
                _db.SaveChanges();
                TempData["msg"] = "<script>alert('Chỉnh sửa thành công!');</script>";
                return View("../Dashboard/Index");
            }
            else
            {
                return View("../Dashboard/Index");
            }
        }

    }
}