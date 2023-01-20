using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENOCA.NET_CHALLENGE.Identity
{
    public class AplicationRole:IdentityRole
    {
        public string Description { get; set; }
        public AplicationRole()
        {

        }
        public AplicationRole(string rolename,string description)
        {
            this.Description = description;
        }
    }
}