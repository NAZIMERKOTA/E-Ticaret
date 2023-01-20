using ENOCA.NET_CHALLENGE.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ENOCA.NET_CHALLENGE.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {

        protected override void Seed(IdentityDataContext context)
        {

            if (!context.Roles.Any(i => i.Name == "Admin")) 
            {
                var store = new RoleStore<AplicationRole>(context);
                var manager = new RoleManager<AplicationRole>(store);

                var role = new AplicationRole() {Name= "admin", Description= "Admin Role" };
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "User"))
            {
                var store = new RoleStore<AplicationRole>(context);
                var manager = new RoleManager<AplicationRole>(store);

                var role = new AplicationRole() { Name = "User", Description = "User Role" };
                manager.Create(role);
            }


            if (!context.Users.Any(i => i.Name == "nazm"))
            {
                var store = new UserStore<AplicationUser>(context);
                var manager = new UserManager<AplicationUser>(store);

                var user = new AplicationUser() { Name = "nazm", Surname = "erkota", UserName = "nazmerkota", Email = "nzm_98@hotmail.com" };
                manager.Create(user,"123456");
                manager.AddToRole(user.Id, "Admin");
                manager.AddToRole(user.Id, "User");
            }

            if (!context.Users.Any(i => i.Name == "normal"))
            {
                var store = new UserStore<AplicationUser>(context);
                var manager = new UserManager<AplicationUser>(store);

                var user = new AplicationUser() { Name = "normal", Surname = "user", UserName = "normaluser", Email = "normal_user@hotmail.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "User");
            }

            base.Seed(context);
        }
    }
}