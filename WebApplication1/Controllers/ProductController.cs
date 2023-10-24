using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        CNPMNC_ltEntities db = new CNPMNC_ltEntities();

        // GET: Product
        public ActionResult Index(int id)
        {
            var product = db.SanPham.Find(id);
            return View(product);
        }
    }
}