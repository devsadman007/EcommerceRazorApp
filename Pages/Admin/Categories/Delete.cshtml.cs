using EcommerceRazorApp.Models;
using EcommerceRazorApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EcommerceRazorApp.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = new();

        // GET: Load category to confirm delete
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var category = await _context.Categories
                                         .FirstOrDefaultAsync(c => c.CategoryId == id);

            if (category == null)
                return NotFound();

            Category = category;
            return Page();
        }

        // POST: Actually delete
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Category deleted successfully!";
            return RedirectToPage("Index");
        }
    }
}