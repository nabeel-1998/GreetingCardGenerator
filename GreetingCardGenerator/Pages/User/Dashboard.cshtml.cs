using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreetingCardGenerator.Pages.User
{
    
    public class DashboardModel : PageModel
    {

        [TempData]
        public string PaymentMessage { get; set; }
        [BindProperty]
        public string GName { get; set; }
        public static int UserId { get; set; }
        public void OnGet(int userId)
        {
            UserId = UserId;
            
        }

        public IActionResult OnPost()
        {
            return GName != null ? RedirectToPage("./SelectGreetings", new { gname = GName }) : (IActionResult)Page();
        }
    }
}
