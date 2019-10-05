using Autofac;
using FrancisStore.Repository;
using FrancisStore.Service;
using FrancisStore.Web.Controllers;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(FrancisStore.Web.Startup))]
namespace FrancisStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            FrancisStore.Identity.Startup.ConfigureAuth(app);
        }
    }
}