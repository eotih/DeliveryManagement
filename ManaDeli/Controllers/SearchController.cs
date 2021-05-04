using ManaDeli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManaDeli.Controllers
{
    public class SearchController : Controller
    {
        ManaDeli_DB empDB = new ManaDeli_DB();
        private ManaDeliEntities db = new ManaDeliEntities();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        
        public List<DONHANG> SearchByKey(string key)
        {
            return (db.DONHANGs.SqlQuery("Select * from DONHANG").ToList());
        }
    }
}