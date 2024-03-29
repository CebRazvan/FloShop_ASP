using FlorarieOnline.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlorarieOnline.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ShopDbContext shopDbContext;
        public CatalogController(ShopDbContext context)
        {
            shopDbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await shopDbContext.Produs.ToListAsync());
        }
    }
}
