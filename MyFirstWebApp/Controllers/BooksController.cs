using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Model;
using NotesApp.Repositories;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesRepository _notesRepository;

        public NotesController(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }
        // get api/books
        [HttpGet]
        public List<Note> GetNotes()
        {
            return _notesRepository.GetNotes();

        }

        //get api/books/id
        [HttpGet("{id}")]
        public Note GetNote(int id)
        {
            return _notesRepository.GetNote(id);
        }

        [HttpPost]
        public ActionResult CreateNotes([FromBody]Note book)
        {
            _notesRepository.CreateNote(book);
            return Ok();
           // return CreatedAtAction(nameof(book), book);
        }

        [HttpDelete]
        public ActionResult DeleteNote([FromQuery]int id)
        {
            _notesRepository.DeleteNote(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateNote([FromBody] Note book)
        {
            _notesRepository.UpdateNote(book);
            return Ok();
        }
    }
}
