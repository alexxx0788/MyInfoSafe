using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ShepherdCo.Startup))]

namespace ShepherdCo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
