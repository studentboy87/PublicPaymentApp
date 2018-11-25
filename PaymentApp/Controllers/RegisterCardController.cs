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
                //to test
                if (!LuhnCheck(model.CardNumberString) || !CardExpiryDateIsValid(model.ExpiryDate))
                {
                    return View();
                }

                                //to test
               







                ModelState.Clear();
            }
            else
            {
                return View();
            }
            return View();
        }


        private bool LuhnCheck(string cardNumber)
        {


            int checksum = 0;
            bool evenDigit = false;
            foreach(char cardDigit in cardNumber.Reverse())
            {
                if(cardDigit <'0'|| cardDigit > '9')
                {
                    return false;
                }
                int digitValue = (cardDigit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;

                while(digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }
            return (checksum %10) == 0;
        }

        private bool CardExpiryDateIsValid(DateTime expiryDate)
        {
            return DateTime.Now <= expiryDate;
        }


    }
}
