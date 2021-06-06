using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ShopBanGiay.Models;

namespace ShopBanGiay.Areas.Admin.Controllers
{
	public class DatHang_ChiTietController : Controller
	{
		private ShopOnlineEntities2 db = new ShopOnlineEntities2();

		// GET: DatHang_ChiTiet
		public ActionResult Index()
		{
			var datHang_ChiTiet = db.DatHang_ChiTiet.Include(d => d.DatHang).Include(d => d.Giay);
			return View(datHang_ChiTiet.ToList());
		}

		// GET: DatHang_ChiTiet/Create
		public ActionResult Create()
		{
			ViewBag.DatHang_ID = new SelectList(db.DatHang, "ID", "DienThoaiGiaoHang");
			ViewBag.Giay_ID = new SelectList(db.Giay, "ID", "TenGiay");
			return View();
		}

		// POST: DatHang_ChiTiet/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,DatHang_ID,Giay_ID,SoLuong,DonGia,Size")] DatHang_ChiTiet datHang_ChiTiet)
		{
			if (ModelState.IsValid)
			{
				db.DatHang_ChiTiet.Add(datHang_ChiTiet);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.DatHang_ID = new SelectList(db.DatHang, "ID", "DienThoaiGiaoHang", datHang_ChiTiet.DatHang_ID);
			ViewBag.Giay_ID = new SelectList(db.Giay, "ID", "TenGiay", datHang_ChiTiet.Giay_ID);
			return View(datHang_ChiTiet);
		}

		// GET: DatHang_ChiTiet/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DatHang_ChiTiet datHang_ChiTiet = db.DatHang_ChiTiet.Find(id);
			if (datHang_ChiTiet == null)
			{
				return HttpNotFound();
			}
			ViewBag.DatHang_ID = new SelectList(db.DatHang, "ID", "DienThoaiGiaoHang", datHang_ChiTiet.DatHang_ID);
			ViewBag.Giay_ID = new SelectList(db.Giay, "ID", "TenGiay", datHang_ChiTiet.Giay_ID);
			return View(datHang_ChiTiet);
		}

		// POST: DatHang_ChiTiet/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,DatHang_ID,Giay_ID,SoLuong,DonGia,Size")] DatHang_ChiTiet datHang_ChiTiet)
		{
			if (ModelState.IsValid)
			{
				db.Entry(datHang_ChiTiet).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.DatHang_ID = new SelectList(db.DatHang, "ID", "DienThoaiGiaoHang", datHang_ChiTiet.DatHang_ID);
			ViewBag.Giay_ID = new SelectList(db.Giay, "ID", "TenGiay", datHang_ChiTiet.Giay_ID);
			return View(datHang_ChiTiet);
		}

		// GET: DatHang_ChiTiet/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DatHang_ChiTiet datHang_ChiTiet = db.DatHang_ChiTiet.Find(id);
			if (datHang_ChiTiet == null)
			{
				return HttpNotFound();
			}
			return View(datHang_ChiTiet);
		}

		// POST: DatHang_ChiTiet/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			DatHang_ChiTiet datHang_ChiTiet = db.DatHang_ChiTiet.Find(id);
			db.DatHang_ChiTiet.Remove(datHang_ChiTiet);
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