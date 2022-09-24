using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NotesApp.Model;

namespace MyFirstWebApp.Pages.Notes
{
    public class CategorySelectModel : PageModel
    {
        public SelectList CategoryNames { get; set; }

        public void GenerateCategoriesDropDownList(NotesContext context, object selectedCategory = null)
        {
            var categoriesQuery = context.Categories.OrderBy(a => a.Name);

            CategoryNames = new SelectList(categoriesQuery, "Id", "Name", selectedCategory);
        }
    }
}
