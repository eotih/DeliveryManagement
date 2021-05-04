using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManaDeli.Models
{
    public class DHModel
    {
        public int Id { get; set; }
        public Nullable<int> mavandon { get; set; }
        public Nullable<int> madonhang { get; set; }
        public string tennguoigui { get; set; }
        public string tennguoinhan { get; set; }
        public string sdtnguoinhan { get; set; }
        public string diachinguoinhan { get; set; }
        public Nullable<int> soluong { get; set; }
        public Nullable<int> giatri { get; set; }
        public string dichvu { get; set; }
        public string loaihang { get; set; }
        public Nullable<int> cannang { get; set; }
        public string ghichu { get; set; }
        public string trangthai { get; set; }
        public Nullable<int> phiship { get; set; }
        public Nullable<int> cod { get; set; }
        public Nullable<System.DateTime> ngaytaodon { get; set; }
        public string Shipper { get; set; }
    }
}