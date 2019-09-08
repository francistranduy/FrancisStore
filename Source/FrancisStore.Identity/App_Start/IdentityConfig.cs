using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using FrancisStore.Identity.Models;
using FrancisStore.Entity.Models;
using FrancisStore.Entity;

namespace FrancisStore.Identity
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class FrancisStoreUserManager : UserManager<FrancisStoreUser>
    {
        public FrancisStoreUserManager(IUserStore<FrancisStoreUser> store)
            : base(store)
        {
        }

        public static FrancisStoreUserManager Create(IdentityFactoryOptions<FrancisStoreUserManager> options, IOwinContext context) 
        {
            var manager = new FrancisStoreUserManager(new UserStore<FrancisStoreUser>(context.Get<FrancisStoreDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<FrancisStoreUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<FrancisStoreUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<FrancisStoreUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<FrancisStoreUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class FrancisStoreSignInManager : SignInManager<FrancisStoreUser, string>
    {
        public FrancisStoreSignInManager(FrancisStoreUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(FrancisStoreUser user)
        {
            return user.GenerateUserIdentityAsync((FrancisStoreUserManager)UserManager);
        }

        public static FrancisStoreSignInManager Create(IdentityFactoryOptions<FrancisStoreSignInManager> options, IOwinContext context)
        {
            return new FrancisStoreSignInManager(context.GetUserManager<FrancisStoreUserManager>(), context.Authentication);
        }
    }
}
