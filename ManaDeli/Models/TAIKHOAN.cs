﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManaDeli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TAIKHOAN
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập họ tên")]
        public string hoten { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập pass")]
        public string pass { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]

        public int phone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string diachi { get; set; }
        public string quyen { get; set; }
    }
}