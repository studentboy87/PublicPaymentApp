using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.Data;
using PaymentApp.ViewModels;

namespace PaymentApp.Controllers
{
    public class RegisterCardController : Controller
    {
        private readonly RegisterCardContext _context;
        public RegisterCardController(RegisterCardContext context)
        {
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Index(CardPaymentViewModel model)
        //{
        //    return View(model);
        //}


        //on load
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
                ModelState.Clear();
            }
            else
            {
                return View();
            }
            return View();
        }

        //[HttpPost]
        //public IActionResult Register(CardPaymentViewModel model, bool confirmation = false)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    else
        //    {

        //    }
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public IActionResult ConfirmCardRegistration(bool confirmation)
        //{
        //    return RedirectToAction("Index");
        //}



        //[HttpPost]
        //public IActionResult ConfirmCardRegistration(CardPaymentViewModel model)
        // {
        //    return PartialView("_ConfirmCardDetails", model);
        //}




    }
}
