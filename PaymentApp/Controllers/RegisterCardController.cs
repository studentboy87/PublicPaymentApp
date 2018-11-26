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
                return View(model);
            }
            return View();
        }

        private void InsertCardDetails(CardPaymentViewModel model, int addressId, int customerId)
        {
           

                var registeredCard = new RegisteredCard
                {
                    CardNumber = model.CardNumberString,
                    CardHolderName = model.CardOwnersName,
                    CardExpiryDate = model.ExpiryDate,
                    CustomerID = customerId,
                    AddressID = addressId
                };
                _context.RegisteredCards.Add(registeredCard);
                _context.SaveChanges();
            
        }

        private UKAddress InsertNewUKCardAddress(CardPaymentViewModel model)
        {
            
                var cardAddress = new UKAddress
                {
                    AddressLine1 = model.CardAddress.AddressLine1,
                    AddressLine2 = model.CardAddress.AddressLine2,
                    Town = model.CardAddress.Town,
                    County = model.CardAddress.County,
                    Postcode = model.CardAddress.Postcode
                };
            _context.UKAddresses.Add(cardAddress);
            _context.SaveChanges();
                return cardAddress;
            
        }

        private bool LuhnCheck(string cardNumber)
        {


            int checksum = 0;
            bool evenDigit = false;
            foreach (char cardDigit in cardNumber.Reverse())
            {
                if (cardDigit < '0' || cardDigit > '9')
                {
                    return false;
                }
                int digitValue = (cardDigit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;

                while (digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }
            return (checksum % 10) == 0;
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
