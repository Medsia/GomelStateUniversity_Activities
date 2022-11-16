﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<EventUsers> EventUsers { get; set; }
        
    }
}
