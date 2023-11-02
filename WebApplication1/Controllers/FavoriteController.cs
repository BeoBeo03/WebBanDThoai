using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FavoriteController : Controller
    {
        // GET: Favorite
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();
        
        public ActionResult Index()
        {
            // Lấy danh sách sản phẩm đã được yêu thíchA từ cơ sở dữ liệu
            if (Session["TaiKhoan"] != null)
            {
                var userID = (KhachHang)Session["TaiKhoan"];
                // Lấy danh sách sản phẩm yêu thích của người dùng và trả về view.
                var danhSachYeuThich = db.YeuThich.Where(yt => yt.IDUser == userID.IDUser).ToList();
                return View(danhSachYeuThich);
            }
            else
            {
                return RedirectToAction("Login", "LoginRegister");
            }
        }
       
        public ActionResult ThemMucYeuThich(int IDSanPham)
        {
            if (Session["TaiKhoan"] != null)
            {
                var khachHang = (KhachHang)Session["TaiKhoan"];
                // Tìm sản phẩm dựa trên IDSanPham
                var sanPham = db.SanPham.FirstOrDefault(sp => sp.IDSanpham == IDSanPham);
                
                // Kiểm tra xem sản phẩm có tồn tại không
                
                if (sanPham != null)
                {
                    // Kiểm tra xem sản phẩm đã tồn tại trong danh sách yêu thích của khách hàng chưa
                    var yeuThich = db.YeuThich.FirstOrDefault(yt => yt.IDSanPham == IDSanPham && yt.IDUser == khachHang.IDUser && yt.NgayThem== DateTime.Now
                    );

                    if (yeuThich == null)
                    {
                        var maxIDYeuThich = db.YeuThich.Max(yt => (int?)yt.IDYeuThich) ?? 0;
                        var newIDYeuThich = maxIDYeuThich + 1;
                        // Nếu sản phẩm chưa tồn tại trong danh sách yêu thích, thêm nó vào
                        var yeuThichMoi = new YeuThich
                        {
                            IDSanPham = IDSanPham,
                            IDUser = khachHang.IDUser,
                            NgayThem = DateTime.Now,
                            IDYeuThich = newIDYeuThich

                        };

                        db.YeuThich.Add(yeuThichMoi);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Favorite");
                    }
                }
                
            }
            else
            {
                return RedirectToAction("Login", "LoginRegister");
            }
            return RedirectToAction("Index","Favorite");
        }
        [HttpPost]
        public ActionResult XoaYeuThich(int IDSanPham)
        {
            // Tìm bản ghi yêu thích theo ID sản phẩm và thực hiện xóa
            // Tìm bản ghi yêu thích theo ID sản phẩm và thực hiện xóa
            if (Session["TaiKhoan"] != null)
            {
                var kh = (KhachHang)Session["TaiKhoan"];
                var yeuThich = db.YeuThich.FirstOrDefault(y => y.IDSanPham == IDSanPham && y.IDUser == kh.IDUser);
                if (yeuThich != null)
                {
                    db.YeuThich.Remove(yeuThich);
                    db.SaveChanges();
                }
                var favoriteProducts = db.YeuThich.Where(y => y.IDUser == kh.IDUser).ToList(); ;
                return View("Index", favoriteProducts);
            }
            else
            {
                return RedirectToAction("Login", "LoginRegister");
            }
        }
    }
}