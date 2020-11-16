using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Shoes_Store3.Models;

namespace Shoes_Store3.Controllers
{
    public class HomeController : Controller
    {
        ShoesContext db = new ShoesContext();

        public ActionResult Index()
        {
            var shoes = db.Shoes.Include(b=>b.Firma);
            return View(shoes.ToList()); //отправляем список книг в представление
        }

        [HttpGet]
        public ActionResult Create()
        {
            // Формируем список авторов для передачи в представление
            SelectList firma = new SelectList(db.Firmas, "Id", "Firma_name");
            ViewBag.Firma = firma;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Shoes shoes)
        {
            //Добавляем книгу в таблицу
            db.Shoes.Add(shoes);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            Shoes shoes = db.Shoes.Find(id);
            if (shoes != null)
            {

                SelectList firma = new SelectList(db.Firmas, "Id", "Firma_name",
                shoes.FirmaId);
                ViewBag.Firma = firma;
                return View(shoes);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Shoes shoes)
        {
            db.Entry(shoes).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var shoes = db.Shoes.Include(c => c.Firma).Where(a => a.Id == id).First();
            ViewBag.Firma = shoes;
            if (shoes != null)
            {
                return View(shoes);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
 
            Shoes shoes = db.Shoes.Find(id);
            if (shoes != null)
            {
                db.Shoes.Remove(shoes);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}