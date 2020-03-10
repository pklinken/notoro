using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notoro.Models;
using Notoro.Data;

namespace Notoro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase 
    {
        private readonly ILogger<NoteController> _logger;
        private readonly NotoroContext _context;
        public NoteController(ILogger<NoteController> logger, NotoroContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id) 
        {
            var note = await _context.Notes.FindAsync(id);
            if( note == null) {
                return NotFound();
            }
            
            return note;
        }

        
    }
}