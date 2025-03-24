using LibraryMS.Models;
using LibraryMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMS.Controllers
{
    public class HomeController : Controller
    {
        RentalRepo rentalRp = new RentalRepo();
        // GET: Rentals
        public ActionResult Index()
        {
            var list = rentalRp.GetAllRental();
            return View(list);
        }

        public ActionResult CreateRental()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateRental(Rental rent)
        {
            if (ModelState.IsValid)
            {
                rentalRp.CreateRental(rent);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeleteRent(int Id)
        {
            var item = rentalRp.Find(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult DeleteRent(RentalModelView rent)
        {
            if (ModelState.IsValid)
            {
                rentalRp.DeleteRent(new Rental { Id = rent.Id });
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateRent(int Id)
        {
            var item = rentalRp.Find(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult UpdateRent(Rental rent)
        {
            if (ModelState.IsValid)
            {
                rentalRp.UpdateRent(rent);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int Id)
        {
            var item = rentalRp.Find(Id);
            return View(item);
        }
    }
}