using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreetingCardGenerator.Pages.Manager
{
    public class DashboardModel : PageModel
    {
        public int AdminId { get; set; }
        public void OnGet(int adminId)
        {
            AdminId = adminId;
        }

    }
}
