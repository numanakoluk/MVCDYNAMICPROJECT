using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDYNAMICPROJECT.Models.Entity;

namespace MVCDYNAMICPROJECT.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var kategoriler = db.TBLKATEGORILER.ToList();

            return View(kategoriler);
        }
    }
}