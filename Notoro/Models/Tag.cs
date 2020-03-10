using System;
using System.Collections.Generic;

namespace Notoro.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Maybe use a join table instead ?
        public ICollection<NoteTag> NoteTags { get; set; }
    }
}