using Microsoft.AspNet.Identity.EntityFramework;

namespace Ith.WebUI.Models.Identity
{
    public class AppRole : IdentityRole
    {
        public AppRole() { }

        public string Description { get; set; }
    }
}