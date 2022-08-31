using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp.Model;

namespace NotesApp.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly NotesContext _context;
        public List<Note> Notes { get; set; }

        public IndexModel(NotesContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Notes = _context.Notes.ToList();
        }
    }
}
