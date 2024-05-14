using Microsoft.AspNetCore.Mvc;

namespace ViewEDC.Controllers
{
    public class HomeController : Controller
    {

        private HttpClient _httpClient;

        public IActionResult Index()
        {

            return View();
        }
    }
}
