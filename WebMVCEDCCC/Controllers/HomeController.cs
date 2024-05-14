using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using WebMVCEDCCC.APICLients;
using WebMVCEDCCC.Models;

namespace WebMVCEDCCC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EDCCCManagementAPI _api;

        public HomeController(ILogger<HomeController> logger, EDCCCManagementAPI api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _api.GetCCards();
            var ccards = JsonSerializer.Deserialize<List<CCard>>(result);
            var newCC = (from cc in ccards select new CCard() {id = cc.id,cNumber = Numero(cc.cNumber), dueDate= cc.dueDate, limit= cc.limit }).ToList();

            return View(newCC);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public static string Numero(string CNumber)
        {
            var Num = new string(CNumber.Reverse().Take(4).Reverse().ToArray());
            string actual = "**** **** **** " + Num;
            return actual;
        }
    }
}
