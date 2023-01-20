﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ENOCA.NET_CHALLENGE.Identity
{
    public class AplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}