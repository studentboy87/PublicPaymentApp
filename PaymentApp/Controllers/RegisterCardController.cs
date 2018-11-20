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
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(CardPaymentViewModel model, bool confirmation = false)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ConfirmCardRegistration(bool confirmation)
        {
            return RedirectToAction("Index");
        }

        [HttpGet("registerCard")]
        public IActionResult RegisterCard()
        {
            return View();
        }
        [HttpPost("registerCard")]
        public IActionResult RegisterCard(CardPaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.UserMessage = "Done";
                ModelState.Clear();
            }
            return View();
        }




    }
}
