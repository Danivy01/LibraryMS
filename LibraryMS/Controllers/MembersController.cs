using LibraryMS.Models;
using LibraryMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMS.Controllers
{
    public class MembersController : Controller
    {
        MembersRepo memberRp = new MembersRepo();
        
        // GET: Members
        public ActionResult Index()
        {
            var list = memberRp.GetAllMembers();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Members member)
        {
            if (ModelState.IsValid)
            {
                memberRp.CreateMember(member);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var item = memberRp.Find(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Members member)
        {
            if (ModelState.IsValid)
            {
                memberRp.UpdateMember(member);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            var item = memberRp.Find(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Delete(MemberDeleteModelView member)
        {
            if (ModelState.IsValid)
            {
                memberRp.DeleteMember(new Members {Id = member.Id });
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public ActionResult Details(int Id)
        {
            var item = memberRp.Find(Id);
            return View(item);
        }


    }
}