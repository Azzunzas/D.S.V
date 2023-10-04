using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Controllers
{
    public class RestauranteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
