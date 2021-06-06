using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ShopOnline.Libs;
using ShopBanGiay.Models;

namespace ShopBanGiay.Areas.Admin.Controllers
{
	public class HomeController : Controller
	{
		private ShopOnlineEntities2 db = new ShopOnlineEntities2();

		public ActionResult Index()
		{
			return View();
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
		public ActionResult Login(NhanVienLogin nhanVien)
		{
			if (ModelState.IsValid)
			{
				string matKhauMaHoa = SHA1.ComputeHash(nhanVien.MatKhau);
				var taiKhoan = db.NhanVien.Where(r => r.TenDangNhap == nhanVien.TenDangNhap && r.MatKhau == matKhauMaHoa).SingleOrDefault();

				if (taiKhoan == null)
				{
					ModelState.AddModelError("LoginError", "Tên đăng nhập hoặc mật khẩu không chính xác!");
					return View(nhanVien);
				}
				else
				{
					// Đăng ký SESSION
					Session["MaNhanVien"] = taiKhoan.ID;
					Session["HoTenNhanVien"] = taiKhoan.HoVaTen;
					Session["Quyen"] = taiKhoan.Quyen;

					// Quay về trang chủ
					return RedirectToAction("Index", "Home");
				}
			}

			return View(nhanVien);
		}
	}
}