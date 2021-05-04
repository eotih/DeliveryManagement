using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManaDeli.Models;

namespace ManaDeli.Controllers
{
    public class DeliveryController : Controller
    {
        private ManaDeliEntities db = new ManaDeliEntities();
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        // GET: Delivery
        public ActionResult Index()
        {
            var b = "Chưa nhận";
            var lst = db.DONHANGs.Where(n => n.Shipper == null & n.trangthai == b);
            return View(lst);
        }

        // GET: Delivery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }
        
        // GET: Delivery/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DONHANG dONHANG)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ShipperUpdate", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", dONHANG.Id);
                com.Parameters.AddWithValue("@trangthai", dONHANG.trangthai);
                com.Parameters.AddWithValue("@ghichu", dONHANG.ghichu);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
                TempData["msg"] = "<script>alert('Chỉnh sửa thành công!');</script>";
            }
            return View(dONHANG);
        }
        public ActionResult ThemShipper(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemShipper(DONHANG dONHANG)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AddShipper", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", dONHANG.Id);
                com.Parameters.AddWithValue("@Shipper", dONHANG.Shipper);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
                TempData["msg"] = "<script>alert('Chọn đơn thành công!');</script>";
            }
            return Redirect("../../Shipper");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
