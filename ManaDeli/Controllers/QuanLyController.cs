using System.Web;
using System.Web.Mvc;
using ManaDeli.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System;

namespace ManaDeli.Controllers
{
    public class QuanLyController : Controller
    {

        ManaDeliEntities _db = new ManaDeliEntities();
        ManaDeli_DB empDB = new ManaDeli_DB();
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //GET: QuanLy
        public ActionResult Tatca()
        {
            //lấy ds đơn hàng chưa duyệt
            if (Session["id"] != null)
            {
                var tong = _db.DONHANGs.ToList();
                return View(tong);
            }
            else
            {
                return RedirectToAction("../Account/Login");

            }
        }
        public ActionResult Chuanhan()
        {
            //lấy ds đơn hàng chưa duyệt
            var a = "Chưa nhận";
            var lst = _db.DONHANGs.Where(n => n.trangthai == a);
            return View(lst);
        }
        public ActionResult DaGiao()
        {
            //lấy ds đơn hàng chưa duyệt
            var b = "Đã giao";
            var lst1 = _db.DONHANGs.Where(n => n.trangthai == b);
            return View(lst1);
        }
        public ActionResult Danggiao()
        {
            //lấy ds đơn hàng chưa duyệt
            var c = "Đã nhận – Đang giao";
            var lst2 = _db.DONHANGs.Where(n => n.trangthai == c);
            return View(lst2);
        }
        public ActionResult Danhanchuagiao()
        {
            //lấy ds đơn hàng chưa duyệt
            var d = "Đã nhận - Chưa giao";
            var lst3 = _db.DONHANGs.Where(n => n.trangthai == d);
            return View(lst3);
        }

        public ActionResult Edit(int id)
        {
            ManaDeli_DB MD = new ManaDeli_DB();
            return View(MD.ListAllTaiKhoan().Find(Emp => Emp.id == id));

        }
        public ActionResult UpDateDH(int? id)
        {
            DHModel up = new DHModel();
            var us = _db.DONHANGs.Where(n => n.Id == id).FirstOrDefault();
            if (us != null)
            {
                up.Id = us.Id;
                up.mavandon = us.mavandon;
                up.madonhang = us.madonhang;
                up.tennguoigui = us.tennguoigui;
                up.tennguoinhan = us.tennguoinhan;
                up.sdtnguoinhan = us.sdtnguoinhan;
                up.diachinguoinhan = us.diachinguoinhan;
                up.soluong = us.soluong;
                up.giatri = us.giatri;
                up.dichvu = us.dichvu;
                up.loaihang = us.loaihang;
                up.cannang = us.cannang;
                up.ghichu = us.ghichu;
                up.trangthai = us.trangthai;
                up.phiship = us.phiship;
                up.cod = us.cod;
                up.ngaytaodon = us.ngaytaodon;

                return View(up);
            }
            return Redirect("../QuanLy/Tatca");
        }
        [HttpPost]
        public ActionResult UpDateDH(DHModel us, HttpPostedFileBase HinhAnh)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var up = _db.DONHANGs.Where(n => n.Id == us.Id).FirstOrDefault();
                    up.Id = us.Id;
                    up.mavandon = us.mavandon;
                    up.madonhang = us.madonhang;
                    up.tennguoigui = us.tennguoigui;
                    up.tennguoinhan = us.tennguoinhan;
                    up.sdtnguoinhan = us.sdtnguoinhan;
                    up.diachinguoinhan = us.diachinguoinhan;
                    up.soluong = us.soluong;
                    up.giatri = us.giatri;
                    up.dichvu = us.dichvu;
                    up.loaihang = us.loaihang;
                    up.cannang = us.cannang;
                    up.ghichu = us.ghichu;
                    up.trangthai = us.trangthai;
                    up.phiship = us.phiship;
                    up.cod = us.cod;
                    up.ngaytaodon = DateTime.Now;
                    _db.SaveChanges();
                    TempData["msg"] = "<script>alert('Sửa đơn hàng thành công!');</script>";
                    return Redirect("../Tatca");
                }
                else
                {
                    TempData["msg"] = "<script>alert('Sửa đơn hàng 0 thành công!');</script>";
                    return View("../QuanLy/Tatca");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }

        // POST: Employee/EditEmpDetails/5    
        [HttpPost]

        public ActionResult Edit(int id, DONHANG dh)
        {
            try
            {
                ManaDeli_DB MD = new ManaDeli_DB();

                MD.Update(dh);
                return View("../QuanLy/Tatca");
            }
            catch
            {
                return View();
            }
        }


        public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = empDB.ListAll().Find(x => x.Id.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(DONHANG emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int? id)
        {
            var product = _db.DONHANGs.Where(s => s.Id == id).First();
            _db.DONHANGs.Remove(product);
            _db.SaveChanges();
            TempData["msg"] = "<script>alert('Xóa đơn hàng thành công!');</script>";
            return RedirectToAction("Tatca");
        }


    }
}