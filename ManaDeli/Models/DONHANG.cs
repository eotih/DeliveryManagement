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

    public partial class DONHANG
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Mã vận đơn")]
        public Nullable<int> mavandon { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Mã đơn hàng")]
        public Nullable<int> madonhang { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Tên người gửi")]
        public string tennguoigui { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Tên người nhận")]
        public string tennguoinhan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại người nhận")]
        public string sdtnguoinhan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ người nhận")]
        public string diachinguoinhan { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Số lượng")]
        public Nullable<int> soluong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Giá trị")]
        public Nullable<int> giatri { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Dịch vụ")]
        public string dichvu { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Loại hàng")]
        public string loaihang { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Cân nặng")]
        public Nullable<int> cannang { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Ghi chú")]
        public string ghichu { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Trạng thái")]
        public string trangthai { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Phí ship")]
        public Nullable<int> phiship { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số tiền Thu hộ")]
        public Nullable<int> cod { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Ngày tạo đơn")]
        public Nullable<System.DateTime> ngaytaodon { get; set; }
        public string Shipper { get; set; }
    }
}
