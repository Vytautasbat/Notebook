using Microsoft.EntityFrameworkCore;
using NotesApp.Model;

namespace NotesApp.Repositories
{
    public class NotesRepository
    {
        private readonly NotesContext _context;

        public NotesRepository(NotesContext context)
        {
            _context = context;
        }

        public List<Note> GetNotes()
        {
            return _context.Notes.ToList();
        }

        public Note GetNote(int id)
        {
            return _context.Notes.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteNote(int id)
        {
            var note = _context.Notes.FirstOrDefault(b => b.Id == id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();

            }
        }

        public void UpdateNote(Note note)
        {          
            _context.Entry(note).State = EntityState.Modified;
            _context.SaveChanges();
           
        }

        public void CreateNote(Note note)
        {
            _context.Add(note);
            _context.SaveChanges();
        }

        
    }
}
