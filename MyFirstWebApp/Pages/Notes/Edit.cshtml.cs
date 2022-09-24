using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model;
using NotesApp.Repositories;

namespace MyFirstWebApp.Pages.Notes
{
    public class EditModel : CategorySelectModel
    {
        private readonly NotesRepository _notesRepository;
        private readonly NotesContext _context;

        public EditModel(NotesRepository notesRepository, NotesContext context)
        {
            _notesRepository = notesRepository;
            _context = context;
        }

        [BindProperty]
        public Note Note { get; set; }
        public void OnGet(int id)
        {
            Note = _notesRepository.GetNote(id);
            GenerateCategoriesDropDownList(_context);
        }

        public async Task<IActionResult> OnPost()
        {
            //            if (!ModelState.IsValid)
            //          {
            //            return Page();
            //      }

            if (Note.Title == null || Note.CategoryId == 0)
            {
                return Page();
            }

            var noteFromDb = _notesRepository.GetNote(Note.Id);

            noteFromDb.CategoryId = Note.CategoryId;
            noteFromDb.Title = Note.Title;
            noteFromDb.Content = Note.Content;

            _notesRepository.UpdateNote(noteFromDb);
            return RedirectToPage("Index");

            /*
               var tryUpdate = await TryUpdateModelAsync<Note>(noteFromDb, "note", s => s.Id, s => s.CategoryId, s => s.Title, s => s.Content);

               if (tryUpdate)
               {
                   _notesRepository.UpdateNote(noteFromDb);
                   return RedirectToPage("Index");
               }
               GenerateCategoriesDropDownList(_context,noteFromDb.CategoryId);
               return Page();
           }
   */
        }
    }
}
