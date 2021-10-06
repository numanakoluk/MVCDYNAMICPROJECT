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
    }
}