using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using test.Models;

[assembly: OwinStartupAttribute(typeof(test.Startup))]
namespace test
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admin"))
            {           
                role.Name = "Admin";
                roleManager.Create(role);

                ApplicationUser user = new ApplicationUser();
                user.UserName = "AhmedAbbass77";
                user.Email = "ahmedrm.ar39@yaho.com";
                user.UserImage = "Admin.jpg";
                user.phone = "01100579367";
                user.PasswordHash = "87Ahmed87";

                var chkUser = UserManager.Create(user, user.PasswordHash);      
                if (chkUser.Succeeded)
                {
                   UserManager.AddToRole(user.Id, "Admin");         
                }

            }
        } 
    }
}
