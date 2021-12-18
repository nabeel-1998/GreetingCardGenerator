using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreetingCardGenerator.Data;
using GreetingCardGenerator.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using GreetingCardGenerator.Helper;

namespace GreetingCardGenerator.Pages.User
{
    public class LoginModel : PageModel
    {
        private readonly IAppData appData;

        [BindProperty]
        public string AdminEmail { get; set; }
        [BindProperty]
        public string AdminPassword { get; set; }

        [BindProperty]
        public string UserEmail { get; set; }

        [BindProperty]
        public string UserPassword { get; set; }

        [TempData]
        public string invalid { get; set; }
        public Admin Admin { get; set; }
        public Member User { get; set; }

        public LoginModel(IAppData appData)
        {
            this.appData = appData;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPostAdmin()
        {
            
            Admin = new Admin 
            {
                ADMIN_ID = 0,
                ADMIN_NAME = "xxxx", 
                EMAIL = AdminEmail, 
                PASSWORD = AdminPassword, 
                PASSWORD_HASH=Security.GetCustomHashCode(AdminPassword)
            };

            Admin = appData.AdminLogin(Admin);
            if(Admin!=null)
            {
                return RedirectToPage("../Manager/Dashboard", Admin);
            }

            TempData["invalid"] = "Invalid Email or Password";
            return Page();
        }

        public IActionResult OnPostMember()
        {

            User = new Member()
            {
                USER_ID = 0,
                USER_NAME = "xxxx",
                EMAIL = UserEmail,
                PASSWORD = "xxxx",
                PASSWORD_HASH = Security.GetCustomHashCode(UserPassword)

            };

            var UserEntity = appData.Login(User);
            if(UserEntity!=null)
            {
                return RedirectToPage("./Dashboard",new { userId = UserEntity.USER_ID});
            }
            TempData["invalid"] = "Invalid Email or Password";
            return Page();

            
        }
    }


    //THIS CODE IS NOT USED
    public static class ModelStateExtensions
    {
        public static ModelStateDictionary MarkAllFieldsAsSkipped(this ModelStateDictionary modelState)
        {
            foreach (var state in modelState.Select(x => x.Value))
            {
                state.Errors.Clear();
                state.ValidationState = ModelValidationState.Skipped;
            }
            return modelState;
        }
    }
}
