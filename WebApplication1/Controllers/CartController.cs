using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();
        public ActionResult Index()
        {
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("Login", "LoginRegister");
            }
            else
            {

                Cart cart = Session["Cart"] as Cart;
                if (cart == null || cart.Total_quantity() == 0)
                    return RedirectToAction("EmptyCart", "Cart");
                return View(cart);

            }
        }
        public ActionResult AddToCart(int id)
        {
            var _spham = db.SanPham.SingleOrDefault(s => s.IDSanpham == id);
            if (_spham != null)
            {
                GetCart().AddtoCart(_spham);  
            }
            return RedirectToAction("Index", "Cart");
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult UpdateCartQua(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_sp = int.Parse(Request.Form["idPro"]);
            int new_quantity = int.Parse(Request.Form["cartQuantity"]);
            cart.UpdateNewQuantity(id_sp, new_quantity);
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;

            cart.Remove_CartItem(id);
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult OrderDetail()
        {
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("Login", "LoginRegister");
            }
            else
            {
                if (Session["Cart"] == null)
                    return View("Index");
                Cart cart = Session["Cart"] as Cart;
                return View(cart);
            }

        }
        public ActionResult DongYDatHang(FormCollection form)
        {
            if (form != null)
            {
                String ten = Request.Form["hoten"].ToString();
                String diachi = Request.Form["diachigiao"].ToString();
                if (ten == "")
                {
                    TempData["loiten"] = "Vui lòng nhập tên!";
                    return RedirectToAction("OrderDetail", "Cart");
                }
                if (diachi == "")
                {
                    TempData["loidiachi"] = "Vui lòng nhập đại chỉ!";
                    return RedirectToAction("OrderDetail", "Cart");
                }
                
                KhachHang user = Session["TaiKhoan"] as KhachHang;
                Cart cart = Session["Cart"] as Cart;
                DonHang _order = new DonHang();
                _order.Ten = ten;
                _order.IDUser = user.IDUser;
                _order.DCGiao = diachi;
                _order.TinhTrang = "Chưa duyệt";

                _order.TongSoLuong = cart.Total_quantity();
                _order.NgayBan = DateTime.Now;
                _order.TongThanhTien = (decimal)cart.Total_money();
                // Lấy số tiền khách hàng nhập vào từ form

                // Tính tiền thối



                db.DonHang.Add(_order);
                db.SaveChanges();

                foreach (var item in cart.Items)
                {
                    // lưu dòng sản phẩm vào chi tiết hóa đơn
                    CTDonHang _order_detail = new CTDonHang();
                    _order_detail.IDDonHang = _order.IDDonHang;
                    _order_detail.IDSanpham = item._sanpham.IDSanpham;

                    _order_detail.TenSP = item._sanpham.TenSP;
                    _order_detail.Soluong = item._soluong;
                    _order_detail.GiaTien = item._sanpham.GiaSP;
                    _order_detail.ThanhTien = item._soluong * item._sanpham.GiaSP;
                    var product = db.SanPham.Find(item._sanpham.IDSanpham);
                    if (product != null)
                    {
                        product.TongSoLuong -= item._soluong;

                        if (product.TongSoLuong == 0 || product.TongSoLuong < 0)
                        {
                            product.TongSoLuong = 0;
                        }
                    }
                    db.CTDonHang.Add(_order_detail);
                    //Số lượng tồn khi đặt mua hàng sẽ trừ vào tổng số lượng
                    db.SaveChanges();


                }


                cart.ClearCart();

                return RedirectToAction("CheckOut_Success", "Cart");
            }
            else
            {
                return Content("Có sai sót! Xin kiểm tra lại thông tin");

            }
        }
        public ActionResult CheckOut_Success()
        {
            return View();
        }
        public ActionResult EmptyCart()
        {
            ViewBag.EmptyNotification = "Chưa có sản phẩm nào trong giỏ hàng";
            return View();
        }
    }
}