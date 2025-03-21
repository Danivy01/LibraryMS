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

        public ActionResult DeleteRent()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DeleteRent(Rental rent)
        {
            if (ModelState.IsValid)
            {
                rentalRp.DeleteRent(rent);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult UpdateRent()
        {

            return View();
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
    }
}