using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManaDeli.Models;

namespace ManaDeli.Controllers
{
    public class ShipperController : Controller
    {
        ManaDeliEntities _db = new ManaDeliEntities();
        ManaDeli_DB empDB = new ManaDeli_DB();

        // GET: Shipper
        public ActionResult Index()
        {

            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Account/Login");
            }
        }
        public ActionResult Edit(int id)
        {
            ManaDeli_DB MD = new ManaDeli_DB();
            return View(MD.ListAllTaiKhoan().Find(Emp => Emp.id == id));

        }

        // POST: Employee/EditEmpDetails/5    
        [HttpPost]

        public ActionResult Edit(int id, DONHANG dh)
        {
            try
            {
                ManaDeli_DB MD = new ManaDeli_DB();

                MD.Update(dh);
                return View("../QuanLy/Index");
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
        public JsonResult GetbyID(string a)
        {
            a = @Session["username"].ToString();
            var Employee = empDB.ListAll().FindAll(x => x.Shipper.Equals(a));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(DONHANG emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }
    }
}