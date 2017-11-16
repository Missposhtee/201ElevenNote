using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    //this is for our user while the first one is for the data base
    
    public class NoteListItemModel
    {

        //setting it to get means readonly mode
        public int NoteId { get; set; }

        public string Title { get; set; }
       
        [UIHint("Starred")]
        public bool IsStared { get; set; }

        public DateTime CreatedUtc { get; set; }

        public DateTime? ModifiedUtc { get; set; }
    }
}
