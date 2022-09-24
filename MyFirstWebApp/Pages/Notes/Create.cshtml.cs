using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstWebApp.Pages.Notes;
using NotesApp.Model;
using NotesApp.Repositories;

namespace NotesApp.Pages.Notes
{
    public class CreateModel : CategorySelectModel
    {

        private readonly NotesRepository _notesRepository;
        private readonly NotesContext _context;

        [BindProperty]
        public Note Note { get; set; }


        public CreateModel(NotesRepository notesRepository, NotesContext context)
        {
            _notesRepository = notesRepository;
            _context = context;
        }

        public IActionResult OnGet()
        {
            GenerateCategoriesDropDownList(_context);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            if (Note.Title == null && Note.CategoryId == 0)
            {
                return Page();
            }

            _notesRepository.CreateNote(Note);
            return RedirectToPage("Index");



   /*         var emptyNote = new Note();
            var tryUpdate = await TryUpdateModelAsync<Note>(emptyNote, "Note", s => s.Id, s => s.CategoryId, s => s.Title, s=> s.Content);

            if (tryUpdate)
            {
                _notesRepository.CreateNote(emptyNote);
                return RedirectToPage("Index");
            }

            return Page();*/
        }
    }
}
