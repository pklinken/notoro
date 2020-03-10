using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notoro.Models;
using Notoro.Data;

namespace Notoro.Data
{
    public class DbInitializer
    {
        public static void Initialize(NotoroContext context)
        {
            context.Database.EnsureCreated();

            if (context.Notes.Any())
            {
                return;   // DB has been seeded
            }

            var notes = new Note[]
            {
                new Note{ Title="Not an empty title", Body="My body is ready."},
                new Note{ Title="", Body="This is a slightly longer body than the other note."}
            };
            foreach (Note n in notes) {
                context.Notes.Add(n);
            }
            context.SaveChanges();

            var tags = new Tag[]
            {
                new Tag{ Name="todo"},
                new Tag{ Name="note"},
                new Tag{ Name="work"},
            };
            foreach (var t in tags) {
                context.Tags.Add(t);
            }
            context.SaveChanges();

            var noteTags = new NoteTag[]
            {
                new NoteTag{ NoteID=context.Notes.First().ID, TagID=context.Tags.First().ID },
                new NoteTag{ NoteID=context.Notes.First().ID, TagID=context.Tags.Skip(1).First().ID },
                new NoteTag{ NoteID=context.Notes.Skip(1).First().ID, TagID=context.Tags.Skip(2).First().ID }
            };
            foreach (var nt in noteTags) {
                context.NoteTags.Add(nt);
            }

            context.SaveChanges();

        }
    }
}
