using ENOCA.NET_CHALLENGE.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENOCA.NET_CHALLENGE.Identity
{
    public class IdentityDataContext: IdentityDbContext<AplicationUser>
    {
        public IdentityDataContext() : base("dataConnection")
        {

        }
    }
}