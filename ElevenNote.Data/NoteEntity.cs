using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    //attributes for table to be created by entity frame work
    [Table("Note")]
    public class NoteEntity
    {
        //its sets up the column (identity column)
        [Key]

        //field or variable that can be accessed from another place...get set(attributes) is to access the modified value

        //Id of the note(to know the particular note in the data base uniquely
         public int NoteId { get; set; }
        [Required]

        //data that we need to represent a note within the system/data base
         public Guid OwnerId { get; set; }
        [Required]

        //title of the note
        public string Title { get; set; }
        [MaxLength(500)]

        //what goes into the note (body of the note)
        public string Content { get; set; }
        [Required]

        //creation date (always store ur date in utc)incase the user changes time zone
        public DateTime CreatedUtc { get; set; }

        //when it was last modified;thequestionmark means wrapping a datetime in another type that allows null
        public DateTime? ModifiedUtc { get; set; }
    }
}
