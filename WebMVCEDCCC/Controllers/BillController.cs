using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebMVCEDCCC.APICLients;
using WebMVCEDCCC.Models;

namespace WebMVCEDCCC.Controllers
{
    public class BillController : Controller
    {

        private readonly ILogger<BillController> _logger;
        private readonly EDCCCManagementAPI _api;

        public BillController(ILogger<BillController> logger, EDCCCManagementAPI api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task<IActionResult> Index(int Id)
        {
            var result = await _api.GetBills(Id);
            var bills = JsonSerializer.Deserialize<List<Bills>>(result);
            return View(bills);
        }
    }
}
