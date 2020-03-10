using System;
using System.Collections.Generic;

namespace Notoro.Models
{
    public class NoteTag
    {
        public int NoteID { get; set; }
        public int TagID { get; set; }

        public Note Note { get; set; }
        public Tag Tag { get; set; }
    }
}