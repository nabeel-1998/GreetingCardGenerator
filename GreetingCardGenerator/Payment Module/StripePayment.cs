﻿using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCardGenerator.Payment_Module
{
    public class StripePayment
    {
        private string CardNumber;
        private string Cvc;
        private string ExpMonth;
        private string ExpYear;

        public bool FormatnPay(PaymentInfo PaymentInfo)
        {
            CardNumber = CryptoEngine.Decrypt(PaymentInfo.CardNumber, Helper.InMemoryInfoHolder.UserId.ToString());
            Cvc = CryptoEngine.Decrypt(PaymentInfo.Cvc, Helper.InMemoryInfoHolder.UserId.ToString());
            ExpMonth = PaymentInfo.ExpireMonth.ToString();
            ExpYear = PaymentInfo.ExpireYear.ToString();
            //return StripePay();
            return true;
        }
        private bool StripePay()
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51If20qKme4ylLpJqCqLr2nw0chcXSm6zi0vCffHptgB8xa1wSUH3qbxCvsSFIHvP6ZLSi1tuXqhFzNApyB4XIEC6001UUZghYc";
                //Step 1: Create Card Options
                TokenCardOptions stripeOptions = new TokenCardOptions();
                stripeOptions.Number = CardNumber;
                stripeOptions.Cvc = Cvc;
                stripeOptions.ExpMonth = long.Parse(ExpMonth);
                stripeOptions.ExpYear = int.Parse(ExpYear);

                //Step 2: Assign Card to a Token
                TokenCreateOptions stripeCard = new TokenCreateOptions();
                stripeCard.Card = stripeOptions;

                TokenService service = new TokenService();
                Token newToken = service.Create(stripeCard);

                //Step 3: Assign Token to the source
                var Options = new SourceCreateOptions
                {
                    Type = SourceType.Card,
                    Currency = "pkr",
                    Token = newToken.Id
                };

                var sourceService = new SourceService();
                var source = sourceService.Create(Options);

                //Step 4: Create Customer Options
                CustomerCreateOptions customerOptions = new CustomerCreateOptions
                {
                    Name = "",
                    Email = "",
                    Address = new AddressOptions { Country = "Pakistan" }
                };

                var customerService = new CustomerService();
                var Customer = customerService.Create(customerOptions);


                //Step 5: Charge Options
                var ChargeOptions = new ChargeCreateOptions
                {
                    Amount = long.Parse("100"),
                    Currency = "PKR",
                    ReceiptEmail = "asadregards@gmail.com", //user Email will be provided
                    Customer = Customer.Id,
                    Source = source.Id


                };

                //Step 6: Charge the Customer
                var chargeService = new ChargeService();
                Charge charge = chargeService.Create(ChargeOptions);
                if (charge.Status == "succeeded")
                {
                    return true;
                    //show "Payment successfull";
                }
                else
                {
                    //Payment declined
                    return false;
                    
                }
            }
            catch (Exception)
            {
                return false;
                //show "Payment Declined"
            }


        }
    }
}

