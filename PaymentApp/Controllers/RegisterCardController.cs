using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.Data;
using PaymentApp.Models;
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

                    UKAddress cardAddress = InsertNewUKCardAddress(model);

                    //This method is just here for illustrative purposes and to tie the registered card to a customer
                    var customerId = GetCustomerId();

                    InsertCardDetails(model, cardAddress.ID, customerId);

                ModelState.Clear();
            }
            else
            {
                return View();
            }
            return View();
        }

        private void InsertCardDetails(CardPaymentViewModel model, int addressId, int customerId)
        {
            using(var ctx = _context)
            {

                var registeredCard = new RegisteredCard
                {
                    CardNumber = long.Parse(model.CardNumberString),
                    CardHolderName = model.CardOwnersName,
                    CardExpiryDate = model.ExpiryDate,
                    CustomerID = customerId,
                    AddressID = addressId
                };
                ctx.RegisteredCards.Add(registeredCard);
                ctx.SaveChanges();
            }
        }

        private UKAddress InsertNewUKCardAddress(CardPaymentViewModel model)
        {
            using(var ctx = _context)
            {
                var cardAddress = new UKAddress
                {
                    AddressLine1 = model.CardAddress.AddressLine1,
                    AddressLine2 = model.CardAddress.AddressLine2,
                    Town = model.CardAddress.Town,
                    County = model.CardAddress.County,
                    Postcode = model.CardAddress.Postcode
                };
                ctx.UKAddresses.Add(cardAddress);
                ctx.SaveChanges();
                return cardAddress;
            }         
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


        //this is a stubbed method intented only for illustrative purposes
        public int GetCustomerId()
        {
            return 1;
        }


    }
}
