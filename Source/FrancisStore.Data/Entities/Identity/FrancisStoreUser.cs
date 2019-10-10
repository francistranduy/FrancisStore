using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FrancisStore.Data.Entities.Identity
{
    public class FrancisStoreUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<FrancisStoreUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim(ClaimTypes.Surname, this.LastName));
            userIdentity.AddClaim(new Claim(ClaimTypes.GivenName, this.FirstName));
            userIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, this.Id));
            return userIdentity;
        }

        [Required, DataType(DataType.Text), StringLength(255), DisplayName("First name")]
        public string FirstName { get; set; }
        [Required, DataType(DataType.Text), StringLength(255), DisplayName("Last name")]
        public string LastName { get; set; }
    }
}
