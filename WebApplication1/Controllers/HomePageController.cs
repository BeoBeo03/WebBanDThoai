using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();
        public ActionResult Index(string SearchString)
        {
            IQueryable<SanPham> products = db.SanPham; // db.SanPham có kiểu DbSet

            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(p => p.TenSP.Contains(SearchString));
            }

            return View(products.ToList());

        }
        public ActionResult GioiThieu()
        {
            return View();
        }

       

    }
}