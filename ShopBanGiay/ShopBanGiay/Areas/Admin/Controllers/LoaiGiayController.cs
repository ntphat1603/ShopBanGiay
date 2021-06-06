using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ShopBanGiay.Models;

namespace ShopBanGiay.Areas.Admin.Controllers
{
    public class LoaiGiayController : Controller
    {
        private ShopOnlineEntities2 db = new ShopOnlineEntities2();

        // GET: Admin/LoaiGiay
        public ActionResult Index()
        {
			return View(db.LoaiGiay.ToList());
        }

		// GET: LoaiSach/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: LoaiSach/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,TenLoai")] LoaiGiay loaiGiay)
		{
			if (ModelState.IsValid)
			{
				db.LoaiGiay.Add(loaiGiay);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(loaiGiay);
		}

		// GET: LoaiSach/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			LoaiGiay loaiGiay = db.LoaiGiay.Find(id);
			if (loaiGiay == null)
			{
				return HttpNotFound();
			}
			return View(loaiGiay);
		}

		// POST: LoaiSach/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,TenLoai")] LoaiGiay loaiGiay)
		{
			if (ModelState.IsValid)
			{
				db.Entry(loaiGiay).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(loaiGiay);
		}

		// GET: LoaiSach/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			LoaiGiay loaiGiay = db.LoaiGiay.Find(id);
			if (loaiGiay == null)
			{
				return HttpNotFound();
			}
			return View(loaiGiay);
		}

		// POST: LoaiSach/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			LoaiGiay loaiGiay = db.LoaiGiay.Find(id);
			db.LoaiGiay.Remove(loaiGiay);
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
