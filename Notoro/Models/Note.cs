using System;
using System.Collections.Generic;

namespace Notoro.Models
{
    public class Note
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public ICollection<NoteTag> NoteTags { get; set; }
    }
}