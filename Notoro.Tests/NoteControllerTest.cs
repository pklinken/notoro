namespace Notoro.Tests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using Notoro.Controllers;
    using Notoro.Models;
    using Xunit;

    public class NoteControllerTest {
        [Fact]
        public void GetShouldReturnNoteWithCorrectModel()
            => MyMvc
                .Controller<NoteController>(instance =>
                    instance.WithData(
                        new Note { Title = "Not an empty title", Body ="My body is ready" }
                    ))
                .Calling(c => c.GetNote(1))
                .ShouldReturn()
                .Object(result => result
                    .WithModelOfType<Note>()
                    .Passing(model => model.Title.Equals("Not an empty title")));
    }
}