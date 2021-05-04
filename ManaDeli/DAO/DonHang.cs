using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManaDeli.Models;

namespace ManaDeli.DAO
{
    public class DonHang
    {
        private ManaDeliEntities db = new ManaDeliEntities();
        public List<DONHANG> SearchByKey(string key)
        {
            return (db.DONHANGs.SqlQuery("Select * from DONHANG where madonhang = '"+key+"'").ToList());
        }
    }
}