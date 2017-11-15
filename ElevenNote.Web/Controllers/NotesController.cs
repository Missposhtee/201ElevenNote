using ElevenNote.Models;
using ElevenNote.Services;
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
           var svc = new NoteService();

            //creating an empty collection so we could view the page
            var model = svc . GetNotes();
            return View(model);
        }
    }
}