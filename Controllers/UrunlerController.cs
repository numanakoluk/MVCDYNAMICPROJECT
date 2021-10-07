using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDYNAMICPROJECT.Models.Entity;

namespace MVCDYNAMICPROJECT.Controllers
{
    public class UrunlerController : Controller
    {

        // GET: Urunler
        MvcDbStokEntities db = new MvcDbStokEntities();

        public ActionResult Index()
        {
            var urunler = db.TBLURUNLER.ToList();
               
            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p1)
        {
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}