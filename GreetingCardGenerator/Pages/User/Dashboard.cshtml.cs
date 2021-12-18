using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreetingCardGenerator.Pages.User
{
    public class DashboardModel : PageModel
    {
        [BindProperty]
        public string GName { get; set; }
        public static int UserId { get; set; }
        public void OnGet(int userId)
        {
            UserId = UserId;
            
        }

        public IActionResult OnPost()
        {
            if(GName!=null)
            {
                return RedirectToPage("./SelectGreetings", new { gname = GName });
            }
            return Page();
        }
    }
}
