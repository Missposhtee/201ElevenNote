using ElevenNote.Models;
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
            //creating an empty collection so we could view the page
            var model = Enumerable.Empty<NoteListItemModel>();
            return View(model);
        }
    }
}