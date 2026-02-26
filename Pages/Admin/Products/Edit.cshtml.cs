using EcommerceRazorApp.Data;
using EcommerceRazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EcommerceRazorApp.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = new();

        public List<Category> Categories { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _context.Products
                        .FirstOrDefaultAsync(p => p.ProductId == id);

            if (Product == null)
                return NotFound();

            Categories = await _context.Categories.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Categories = await _context.Categories.ToListAsync();

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return Page();
            }

            Console.WriteLine("MODEL VALID");

            var productFromDb = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == Product.ProductId);

            if (productFromDb == null)
                return NotFound();

            productFromDb.Name = Product.Name;
            productFromDb.Price = Product.Price;
            productFromDb.CategoryId = Product.CategoryId;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Product updated successfully!";
            return RedirectToPage("Index");
        }
    }
}