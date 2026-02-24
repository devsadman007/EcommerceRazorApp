using EcommerceRazorApp.Data;
using EcommerceRazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceRazorApp.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public List<Category> Categories { get; set; }

        public void OnGet()
        {
            Categories = _context.Categories.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}