using EcommerceRazorApp.Models;
using EcommerceRazorApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceRazorApp.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _service;

        public IndexModel(IProductService service)
        {
            _service = service;
        }

        public List<Category> Categories { get; set; } = new();

        public async Task OnGetAsync()
        {
            Categories = await _service.GetAllCategoriesAsync();
        }
    }
}