using EcommerceRazorApp.Models;
using EcommerceRazorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceRazorApp.Pages.Admin.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _service;

        public DetailsModel(IProductService service)
        {
            _service = service;
        }

        public Product? Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _service.GetProductByIdAsync(id);

            if (Product == null)
                return NotFound();

            return Page();
        }
    }
}