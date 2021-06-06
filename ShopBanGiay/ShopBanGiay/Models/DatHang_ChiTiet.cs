﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopBanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class DatHang_ChiTiet
    {
        [Display(Name = "Mã chi tiết")]
        public int ID { get; set; }

        [Display(Name = "Đơn đặt hàng")]
        [Required(ErrorMessage = "Chưa chọn đơn đặt hàng!")]
        public Nullable<int> DatHang_ID { get; set; }

        [Display(Name = "Giày")]
        [Required(ErrorMessage = "Chưa chọn giày!")]
        public Nullable<int> Giay_ID { get; set; }

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Số lượng không được bỏ trống!")]
        public Nullable<short> SoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Đơn giá không được bỏ trống!")]
        public Nullable<int> DonGia { get; set; }

        [Display(Name = "Size")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Size không được bỏ trống!")]
        public Nullable<int> Size { get; set; }

        public virtual DatHang DatHang { get; set; }
        public virtual Giay Giay { get; set; }
    }
}
