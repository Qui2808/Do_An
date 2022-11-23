using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An.Models;
using System.Net;

namespace Do_An.Controllers
{
    public class ProductController : Controller
    {
        TravelEntities1 db = new TravelEntities1();
        // GET: Product
        public ActionResult Index()
        {
            var product = db.Infors;
            return View(product.ToList());
        }
        public ActionResult ChiTietProduct(int id)
        {
            var chitiet = db.Infors.FirstOrDefault(l => l.Id == id);
            return View(chitiet);
        }
    }
}