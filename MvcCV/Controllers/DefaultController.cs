using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities db=new DbCVEntities();
        public ActionResult Index()
        {
            var degerler=db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        } 
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifikalar =db.TblSertifikalarim.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet] //sayfa yüklenince burası çalışacak
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost] // butona tıklanınca burası çalışacak- attribute
        public PartialViewResult iletisim(Tbliletisim t) //tbliletiism sınıfında t isimli parametre ürettim
        {
            t.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString()); //bugünün kısa tarihini alsın
            db.Tbliletisim.Add(t);  //tden gelen değerleri buraya ekle
            db.SaveChanges();
            return PartialView();
        }
    }
}