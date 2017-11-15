using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    //this is for our user while the first one is for the data base
    
    public class NoteListItemModel
    {
        public NoteListItemModel(
            int noteId,
            string title,
            DateTime createdUtc,
            DateTime? modifiedUtc)
        {
            NoteId = noteId;
            Title = title;
            CreatedUtc = createdUtc;
            ModifiedUtc = modifiedUtc;
        }
        //setting it to get means readonly mode
        public int NoteId { get; }

        public string Title { get; }

        public DateTime CreatedUtc { get; }

        public DateTime? ModifiedUtc { get; }
    }
}
