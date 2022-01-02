using GreetingCardGenerator.Data;
using GreetingCardGenerator.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreetingCardGenerator.Helper;

namespace GreetingCardGenerator.Pages.User
{
    public class SignUpModel : PageModel
    {
        private readonly IAppData appData;

        [BindProperty]
        public Member Member { get; set; }
        [BindProperty]
        public string RepeatPassword { get; set; }
        [TempData]
        public string alertMessage { get; set; }
        public SignUpModel(IAppData appData)
        {
            this.appData = appData;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if(Member.PASSWORD!=RepeatPassword)
            {
                TempData["alertMessage"] = "Passwords Don't Match";
                return Page();
            }
           
            Member.PASSWORD_HASH = Security.GetCustomHashCode(Member.PASSWORD);
            var Entity=appData.Signup(Member);
            if(Entity!=null)
            {
               return RedirectToPage("./Login");
            }
            TempData["alertMessage"] = "Could not signup at the moment, Try again later";
            return Page();
            
        }
    }
}
