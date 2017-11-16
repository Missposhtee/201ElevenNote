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
        private NoteService CreateNoteService()
        {
            //creating an instance of our noteservice
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new NoteService(userId);

            return svc;
        }
        // GET: Notes
        public ActionResult Index()
        {
            //creating an empty collection so we could view the page
            var model = CreateNoteService().GetNotes();
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

            if (!CreateNoteService().CreateNote(model))
            {
                ModelState.AddModelError("", "Unable to create note");
                return View(model);
            }

            return RedirectToAction("Index");
        }
       public ActionResult Details(int id)
            {
            var model = CreateNoteService().GetNoteById(id);
            return View(model);
            }
           
        public ActionResult Edit(int id)
        {
            var detailModel = CreateNoteService().GetNoteById(id);
            var editModel =
                new NoteEditModel
                {
                    NoteId = detailModel.NoteId,
                    Title = detailModel.Title,
                    Content = detailModel.Content,
                };
            return View(editModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( int id,NoteEditModel model)
        {
            if (model.NoteId != id)
            {
                ModelState.AddModelError("", "Nice try");
                model.NoteId = id;
                return View(model);
            }

            if (!ModelState.IsValid) return View(model);

            if (!CreateNoteService().UpdateNote(model))
            {
                ModelState.AddModelError("", "unable to update note");
            }
            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
       public ActionResult DeleteGet(int id)
        {
            var model = CreateNoteService().GetNoteById(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            CreateNoteService().DeleteNote(id);
            return RedirectToAction("index");
        }
    }
}