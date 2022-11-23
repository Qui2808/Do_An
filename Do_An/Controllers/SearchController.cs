using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An.Models;

namespace Do_An.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        TravelEntities1 db = new TravelEntities1();

        [HttpPost]
        public ActionResult KetQuaTimKiem(string txtTimKiem = "")
        {        
            List<Infor> listKQTK = db.Infors.Where(n => n.Name.Contains(txtTimKiem)).ToList();    
            if (listKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả phù hợp";
            }
            return View(listKQTK.OrderBy(n => n.Name));
        }
       
    }
}