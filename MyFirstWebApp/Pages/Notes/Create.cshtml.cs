using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model;

namespace NotesApp.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly NotesContext _context;

        [BindProperty]
        public Note Book { get; set; }

        public CreateModel(NotesContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Add(Book);
                _context.SaveChanges();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
