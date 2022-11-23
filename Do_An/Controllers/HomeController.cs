using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Do_An.Models;

namespace Do_An.Controllers
{
    public class HomeController : Controller
    {
        private TravelEntities1 tdb = new TravelEntities1(); 

        public ActionResult Content()
        {
            var trangchu = tdb.Infors;
                          
            return View(trangchu.ToList().Take(6));
        }

        public ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult TinTuc()
        {
            return View();
        }
    }
}