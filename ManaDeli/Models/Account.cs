using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManaDeli.Models
{
    public class Account
    {
            public int id { get; set; }
            public string hoten { get; set; }
            public string email { get; set; }
            public string username { get; set; }
            public string pass { get; set; }
            public int phone { get; set; }
            public string diachi { get; set; }
            public string quyen { get; set; }
        
    }
}