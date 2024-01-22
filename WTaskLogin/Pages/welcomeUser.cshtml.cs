using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WTaskLogin.Pages
{
    [Authorize]
    public class welcomeUserModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
