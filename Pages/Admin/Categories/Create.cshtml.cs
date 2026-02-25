using EcommerceRazorApp.Models;
using EcommerceRazorApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceRazorApp.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Category created successfully!";
            return RedirectToPage("Index");
        }
    }
}