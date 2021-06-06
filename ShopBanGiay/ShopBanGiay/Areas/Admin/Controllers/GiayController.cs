using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ShopBanGiay.Models;

namespace ShopBanGiay.Areas.Admin.Controllers
{
	public class GiayController : Controller
	{
		private ShopOnlineEntities2 db = new ShopOnlineEntities2();

		// GET: Sach
		public ActionResult Index()
		{
			var giay = db.Giay.Include(s => s.LoaiGiay).Include(s => s.NhaSanXuat);
			return View(giay.ToList());
		}

		// GET: Sach/Create
		public ActionResult Create()
		{
			ViewBag.LoaiGiay_ID = new SelectList(db.LoaiGiay, "ID", "TenLoai");
			ViewBag.NhaSanXuat_ID = new SelectList(db.NhaSanXuat, "ID", "TenNhaSanXuat");
			ModelState.AddModelError("UploadError", "");
			return View();
		}

		// POST: Sach/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,NhaSanXuat_ID,LoaiGiay_ID,TenGiay,DonGia,Size,SoLuong,DuLieuHinhAnhBia,MoTa")] Giay giay)
		{
			ViewBag.LoaiGiay_ID = new SelectList(db.LoaiGiay, "ID", "TenLoai", giay.LoaiGiay_ID);
			ViewBag.NhaSanXuat_ID = new SelectList(db.NhaSanXuat, "ID", "TenNhaSanXuat", giay.NhaSanXuat_ID);

			if (ModelState.IsValid)
			{
				// Upload
				if (giay.DuLieuHinhAnhBia != null)
				{
					string folder = "Storage/";
					string fileExtension = Path.GetExtension(giay.DuLieuHinhAnhBia.FileName).ToLower();

					// Kiểm tra kiểu
					var fileTypeSupported = new[] { ".jpg", ".jpeg", ".png", ".gif" };
					if (!fileTypeSupported.Contains(fileExtension))
					{
						ModelState.AddModelError("UploadError", "Chỉ cho phép tập tin JPG, PNG, GIF!");
						return View(giay);
					}
					else if (giay.DuLieuHinhAnhBia.ContentLength > 2 * 1024 * 1024)
					{
						ModelState.AddModelError("UploadError", "Chỉ cho phép tập tin từ 2MB trở xuống!");
						return View(giay);
					}
					else
					{
						string fileName = Guid.NewGuid().ToString() + fileExtension;
						string filePath = Path.Combine(Server.MapPath("~/" + folder), fileName);
						giay.DuLieuHinhAnhBia.SaveAs(filePath);

						// Cập nhật đường dẫn vào CSDL
						giay.HinhAnh = folder + fileName;

						db.Giay.Add(giay);
						db.SaveChanges();
						return RedirectToAction("Index");
					}
				}
				else
				{
					ModelState.AddModelError("UploadError", "Hình ảnh bìa không được bỏ trống!");
					return View(giay);
				}
			}

			return View(giay);
		}

		// GET: Sach/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Giay giay = db.Giay.Find(id);
			if (giay == null)
			{
				return HttpNotFound();
			}
			ViewBag.LoaiGiay_ID = new SelectList(db.LoaiGiay, "ID", "TenLoai", giay.LoaiGiay_ID);
			ViewBag.NhaSanXuat_ID = new SelectList(db.NhaSanXuat, "ID", "TenNhaSanXuat", giay.NhaSanXuat_ID);
			ModelState.AddModelError("UploadError", "");
			return View(giay);
		}

		// POST: Sach/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,HinhAnh,NhaXuatBan_ID,LoaiSach_ID,TenSach,DonGia,Size,SoLuong,DuLieuHinhAnhBia,MoTa")] Giay giay)
		{
			ViewBag.LoaiGiay_ID = new SelectList(db.LoaiGiay, "ID", "TenLoai", giay.LoaiGiay_ID);
			ViewBag.NhaSanXuat_ID = new SelectList(db.NhaSanXuat, "ID", "TenNhaSanXuat", giay.NhaSanXuat_ID);

			if (ModelState.IsValid)
			{
				// Upload ảnh mới
				if (giay.DuLieuHinhAnhBia != null)
				{
					// Xóa ảnh cũ
					string oldFilePath = Server.MapPath("~/" + giay.HinhAnh);
					if (System.IO.File.Exists(oldFilePath)) System.IO.File.Delete(oldFilePath);

					string folder = "Storage/";
					string fileExtension = Path.GetExtension(giay.DuLieuHinhAnhBia.FileName).ToLower();

					// Kiểm tra kiểu
					var fileTypeSupported = new[] { ".jpg", ".jpeg", ".png", ".gif" };
					if (!fileTypeSupported.Contains(fileExtension))
					{
						ModelState.AddModelError("UploadError", "Chỉ cho phép tập tin JPG, PNG, GIF!");
						return View(giay);
					}
					else if (giay.DuLieuHinhAnhBia.ContentLength > 2 * 1024 * 1024)
					{
						ModelState.AddModelError("UploadError", "Chỉ cho phép tập tin từ 2MB trở xuống!");
						return View(giay);
					}
					else
					{
						string fileName = Guid.NewGuid().ToString() + fileExtension;
						string filePath = Path.Combine(Server.MapPath("~/" + folder), fileName);
						giay.DuLieuHinhAnhBia.SaveAs(filePath);

						// Cập nhật đường dẫn vào CSDL
						giay.HinhAnh = folder + fileName;

						db.Entry(giay).State = EntityState.Modified;
						db.SaveChanges();
						return RedirectToAction("Index");
					}
				}
				else // Giữ nguyên ảnh cũ
				{
					db.Entry(giay).State = EntityState.Modified;
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}

			return View(giay);
		}

		// GET: Sach/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Giay giay = db.Giay.Find(id);
			if (giay == null)
			{
				return HttpNotFound();
			}
			return View(giay);
		}

		// POST: Sach/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Giay giay = db.Giay.Find(id);
			db.Giay.Remove(giay);
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