using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Users.Models
{
    public enum Cities
    {
        London, Paris, Chicago
    }
    public enum Countries
    {
        NONE, UK, FRANCE, USA
    }

    public class AppUser : IdentityUser {
            public Cities City { get; set; }
            public Countries Country { get; set; }

            public void SetCountryFromCity(Cities city) {
            switch (city) {
            case Cities.London:
                Country = Countries.UK;
                break;
            case Cities.Paris:
                Country = Countries.FRANCE;
                break;
            case Cities.Chicago:
                Country = Countries.USA;
                break;
            default:
                Country = Countries.NONE;
                break;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager) {
            // Note the authenticationType must match the one 
            // defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = 
                await manager.CreateIdentityAsync(this, 
                    DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
            }
        }
    }
