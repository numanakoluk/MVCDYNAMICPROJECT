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
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORI.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORI == p1.TBLKATEGORILER.KATEGORI).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SIL(int id)
        {
            var URUNLER = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(URUNLER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORI.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;


            return View("UrunGetir", urun);

        }
        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
            //urun.URUNKATEGORI = p.URUNKATEGORI;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}