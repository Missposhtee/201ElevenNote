using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
{
    //to make the log in pple access to it alone(it automatically allows those that are auntheticated alone)
    [Authorize]
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            //creating an instance of our noteservice
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new NoteService(userId);

            //creating an empty collection so we could view the page
            var model = svc . GetNotes();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new NoteCreateModel();
                return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new NoteService(userId);
            if (!svc.CreateNote(model))
            {
                ModelState.AddModelError("", "Unable to create note");
                return View(model);
            }

            return RedirectToAction("Index");
        }
       public ActionResult Details(int id)
            {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new NoteService(userId);
            var model = svc.GetNoteById(id);
            return View(model);
            }
        

    }
}