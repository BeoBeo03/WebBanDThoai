using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginRegisterController : Controller
    {
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();
        // GET: LoginRegister
        
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(KhachHang cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.Email))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(cust.MatKhau))
                    ModelState.AddModelError(string.Empty, "Họ và tên không được để trống");
                if (string.IsNullOrEmpty(cust.MatKhau))
                    ModelState.AddModelError(string.Empty, "Địa chỉ không được để trống");
                if (string.IsNullOrEmpty(cust.GioiTinh))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");
                if (string.IsNullOrEmpty(cust.TenKH))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");
               

                //Kiểm tra xem có người nào đã đăng kí với tên đăng nhậpnày hay chưa
                var khachhang = db.KhachHang.FirstOrDefault(k => k.Email == cust.Email);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người đăng ký");


                if (ModelState.IsValid)
                {
                    //cust.phanquyen=2;
                    db.KhachHang.Add(cust);
                    db.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.Email))
                    ModelState.AddModelError(string.Empty, "Email  không được để trống");
                if (string.IsNullOrEmpty(kh.MatKhau))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    if (kh.Email == "admin@gmail.com" && kh.MatKhau == "123")
                    {
                        ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                        Session["TaiKhoanAdmin"] = "Admin";
                        return RedirectToAction("Index", "Admin");

                    }
                    else
                    {
                        var khachhang = db.KhachHang.FirstOrDefault(k => k.Email == kh.Email && k.MatKhau == kh.MatKhau);
                        if (khachhang != null)
                        {
                            ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                            Session["TaiKhoan"] = khachhang;
                            return RedirectToAction("Index", "HomePage");
                        }
                        else
                        {
                            ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                            ModelState.AddModelError("", "Sai mật khẩu!");
                            
                        }
                        return RedirectToAction("Login", "LoginRegister");
                    }
                }
            }
            return RedirectToAction("Index", "HomePage");


        }
        public ActionResult LogOut()
        {
            Session["Taikhoan"] = null;
            return Redirect("/");
        }
    }
}