using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Users.Models
{
    public enum Cities
    {
        London, Paris, Chicago
    }
    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
    }
}