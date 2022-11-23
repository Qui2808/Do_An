using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An.Models;

namespace Do_An.Controllers
{
    public class CategoriesController : Controller
    {
        TravelEntities1 database = new TravelEntities1();

        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryPartial()
        {
            var cateList = database.KhuVucs.ToList();
            return View(cateList);
        }
        public ActionResult ProductList(int id)
        {
            var listProduct = database.Infors.Where(n => n.IdKhuVuc == id).ToList();
            return View(listProduct);
        }
    }
}