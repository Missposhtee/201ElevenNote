﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteDetailModel
    {
     public int NoteId { get; set; }

     public string Title { get; set; }
        
     public string Content { get; set; }
       
     public DateTime CreatedUtc { get; set; }

     public DateTime? ModifiedUtc { get; set; }

    }
}
