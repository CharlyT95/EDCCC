using Microsoft.AspNetCore.Mvc;
using WebMVCEDCCC.APICLients;
using WebMVCEDCCC.Models;

namespace WebMVCEDCCC.Controllers
{
    public class PurchaseController : Controller
    {

        private readonly ILogger<PurchaseController> _logger;
        private readonly EDCCCManagementAPI _api;

        public PurchaseController(ILogger<PurchaseController> logger, EDCCCManagementAPI api)
        {
            _logger = logger;
            _api = api;
        }

        public IActionResult Index(int id)
        {
            TempData["cCardId"] = id;
            return View();
        }


        public async Task<IActionResult> Purchase(string descp, double purchaseAmount, DateTime purchaseDate)
        {
            Bills billModel = new Bills
            {
                cCardId = (int)TempData["cCardId"],
                description = descp,
                amount = (double)purchaseAmount,
                date = purchaseDate,
                transactionTypeId = 1
            };

            var result = await _api.SaveNewBill(billModel);

            if (result.StatusCode != null)
            {
                ViewBag.Message = "Compra por $" + purchaseAmount + " registrado para Tarjeta " + TempData["cCardId"];
                ViewBag.Message2 = "Regitro realizado " + DateTime.Now;
            }
            else
            {
                ViewBag.Message = "Error al realizar el registro de la compra, intente nuevamente";
                ViewBag.Message2 = "Regitro fallido " + DateTime.Now;
            }



            return View("Index", new { id = TempData["cCardId"] });
        }
    }
}
