using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ShopOnline.Libs;
using ShopBanGiay.Models;

namespace ShopBanGiay.Controllers
{
	public class HomeController : Controller
	{
		private ShopOnlineEntities2 db = new ShopOnlineEntities2();

		// GET: Home
		public ActionResult Index()
		{
			var sach = db.Giay.Where(r => r.SoLuong > 0).ToList();
			return View(sach);
		}

		// GET: Home/ThanhToan
		public ActionResult ThanhToan()
		{
			if (Session["MaKhachHang"] == null)
			{
				return RedirectToAction("Login", "Home");
			}
			else
			{
				return View();
			}
		}

		// POST: Home/ThanhToan
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ThanhToan(DatHang datHang)
		{
			if (ModelState.IsValid)
			{
				// Lưu vào bảng DatHang
				DatHang dh = new DatHang();
				dh.DiaChiGiaoHang = datHang.DiaChiGiaoHang;
				dh.DienThoaiGiaoHang = datHang.DienThoaiGiaoHang;
				dh.NgayDatHang = DateTime.Now;
				dh.KhachHang_ID = Convert.ToInt32(Session["MaKhachHang"]);
				dh.TinhTrang = 0;
				db.DatHang.Add(dh);
				db.SaveChanges();

				// Lưu vào bảng DatHang_ChiTiet
				List<SanPhamTrongGio> cart = (List<SanPhamTrongGio>)Session["cart"];
				foreach (var item in cart)
				{
					DatHang_ChiTiet ct = new DatHang_ChiTiet();
					ct.DatHang_ID = dh.ID;
					ct.Giay_ID = item.giay.ID;
					ct.SoLuong = Convert.ToInt16(item.soLuongTrongGio);
					ct.DonGia = item.giay.DonGia;
					ct.Size = item.giay.Size;
					db.DatHang_ChiTiet.Add(ct);
					db.SaveChanges();
				}

				// Xóa giỏ hàng
				cart.Clear();

				// Quay về trang chủ
				return RedirectToAction("Index", "Home");
			}

			return View(datHang);
		}

		// GET: Home/Login
		public ActionResult Login()
		{
			ModelState.AddModelError("LoginError", "");
			return View();
		}

		// POST: Home/Login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(KhachHangLogin khachHang)
		{
			if (ModelState.IsValid)
			{
				string matKhauMaHoa = SHA1.ComputeHash(khachHang.MatKhau);
				var taiKhoan = db.KhachHang.Where(r => r.TenDangNhap == khachHang.TenDangNhap && r.MatKhau == matKhauMaHoa).SingleOrDefault();

				if (taiKhoan == null)
				{
					ModelState.AddModelError("LoginError", "Tên đăng nhập hoặc mật khẩu không chính xác!");
					return View(khachHang);
				}
				else
				{
					// Đăng ký SESSION
					Session["MaKhachHang"] = taiKhoan.ID;
					Session["HoTenKhachHang"] = taiKhoan.HoVaTen;

					// Quay về trang chủ
					return RedirectToAction("Index", "Home");
				}
			}

			return View(khachHang);
		}
	}
}