using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model;
using NotesApp.Repositories;

namespace NotesApp.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly NotesRepository _notesRepository;

        public List<Note> Notes { get; set; }

        public IndexModel(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public void OnGet()
        {
            Notes = _notesRepository.GetNotes();
        }

        public IActionResult OnPostDelete(int id)
        {
            var note = _notesRepository.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }
            _notesRepository.DeleteNote(id);
            return RedirectToPage("Index");
        }
    }
}
