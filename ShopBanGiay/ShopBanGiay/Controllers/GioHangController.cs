using System.Collections.Generic;
using System.Web.Mvc;
using ShopBanGiay.Models;

namespace ShopBanGiay.Controllers
{
    public class GioHangController : Controller
    {
        private ShopOnlineEntities2 db = new ShopOnlineEntities2();

        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }

        // GET: GioHang/ThemVaoGio/{maSP}
        public ActionResult ThemVaoGio(int maSP)
        {
            if (Session["cart"] == null)
            {
                var sp = db.Giay.Find(maSP);
                
                List<SanPhamTrongGio> cart = new List<SanPhamTrongGio>();
                cart.Add(new SanPhamTrongGio { giay = sp, soLuongTrongGio = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<SanPhamTrongGio> cart = (List<SanPhamTrongGio>)Session["cart"];
                int index = isExist(maSP);
                if (index != -1)
                {
                    cart[index].soLuongTrongGio++;
                }
                else
                {
                    var sp = db.Giay.Find(maSP);
                    cart.Add(new SanPhamTrongGio { giay = sp, soLuongTrongGio = 1 });
                }
                Session["cart"] = cart;
            }

            return RedirectToAction("Index");
        }

        // GET: GioHang/CapNhatTang/{maSP}
        public ActionResult CapNhatTang(int maSP)
        {
            List<SanPhamTrongGio> cart = (List<SanPhamTrongGio>)Session["cart"];
            foreach(var item in cart)
            {
                if (item.giay.ID == maSP && item.soLuongTrongGio <= 10)
                    item.soLuongTrongGio++;
            }
            Session["cart"] = cart;

            return RedirectToAction("Index");
        }

        // GET: GioHang/CapNhatGiam/{maSP}
        public ActionResult CapNhatGiam(int maSP)
        {
            List<SanPhamTrongGio> cart = (List<SanPhamTrongGio>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.giay.ID == maSP && item.soLuongTrongGio >= 1)
                    item.soLuongTrongGio--;
            }
            Session["cart"] = cart;

            return RedirectToAction("Index");
        }

        // GET: GioHang/XoaKhoiGio/{maSP}
        public ActionResult XoaKhoiGio(int maSP)
        {
            List<SanPhamTrongGio> cart = (List<SanPhamTrongGio>)Session["cart"];
            int index = isExist(maSP);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<SanPhamTrongGio> cart = (List<SanPhamTrongGio>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].giay.ID.Equals(id))
                    return i;
            return -1;
        }
    }
}
