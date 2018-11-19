using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.ViewModels;

namespace PaymentApp.Controllers
{
    public class RegisterCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CardPaymentViewModel model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(CardPaymentViewModel model, bool confirmation = false)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ConfirmCardRegistration(bool confirmation)
        {
            return RedirectToAction("Index");
        }
    }
}
