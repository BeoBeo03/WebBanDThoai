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
            
                var products = db.SanPham.ToList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(p => p.TenSP.Contains(SearchString)).ToList();
            }
            return View(products);

        }
        public ActionResult GioiThieu()
        {
            return View();
        }

       

    }
}