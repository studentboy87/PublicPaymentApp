using System;
using System.Linq;
using PaymentApp.Models;
namespace PaymentApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RegisterCardContext registerCardContext)
        {
            registerCardContext.Database.EnsureCreated();
        }
    }
}
