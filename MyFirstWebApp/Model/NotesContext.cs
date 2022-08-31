using Microsoft.EntityFrameworkCore;

namespace NotesApp.Model
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions<NotesContext> options) : base(options) 
        {
                  
        }
        public DbSet<Note> Notes { get; set; }

        public DbSet<Author> Authors { get; set; }

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        optionsBuilder.UseSqlServer("Server=localhost;Database=AspNetBooks;Trusted_Connection=true");
        //    }

    }
}
