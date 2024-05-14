using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebMVCEDCCC.APICLients;
using WebMVCEDCCC.Models;

namespace WebMVCEDCCC.Controllers
{
    public class PaymentController : Controller
    {

        private readonly ILogger<PaymentController> _logger;
        private readonly EDCCCManagementAPI _api;

        public PaymentController(ILogger<PaymentController> logger, EDCCCManagementAPI api)
        {
            _logger = logger;
            _api = api;
        }

        public IActionResult Index(int id)
        {
            TempData["cCardId"] = id;
            return View();
        }


        public async Task<IActionResult> Payment(string desc, double paymentAmount, DateTime paymentDate)
        {
            Bills billModel = new Bills
            {
                cCardId = (int)TempData["cCardId"],
                description = desc,
                amount = (double)paymentAmount,
                date = paymentDate,
                transactionTypeId = 2
            };

            var result = await _api.SaveNewBill(billModel);

            if (result.StatusCode != null)
            {
                ViewBag.Message = "Pago por $" + paymentAmount + " registrado para Tarjeta " + TempData["cCardId"];
                ViewBag.Message2 = "Regitro realizado " + DateTime.Now;
            }
            else
            {
                ViewBag.Message = "Error al realizar el registro de pago, intente nuevamente";
                ViewBag.Message2 = "Regitro fallido " + DateTime.Now;
            }
            

            return View("Index", new { id = TempData["cCardId"]});
        }
    }
}
