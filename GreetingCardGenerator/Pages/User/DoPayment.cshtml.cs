using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreetingCardGenerator.Payment_Module;
using GreetingCardGenerator.Helper;

namespace GreetingCardGenerator.Pages.User
{
    public class DoPaymentModel : PageModel
    {
        [BindProperty]
        public PaymentInfo paymentinfo { get; set; }
        public void OnGet()
        {

        }

        [TempData]
        public string PaymentMessage { get; set; }
        public IActionResult OnPost()
        {
            if(paymentinfo!=null)
            {
                StripePayment payment = new StripePayment();
                if(payment.FormatnPay(paymentinfo))
                {
                    TempData["PaymentMessage"] = "Payment Successfull, Your card is being downloaded, Meanwhile Create More cards";
                    //return ImageHelper.DownloadCard(InMemoryInfoHolder.CardImage);
                    
                    return RedirectToPage("./Dashboard",new { userId=InMemoryInfoHolder.UserId});
                }
                TempData["PaymentMessage"]= "Unfortunately, the payment has been declined";
                return Page();

            }
            TempData["PaymentMessage"] = "Please Fill Out all details correctly";
            return Page();
        }

    }
}
