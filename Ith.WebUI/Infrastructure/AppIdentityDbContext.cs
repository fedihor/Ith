using Ith.WebUI.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ith.WebUI.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("name=PostDbContext") { }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }
}