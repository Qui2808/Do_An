using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An.Models;

namespace Do_An.Controllers
{
    public class UserController : Controller
    {
        private TravelEntities1 db = new TravelEntities1();
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.Ho))
                    ModelState.AddModelError(string.Empty, "Không được để trống");
                if (string.IsNullOrEmpty(cust.Ten))
                    ModelState.AddModelError(string.Empty, "Tên không được để trống");
                if (string.IsNullOrEmpty(cust.MatKhau))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (string.IsNullOrEmpty(cust.Email))
                    ModelState.AddModelError(string.Empty, "Email không được để trống");
                if (string.IsNullOrEmpty(cust.Sdt))
                    ModelState.AddModelError(string.Empty, "Điện thoại không được để trống");
                var khachhang = db.Customers.FirstOrDefault(k => k.Email == cust.Email);
                if (khachhang != null)
                    ModelState.AddModelError(string.Empty, "Đã có người đăng kí tên này");
                if (ModelState.IsValid)
                {
                    db.Customers.Add(cust);
                    db.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Login");
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cust.Email))
                    ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng");
                if (string.IsNullOrEmpty(cust.MatKhau))
                    ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng");
                if (ModelState.IsValid)
                {
                    //Tìm khách hàng có tên đăng nhập và password hợp lệ trong CSDL
                    var khachhang = db.Customers.FirstOrDefault(k => k.Email == cust.Email && k.MatKhau == cust.MatKhau);
                    if (khachhang != null)
                    {
                        ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                        //lưu vào session
                        Session["TaiKhoan"] = khachhang;
                        return RedirectToAction("Content", "Home");
                    }
                    else
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Content", "Home");
        }

    }  
    
}