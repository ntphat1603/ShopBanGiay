using System;
using System.ComponentModel.DataAnnotations;

namespace ShopBanGiay.Models
{
    public class SanPhamTrongGio
    {
        public Giay giay { get; set; }
        public int soLuongTrongGio { get; set; }
    }
}