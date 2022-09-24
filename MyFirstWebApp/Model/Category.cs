using NotesApp.Model;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApp.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name="Category")]
        public string Name { get; set; }
        public List<Note> Notes { get; set; }
    }
}
