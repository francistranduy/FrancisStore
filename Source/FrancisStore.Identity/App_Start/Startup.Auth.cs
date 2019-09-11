using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using FrancisStore.Identity.Models;
using FrancisStore.Identity;
using Microsoft.Owin.Security.Facebook;
using System.Security.Claims;
using System.Threading.Tasks;
using FrancisStore.Data;
using FrancisStore.Data.Entities.Identity;

namespace FrancisStore.Identity
{
    public class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public static void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(FrancisStoreDbContext.Create);
            app.CreatePerOwinContext<FrancisStoreUserManager>(FrancisStoreUserManager.Create);
            app.CreatePerOwinContext<FrancisStoreSignInManager>(FrancisStoreSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<FrancisStoreUserManager, FrancisStoreUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",   
            //   consumerSecret: "");

            var fbAuthOptions = new FacebookAuthenticationOptions()
            {
                AppId = "2369775049977123",
                AppSecret = "430c56c74ef45985f38486084cf6fef4",
            };

            // Set requested scope
            //fbAuthOptions.Scope.Add("email");
            //fbAuthOptions.Scope.Add("default");

            // Set requested fields
            //fbAuthOptions.Fields.Add("email");
            //fbAuthOptions.Fields.Add("first_name");
            //fbAuthOptions.Fields.Add("middle_name");
            //fbAuthOptions.Fields.Add("last_name");

            fbAuthOptions.Provider = new FacebookAuthenticationProvider()
            {
                OnAuthenticated = (context) =>
                {
                    // Attach the access token if you need it later on for calls on behalf of the user
                    context.Identity.AddClaim(new Claim("FacebookAccessToken", context.AccessToken));

                    foreach (var claim in context.User)
                    {
                        //var claimType = string.Format("urn:facebook:{0}", claim.Key);
                        var claimType = string.Format("{0}", claim.Key);
                        string claimValue = claim.Value.ToString();

                        if (!context.Identity.HasClaim(claimType, claimValue))
                            context.Identity.AddClaim(new Claim(claimType, claimValue, "XmlSchemaString", "Facebook"));
                    }

                    return Task.FromResult(0);
                }
            };


            app.UseFacebookAuthentication(fbAuthOptions);



            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}