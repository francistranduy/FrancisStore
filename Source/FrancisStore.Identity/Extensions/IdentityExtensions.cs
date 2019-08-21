using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace FrancisStore.Identity
{
    /// <summary>
    ///     Extensions making it easier to get the user profile off of an identity
    /// </summary>
    public static class IdentityExtensions
    {
        /// <summary>
        ///     Return the user first name using the GivenNameClaimType
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetUserFirstName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException();
            }

            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirst(ClaimTypes.GivenName)?.Value;
            }
            return null;
        }

        /// <summary>
        ///     Return the user last name using the SurnameClaimsType
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetUserLastName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException();
            }

            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirst(ClaimTypes.Surname)?.Value;
            }
            return null;
        }
    }
}