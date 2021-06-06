using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ShopOnline.Libs;
using ShopBanGiay.Models;

namespace ShopBanGiay.Areas.Admin.Controllers
{
	public class KhachHangController : Controller
	{
		private ShopOnlineEntities2 db = new ShopOnlineEntities2();

		// GET: KhachHang
		public ActionResult Index()
		{
			return View(db.KhachHang.ToList());
		}

		// GET: KhachHang/Logout
		public ActionResult Logout()
		{
			// Xóa SESSION
			Session.Remove("MaKhachHang");
			Session.Remove("HoTenKhachHang");

			// Quay về trang chủ
			return RedirectToAction("Index", "Home");
		}

		// GET: KhachHang/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: KhachHang/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,HoVaTen,DienThoai,DiaChi,TenDangNhap,XacNhanMatKhau,MatKhau")] KhachHang khachHang)
		{
			if (ModelState.IsValid)
			{
				// Mã hóa mật khẩu
				khachHang.MatKhau = SHA1.ComputeHash(khachHang.MatKhau);
				khachHang.XacNhanMatKhau = SHA1.ComputeHash(khachHang.XacNhanMatKhau);

				db.KhachHang.Add(khachHang);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(khachHang);
		}

		// GET: KhachHang/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			KhachHang khachHang = db.KhachHang.Find(id);
			if (khachHang == null)
			{
				return HttpNotFound();
			}
			return View(new KhachHangEdit(khachHang));
		}

		// POST: KhachHang/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,HoVaTen,DienThoai,DiaChi,TenDangNhap,MatKhau,XacNhanMatKhau")] KhachHangEdit khachHang)
		{
			if (ModelState.IsValid)
			{
				KhachHang n = db.KhachHang.Find(khachHang.ID);

				// Giữ nguyên mật khẩu cũ
				if (khachHang.MatKhau == null)
				{
					n.ID = khachHang.ID;
					n.HoVaTen = khachHang.HoVaTen;
					n.DienThoai = khachHang.DienThoai;
					n.DiaChi = khachHang.DiaChi;
					n.TenDangNhap = khachHang.TenDangNhap;
					n.XacNhanMatKhau = n.MatKhau;
				}
				else // Cập nhật mật khẩu mới
				{
					n.ID = khachHang.ID;
					n.HoVaTen = khachHang.HoVaTen;
					n.DienThoai = khachHang.DienThoai;
					n.DiaChi = khachHang.DiaChi;
					n.TenDangNhap = khachHang.TenDangNhap;
					n.MatKhau = SHA1.ComputeHash(khachHang.MatKhau);
					n.XacNhanMatKhau = SHA1.ComputeHash(khachHang.XacNhanMatKhau);
				}

				db.Entry(n).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(khachHang);
		}

		// GET: KhachHang/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			KhachHang khachHang = db.KhachHang.Find(id);
			if (khachHang == null)
			{
				return HttpNotFound();
			}
			return View(khachHang);
		}

		// POST: KhachHang/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			KhachHang khachHang = db.KhachHang.Find(id);
			db.KhachHang.Remove(khachHang);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}