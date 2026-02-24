using EcommerceRazorApp.Models;
using EcommerceRazorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceRazorApp.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _service;

        public IndexModel(IProductService service)
        {
            _service = service;
        }

        public List<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _service.GetAllProductsAsync();
        }
    }
}