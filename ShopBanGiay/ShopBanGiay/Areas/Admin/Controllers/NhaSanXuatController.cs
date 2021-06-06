using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopBanGiay.Models;

namespace ShopBanGiay.Areas.Admin.Controllers
{
	public class NhaSanXuatController : Controller
	{
		private ShopOnlineEntities2 db = new ShopOnlineEntities2();

		// GET: Admin/NhaSanXuat
		public ActionResult Index()
		{
			return View(db.NhaSanXuat.ToList());
		}

		// GET: Admin/NhaSanXuat/Details/5
		public ActionResult Create()
		{
			return View();
		}

		// POST: NhaXuatBan/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,TenNhaSanXuat")] NhaSanXuat nhaSanXuat)
		{
			if (ModelState.IsValid)
			{
				db.NhaSanXuat.Add(nhaSanXuat);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(nhaSanXuat);
		}

		// GET: NhaXuatBan/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NhaSanXuat nhaSanXuat = db.NhaSanXuat.Find(id);
			if (nhaSanXuat == null)
			{
				return HttpNotFound();
			}
			return View(nhaSanXuat);
		}

		// POST: NhaXuatBan/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,TenNhaSanXuat")] NhaSanXuat nhaSanXuat)
		{
			if (ModelState.IsValid)
			{
				db.Entry(nhaSanXuat).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(nhaSanXuat);
		}

		// GET: NhaXuatBan/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NhaSanXuat nhaSanXuat = db.NhaSanXuat.Find(id);
			if (nhaSanXuat == null)
			{
				return HttpNotFound();
			}
			return View(nhaSanXuat);
		}

		// POST: NhaXuatBan/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			NhaSanXuat nhaSanXuat = db.NhaSanXuat.Find(id);
			db.NhaSanXuat.Remove(nhaSanXuat);
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
