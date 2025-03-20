using LibraryMS.Models;
using LibraryMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMS.Controllers
{
    public class BooksController : Controller
    {
        BookRepo bookrp = new BookRepo();
        // GET: Books
        public ActionResult Index()
        {
            var list = bookrp.GetAllBooks();
            return View(list);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(Books book)
        {
            if (ModelState.IsValid)
            {
                bookrp.CreateBook(book);
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName("Edit")]
        public ActionResult EditBook(int Id)
        {
            var b = bookrp.Find(Id);
            return View(b);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditBook(Books book)
        {
            if (ModelState.IsValid)
            {
                bookrp.UpdateBook(book);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            var b = bookrp.Find(Id);
            return View(b);
        }

        [HttpPost]
        public ActionResult Delete(Books book)
        {
            if (ModelState.IsValid)
            {
                bookrp.DeleteBook(book);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int Id)
        {
            var b = bookrp.Find(Id);
            return View(b);
        }

    }
}